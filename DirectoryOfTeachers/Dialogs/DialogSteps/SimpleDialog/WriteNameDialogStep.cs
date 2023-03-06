using DirectoryOfTeachers.Bot.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.SimpleDialog
{
    public class WriteNameDialogStep : IDialogStep
    {
        public async Task<IDialogStep?> InvokeAsync(DialogStepParameters parameter)
        {
            var chatId = parameter.ChatId;
            await parameter.BotClient.SendTextMessageAsync(chatId, "Яке ваше імя?");
            return await Task.Run(() => parameter.Next);
        }
    }
}
