using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.FindTeacherDialog
{
    public class GetNameDialogStep : DialogStep
    {
        public override async Task InvokeAsync(DialogStepParameters parameters)
        {
            await parameters.SendTextAnswerAsync("Введіть ім'я викладача");
            NextStep<GetEducationInstitutionDialogStep>();
        }
    }
}
