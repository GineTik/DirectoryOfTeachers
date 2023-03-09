using DirectoryOfTeachers.Framework.Parameters;
using DirectoryOfTeachers.Framework.Dialogs;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.SimpleDialog
{
    public class AgeDialogStep : DialogStep
    {
        public override async Task InvokeAsync(DialogStepParameters parameter)
        {
            var chatId = parameter.ChatId;
            var name = parameter.Message.Text; 

            await parameter.BotClient.SendTextMessageAsync(chatId, $"Добре {name}, скільки вам років!");
        }
    }
}
