namespace DirectoryOfTeachers.Bot.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class CommandAttribute : Attribute
    {
        public string Command { get; set; }
        public string Description { get; set; }

        public CommandAttribute(string command)
        {
            Command = command;
        }
    }
}
