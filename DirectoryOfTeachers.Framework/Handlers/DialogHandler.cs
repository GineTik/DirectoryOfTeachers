using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DirectoryOfTeachers.Framework.Handlers
{
    public class DialogHandler : IHandler
    {
        public Dictionary<long, Dialog> Dialogs => _stack.Dialogs;

        private readonly DialogStack _stack;

        public DialogHandler(DialogStack stack)
        {
            _stack = stack;
        }

        public bool CanHandle(Update update)
        {
            var message = update.Message;
            if (message == null || message.Type != MessageType.Text)
                return false;

            var chatId = message.Chat.Id;
            return Dialogs.ContainsKey(chatId);
        }

        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            if (CanHandle(update) == false)
                throw new InvalidOperationException("can't handle the dialog");

            var chatId = update.Message.Chat.Id;
            var dialog = Dialogs[chatId];

            await dialog.InvokeCurrentStepAsync(new DialogParameters
            {
                BotClient = botClient,
                Update = update
            });
        }
    }
}
