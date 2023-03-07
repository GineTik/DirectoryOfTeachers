using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public class DialogContext
    {
        public Dictionary<string, Message> Messages { get; }
        public Message LastMessage => Messages.LastOrDefault().Value;

        public DialogContext()
        {
            Messages = new Dictionary<string, Message>();
        }
    }
}
