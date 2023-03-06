using DirectoryOfTeachers.Bot.Dialogs;
using DirectoryOfTeachers.Bot.Handlers;
using DirectoryOfTeachers.Bot.Parameters;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Bot.Commands
{
    public abstract class Command
    {
        public Dialog CurrentDialog { get; private set; }
        
        private DialogHandler _dialogHandler;
        private long _chatId;

        public void Init(DialogHandler dialogHandler, Update update)
        {
            _dialogHandler = dialogHandler;
            _chatId = update.Message.Chat.Id;

            if (_dialogHandler.Dialogs.ContainsKey(_chatId))
                CurrentDialog = _dialogHandler.Dialogs[_chatId];
        }

        public abstract Task InvokeAsync(CommandParameters parameters);
        
        public async Task StartDialogAsync(Dialog dialog, CommandParameters parameters)
        {
            if (_dialogHandler == null)
                throw new InvalidOperationException("_dialogHandler is null");

            if (dialog == null)
                throw new ArgumentNullException(nameof(dialog));

            await _dialogHandler.StartDialogAsync(_chatId, dialog, new DialogParameters
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
            });
        }
    }
}
