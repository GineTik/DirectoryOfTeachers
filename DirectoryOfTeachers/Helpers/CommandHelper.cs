using DirectoryOfTeachers.Bot.Attributes;
using DirectoryOfTeachers.Bot.Commands;
using System.Reflection;

namespace DirectoryOfTeachers.Bot.Helpers
{
    public static class CommandHelper
    {
        public static List<CommandAttribute> GetAll()
        {
            IEnumerable<Type> allTypes = Assembly.GetExecutingAssembly().GetTypes();

            var commandAttributes = new List<CommandAttribute>();

            foreach (Type type in allTypes)
                commandAttributes.AddRange(type.GetCustomAttributes<CommandAttribute>());

            return commandAttributes;
        }

        public static Command? GetCommand(string command)
        {
            IEnumerable<Type> handlerTypes = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => type.GetCustomAttributes<CommandAttribute>()
                   .Any(attr => attr.Command == command));

            if (handlerTypes.Any())
            {
                Type handlerType = handlerTypes.First();
                Command handler = (Command)Activator.CreateInstance(handlerType);
                return handler;
            }
            else
            {
                return null;
            }
        }
    }
}
