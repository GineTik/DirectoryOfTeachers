using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Handlers;
using DirectoryOfTeachers.Framework.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Framework.Configures.ServicesExtensions
{
    public static class CommandServicesExtensions
    {
        public static void AddCommands(this ServiceCollection services)
        {
            services.AddSingleton<IHandler, CommandHandler>();
            foreach (var commandType in CommandHelper.GetCommandTypes())
                services.AddTransient(typeof(Command), commandType);
        }
    }
}
