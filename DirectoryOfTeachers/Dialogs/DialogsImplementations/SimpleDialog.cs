using DirectoryOfTeachers.Bot.Dialogs.DialogSteps.SimpleDialog;
using DirectoryOfTeachers.Framework.Parameters;
using DirectoryOfTeachers.Framework.Dialogs;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations
{
    public class SimpleDialog : Dialog
    {
        public override List<IDialogStep> SetSteps()
        {
            return new List<IDialogStep>()
            {
                new WriteNameDialogStep(),
                new AgeDialogStep()
            };
        }

        public override async Task StepsEndedCallback(DialogParameters parameters)
        {
            var name = DialogContext.Messages[typeof(WriteNameDialogStep).FullName].Text;
            var age = DialogContext.Messages[typeof(AgeDialogStep).FullName].Text;

            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, $"Вас звати {name}, вам {age} років!");
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, "Дякую за успішне завершення діалогу");
        }
    }
}
