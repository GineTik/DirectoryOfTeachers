using DirectoryOfTeachers.Framework.Dialogs;

namespace DirectoryOfTeachers.Framework.Parameters
{
    public class DialogStepParameters : BaseParameters
    {
        public DialogContext DialogContext { get; set; }
        public IDialogStep? Next { get; set; }
    }
}
