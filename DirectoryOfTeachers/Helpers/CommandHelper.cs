using DirectoryOfTeachers.Bot.Attributes;
using DirectoryOfTeachers.Bot.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DirectoryOfTeachers.Bot.Helpers
{
    public static class CommandHelper
    {
        public static List<CommandAttribute> GetAllCommandAttributes()
        {
            IEnumerable<Type> allTypes = Assembly.GetExecutingAssembly().GetTypes();

            var commandAttributes = new List<CommandAttribute>();

            foreach (Type type in allTypes)
                commandAttributes.AddRange(type.GetCustomAttributes<CommandAttribute>());

            return commandAttributes;
        }

        public static IEnumerable<Type> GetCommandTypes()
        {
            IEnumerable<Type> types = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => type.GetCustomAttributes<CommandAttribute>().Count() != 0);

            return types;
        }

        public static Type? GetCommandType(string command)
        {
            IEnumerable<Type> handlerTypes = Assembly.GetExecutingAssembly().GetTypes()
               .Where(type => type.GetCustomAttributes<CommandAttribute>()
                   .Any(attr => attr.Command == command));

            if (handlerTypes.Any())
            {
                Type handlerType = handlerTypes.First();
                return handlerType;
                //Command handler = (Command)Activator.CreateInstance(handlerType);
                //return handler;
            }
            else
            {
                return null;
            }
        }

        public static Command? GetCommand(string commandString, IServiceProvider _serviceProvider)
        {
            var commands = _serviceProvider.GetServices<Command>();
            return commands.FirstOrDefault(c =>
                c.GetType()
                .GetCustomAttributes<CommandAttribute>()
                .Any(attr => attr.Command == commandString));
        }
    }
}
