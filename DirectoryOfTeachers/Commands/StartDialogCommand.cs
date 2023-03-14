using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Parameters;
using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Framework.Dialogs.Extensions;
using DirectoryOfTeachers.Framework.Dialogs;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/start_dialog", Description = "Простенький діалог для тесту")]
    public class StartDialogCommand : Command
    {
        private readonly DialogStack _stack;

        public StartDialogCommand(DialogStack stack)
        {
            _stack = stack;
        }

        public override async Task InvokeAsync(CommandParameters parameters)
        {
            await _stack.StartDialogAsync<SimpleDialog>(parameters);
        }
    }
}
