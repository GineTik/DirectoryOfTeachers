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

        public Message? TryGetMessage(string key)
        {
            Messages.TryGetValue(key, out var message);
            return message;
        }
    }
}
