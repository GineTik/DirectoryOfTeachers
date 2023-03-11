using DirectoryOfTeachers.Bot.Dialogs.DialogSteps.SimpleDialog;
using DirectoryOfTeachers.Framework.Parameters;
using DirectoryOfTeachers.Framework.Dialogs;
using Telegram.Bot;
using DirectoryOfTeachers.Core.DTOs.Teacher;

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

            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, $"Вас звати {name}, вам {age} років!");
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, "Дякую за успішне завершення діалогу");
        }
    }
}
