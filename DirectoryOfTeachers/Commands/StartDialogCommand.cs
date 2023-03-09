using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Parameters;
using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Framework.Dialogs.Extensions;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/start_dialog", Description = "Простенький діалог для тесту")]
    public class StartDialogCommand : Command
    {
        public override async Task InvokeAsync(CommandParameters parameters)
        {
            await DialogStack.StartDialogAsync<SimpleDialog>(parameters);
        }
    }
}
