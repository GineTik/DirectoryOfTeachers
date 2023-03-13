using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public class DialogContext
    {
        public Dictionary<string, Message> Messages { get; }
        public Message LastMessage => Messages.LastOrDefault().Value;

        private Dictionary<string, object> _models;

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
            object model;
            _models.TryGetValue(nameof(TModel), out model);

            if (model == null)
                throw new InvalidCastException($"this model({nameof(TModel)}) not exists");

            return (TModel)model;
        }

        public void AddModel<TModel>()
            where TModel : new()
        {
            AddModel(new TModel());
        }

        public void AddModel<TModel>(TModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            _models.Add(nameof(TModel), model);
        }
    }
}
