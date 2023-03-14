using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Helpers;
using DirectoryOfTeachers.Framework.Parameters;
using System.Reflection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DirectoryOfTeachers.Framework.Handlers
{
    public class CommandHandler : IHandler
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public bool CanHandle(Update update)
        {
            var message = update.Message;
            return message != null && message.Type == MessageType.Text && message.Text.StartsWith("/");
        }

        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            if (CanHandle(update) == false)
                throw new InvalidOperationException("can't handle the command");

            var message = update.Message;
            var commandString = message.Text.Split(' ')[0];

            Command? command = CommandHelper.GetCommand(commandString, _serviceProvider);

            if (command == null)
                return;

            await TryInvokeCommand(botClient, update, command);
        }

        private async Task TryInvokeCommand(ITelegramBotClient botClient, Update update, Command command)
        {
            var attributes = command.GetType().GetCustomAttributes<CanInvokeCommandAttribute>();

            foreach (var attribute in attributes)
            {
                if (attribute.CanInvoke(update) == false)
                {
                    await botClient.SendTextMessageAsync(update.Message.Chat.Id, attribute.Message);
                    return;
                }
            }

            await command.InvokeAsync(new CommandParameters
            {
                BotClient = botClient,
                Update = update,
                QueryParameters = GetQueryParameters(update.Message.Text)
            });
        }

        private List<string> GetQueryParameters(string message)
        {
            var queryParameters = message.Split(' ').ToList();
            queryParameters.RemoveAt(0);
            return queryParameters;
        }
    }
}
