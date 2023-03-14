using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.AddCharacteristicDialog
{
    public class GetCharacteristicNameDialogStep : DialogStep
    {
        public override async Task InvokeAsync(DialogStepParameters parameters)
        {
            await parameters.SendTextAnswerAsync("Введіть назву характеристики");
        }
    }
}
