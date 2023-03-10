using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Helpers;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DirectoryOfTeachers.Framework.Handlers
{
    public class CommandHandler : IHandler
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly DialogStack _dialogStack;

        public CommandHandler(IServiceProvider serviceProvider, DialogStack dialogStack)
        {
            _serviceProvider = serviceProvider;
            _dialogStack = dialogStack;
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

            if (command != null)
            {
                command.Init(_dialogStack, update);

                var queryParameters = message.Text.Split(' ').ToList();
                queryParameters.RemoveAt(0);

                await command.InvokeAsync(new CommandParameters 
                { 
                    BotClient = botClient,
                    Update = update,
                    QueryParameters = queryParameters
                });
            }
        }
    }
}
