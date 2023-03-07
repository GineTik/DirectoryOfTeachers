using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public interface IDialogStep
    {
        Task<IDialogStep?> InvokeAsync(DialogStepParameters parameter);
    }
}
