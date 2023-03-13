using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public abstract class DialogStep
    {
        public Dialog Dialog { get; set; }
        public DialogContext? DialogContext => Dialog?.DialogContext;

        public abstract Task InvokeAsync(DialogStepParameters parameters);

        public void Init(Dialog dialog)
        {
            if (dialog == null) 
                throw new ArgumentNullException(nameof(dialog));

            Dialog = dialog;
        }

        public virtual async Task TakeResultAsync(DialogStepParameters parameters) { }

        protected void NextStep<T>()
            where T : DialogStep
        {
            Dialog.SetNextStep(typeof(T));
        }
    }
}
