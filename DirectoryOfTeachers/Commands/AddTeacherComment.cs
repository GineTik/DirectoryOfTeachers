using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Dialogs.Extensions;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/add_teacher")]
    public class AddTeacherComment : Command
    {
        public override async Task InvokeAsync(CommandParameters parameters)
        {
            await DialogStack.StartDialogAsync<AddTeacherDialog>(parameters);
        }
    }
}
