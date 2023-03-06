using DirectoryOfTeachers.Bot.Dialogs;
using DirectoryOfTeachers.Bot.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace DirectoryOfTeachers.Bot.Handlers
{
    public class DialogHandler : IHandler
    {
        public Dictionary<long, Dialog> Dialogs { get; }

        public DialogHandler()
        {
            Dialogs = new Dictionary<long, Dialog>();
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

        public async Task StartDialogAsync(long chatId, Dialog dialog, DialogParameters parameters)
        {
            if (Dialogs.ContainsKey(chatId))
                DialogEnded(chatId);

            Dialogs.Add(chatId, dialog);
            dialog.StepsEndedAction = DialogEnded;
            await dialog.InvokeCurrentStepAsync(parameters);
        }

        public void DialogEnded(long chatId)
        {
            if (Dialogs.ContainsKey(chatId))
                Dialogs.Remove(chatId);
        }
    }
}
