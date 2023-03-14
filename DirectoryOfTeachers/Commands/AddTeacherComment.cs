using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/add_teacher")]
    public class AddTeacherComment : Command
    {
        private readonly DialogStack _stack;

        public AddTeacherComment(DialogStack stack)
        {
            _stack = stack;
        }

        public override async Task InvokeAsync(CommandParameters parameters)
        {
            await _stack.StartDialogAsync<AddTeacherDialog, CommandParameters>(parameters);
        }
    }
}
