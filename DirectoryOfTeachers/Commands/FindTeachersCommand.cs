using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/find_teacher", Description = "Знайти вчителя за іменем та навчальним закладом")]
    public class FindTeachersCommand : Command
    {
        private readonly DialogStack _stack;

        public FindTeachersCommand(DialogStack stack)
        {
            _stack = stack;
        }

        public override async Task InvokeAsync(CommandParameters parameters)
        {
            await _stack.StartDialogAsync<FindTeacherDialog, CommandParameters>(parameters);
        }
    }
}
