using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public class DialogContext
    {
        public Dictionary<string, Message> Messages { get; }
        public Message LastMessage => Messages.LastOrDefault().Value;

        private object _model;

        public DialogContext()
        {
            Messages = new Dictionary<string, Message>();
        }

        public Message? TryGetMessage(string key)
        {
            Messages.TryGetValue(key, out var message);
            return message;
        }

        public TModel GetModel<TModel>()
            where TModel : class, new()
        {
            if (_model == null)
                _model = new TModel();

            var model = _model as TModel;

            if (model == null)
                throw new InvalidCastException("failed cast to " + nameof(TModel));

            return model;
        }
    }
}
