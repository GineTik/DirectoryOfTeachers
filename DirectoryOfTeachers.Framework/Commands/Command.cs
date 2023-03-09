using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Framework.Commands
{
    public abstract class Command
    {
        public Dialog CurrentDialog { get; private set; }
        public DialogStack DialogStack { get; set; }
        
        private long _chatId;

        public void Init(DialogStack dialogStack, Update update)
        {
            DialogStack = dialogStack;
            _chatId = update.Message.Chat.Id;

            if (DialogStack.Dialogs.ContainsKey(_chatId))
                CurrentDialog = DialogStack.Dialogs[_chatId];
        }

        public abstract Task InvokeAsync(CommandParameters parameters);
    }
}
