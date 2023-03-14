using DirectoryOfTeachers.Bot.Dialogs.DialogSteps.SimpleDialog;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations
{
    public class SimpleDialog : Dialog
    {
        public SimpleDialog()
        {
            SetNextStep(typeof(WriteNameDialogStep));
        }

        public override async Task StepsEndedCallback(DialogParameters parameters)
        {
            var name = DialogContext.TryGetMessage(typeof(WriteNameDialogStep).Name)?.Text;
            var age = DialogContext.TryGetMessage(typeof(AgeDialogStep).Name)?.Text;

            await parameters.SendTextAnswerAsync($"Вас звати {name}, вам {age} років!");
            await parameters.SendTextAnswerAsync("Дякую за успішне завершення діалогу");
        }
    }
}
