using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace DirectoryOfTeachers.Framework.Helpers
{
    public static class CommandHelper
    {
        public static List<CommandAttribute> GetAllCommandAttributes()
        {
            IEnumerable<Type> allTypes = TypeHelper.GetTypes();

            var commandAttributes = new List<CommandAttribute>();

            foreach (Type type in allTypes)
                commandAttributes.AddRange(type.GetCustomAttributes<CommandAttribute>());

            return commandAttributes;
        }

        public static IEnumerable<Type> GetCommandTypes()
        {
            IEnumerable<Type> types = TypeHelper.GetTypes(type => type.GetCustomAttributes<CommandAttribute>().Count() != 0);

            return types;
        }

        public static Type? GetCommandType(string command)
        {
            IEnumerable<Type> handlerTypes = TypeHelper.GetTypes(
                type => type.GetCustomAttributes<CommandAttribute>()
                   .Any(attr => attr.Command == command));

            if (handlerTypes.Any())
            {
                Type handlerType = handlerTypes.First();
                return handlerType;
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
