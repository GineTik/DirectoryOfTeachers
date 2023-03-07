using DirectoryOfTeachers.Bot.Dialogs;
using DirectoryOfTeachers.Bot.Parameters;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Bot.Commands
{
    public abstract class Command
    {
        public Dialog CurrentDialog { get; private set; }
        
        private DialogStack _dialogStack;
        private long _chatId;

        public void Init(DialogStack dialogStack, Update update)
        {
            _dialogStack = dialogStack;
            _chatId = update.Message.Chat.Id;

            if (_dialogStack.Dialogs.ContainsKey(_chatId))
                CurrentDialog = _dialogStack.Dialogs[_chatId];
        }

        public abstract Task InvokeAsync(CommandParameters parameters);
        
        public async Task StartDialogAsync(Dialog dialog, CommandParameters parameters)
        {
            if (_dialogStack == null)
                throw new InvalidOperationException("_dialogStack is null");

            if (dialog == null)
                throw new ArgumentNullException(nameof(dialog));

            await _dialogStack.StartDialogAsync(_chatId, dialog, new DialogParameters
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
            });
        }
    }
}
