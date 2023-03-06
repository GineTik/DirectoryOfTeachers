using DirectoryOfTeachers.Bot.Dialogs;

namespace DirectoryOfTeachers.Bot.Parameters
{
    public class DialogStepParameters : BaseParameters
    {
        public DialogContext DialogContext { get; set; }
        public IDialogStep? Next { get; set; }
    }
}
