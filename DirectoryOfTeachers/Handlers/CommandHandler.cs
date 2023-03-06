using DirectoryOfTeachers.Bot.Commands;
using DirectoryOfTeachers.Bot.Helpers;
using DirectoryOfTeachers.Bot.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DirectoryOfTeachers.Bot.Handlers
{
    public class CommandHandler : IHandler
    {
        private readonly DialogHandler _dialogHandler;

        public CommandHandler(DialogHandler dialogHandler)
        {
            _dialogHandler = dialogHandler;
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

            Command command = CommandHelper.GetCommand(commandString);
            command.Init(_dialogHandler, update);

            if (command != null)
            {
                await command.InvokeAsync(new CommandParameters 
                { 
                    BotClient = botClient,
                    Update = update,
                });
            }
        }
    }
}
