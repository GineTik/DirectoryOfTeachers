using DirectoryOfTeachers.Bot.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs
{
    public class DialogStack
    {
        public Dictionary<long, Dialog> Dialogs { get; }

        public DialogStack()
        {
            Dialogs = new Dictionary<long, Dialog>();
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
