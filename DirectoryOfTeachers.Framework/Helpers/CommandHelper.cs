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
            IEnumerable<Type> allTypes = GetTypes();

            var commandAttributes = new List<CommandAttribute>();

            foreach (Type type in allTypes)
                commandAttributes.AddRange(type.GetCustomAttributes<CommandAttribute>());

            return commandAttributes;
        }

        public static IEnumerable<Type> GetCommandTypes()
        {
            IEnumerable<Type> types = GetTypes(type => type.GetCustomAttributes<CommandAttribute>().Count() != 0);

            return types;
        }

        public static Type? GetCommandType(string command)
        {
            IEnumerable<Type> handlerTypes = GetTypes(
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

        private static IEnumerable<Type> GetTypes(Predicate<Type>? predicate = null)
        {
            if (predicate == null)
                return Assembly.GetEntryAssembly()?.GetTypes() ?? new Type[0];

            return Assembly.GetEntryAssembly()?.GetTypes()
               .Where(t => predicate(t)) ?? new Type[0];
        }
    }
}
