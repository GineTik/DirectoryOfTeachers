using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.SimpleDialog
{
    public class WriteNameDialogStep : DialogStep
    {
        public override async Task InvokeAsync(DialogStepParameters parameter)
        {
            var chatId = parameter.ChatId;
            await parameter.BotClient.SendTextMessageAsync(chatId, "Яке ваше імя?");

            NextStep<AgeDialogStep>();
        }
    }
}
