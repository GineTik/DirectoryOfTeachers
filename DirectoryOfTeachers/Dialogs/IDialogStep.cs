using DirectoryOfTeachers.Bot.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs
{
    public interface IDialogStep
    {
        Task<IDialogStep?> InvokeAsync(DialogStepParameters parameter);
    }
}
