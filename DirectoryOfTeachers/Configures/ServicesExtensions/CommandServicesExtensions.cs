using DirectoryOfTeachers.Bot.Commands;
using DirectoryOfTeachers.Bot.Handlers;
using DirectoryOfTeachers.Bot.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Bot.Configures.ServicesExtensions
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
