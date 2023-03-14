using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.FindTeacherDialog
{
    public class GetEducationInstitutionDialogStep : DialogStep
    {
        public override async Task InvokeAsync(DialogStepParameters parameters)
        {
            await parameters.SendTextAnswerAsync("Введіть навчальний заклад викладача");
        }
    }
}
