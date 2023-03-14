using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public class DialogStack
    {
        private readonly IServiceProvider _provider;

        public Dictionary<long, Dialog> Dialogs { get; }

        public DialogStack(IServiceProvider provider)
        {
            Dialogs = new Dictionary<long, Dialog>();
            _provider = provider;
        }

        public async Task StartDialogAsync<TDialog, TParameter>(TParameter parameters, object? data = null)
            where TDialog : Dialog
            where TParameter : BaseParameters
        {
            await StartDialogAsync(typeof(TDialog), new DialogParameters
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
            }, data);
        }

        public async Task StartDialogAsync(Type DialogType, DialogParameters parameters, object? data = null)
        {
            var chatId = parameters.ChatId;

            if (Dialogs.ContainsKey(chatId))
                DialogEnded(chatId);

            var dialog = _provider.GetService(DialogType) as Dialog;

            if (dialog == null)
                throw new InvalidOperationException("dialog is null");

            dialog.Init(_provider, data);
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
