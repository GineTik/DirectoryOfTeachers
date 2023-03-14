using DirectoryOfTeacher.DataAccess.EF;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Helpers;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/help", Description = "Допомогає розібратися в коммандах")]
    public class HelpCommand : Command
    {
        public override async Task InvokeAsync(CommandParameters parameters)
        {
            var commandAttributes = CommandHelper.GetAllCommandAttributes();
            var resultMessage = string.Join("\n", commandAttributes.Select(x => x.Command + " - " + x.Description));

            await parameters.SendTextAnswerAsync("Ось усі комманди які має бот: \n\n" + resultMessage);
            await Task.Delay(10000);
        }
    }
}
