using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Bot.Attributes;
using DirectoryOfTeachers.Bot.Helpers;
using DirectoryOfTeachers.Bot.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Commands.CommandImplementations
{
    [Command("/help", Description = "Допомогає розібратися в коммандах")]
    public class HelpCommand : Command
    {
        public override async Task InvokeAsync(CommandParameters parameters)
        {
            var commandAttributes = CommandHelper.GetAllCommandAttributes();
            var resultMessage = String.Join("\n", commandAttributes.Select(x => x.Command + " - " + x.Description));

            var chatId = parameters.ChatId;
            await parameters.BotClient.SendTextMessageAsync(chatId, "Ось усі комманди які має бот: \n\n" + resultMessage);
            await Task.Delay(10000);
        }
    }
}
