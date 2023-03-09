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

        public async Task StartDialogAsync<TDialog>(DialogParameters parameters)
            where TDialog : Dialog
        {
            await StartDialogAsync(typeof(TDialog), parameters);
        }

        public async Task StartDialogAsync(Type DialogType, DialogParameters parameters)
        {
            var chatId = parameters.ChatId;

            if (Dialogs.ContainsKey(chatId))
                DialogEnded(chatId);

            var dialog = _provider.GetService(DialogType) as Dialog;

            if (dialog == null)
                throw new InvalidOperationException("dialog is null");

            dialog.Init(_provider);
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
