using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Framework.Commands
{
    public abstract class Command
    {
        public abstract Task InvokeAsync(CommandParameters parameters);
    }
}
