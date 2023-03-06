using DirectoryOfTeachers.Bot.Attributes;
using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Bot.Parameters;

namespace DirectoryOfTeachers.Bot.Commands.CommandImplementations
{
    [Command("/start_dialog", Description = "Простенький діалог для тесту")]
    public class StartDialogCommand : Command
    {
        public override async Task InvokeAsync(CommandParameters parameters)
        {
            await StartDialogAsync(new SimpleDialog(), parameters);
        }
    }
}
