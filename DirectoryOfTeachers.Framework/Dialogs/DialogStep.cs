﻿using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Framework.Dialogs
{
    public abstract class DialogStep
    {
        public Dialog Dialog { get; set; }

        public abstract Task InvokeAsync(DialogStepParameters parameter);

        public void Init(Dialog dialog)
        {
            if (dialog == null) 
                throw new ArgumentNullException(nameof(dialog));

            Dialog = dialog;
        }

        protected void NextStep<T>()
            where T : DialogStep
        {
            Dialog.SetNextStep(typeof(T));
        }
    }
}