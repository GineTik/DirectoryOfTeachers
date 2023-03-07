using DirectoryOfTeachers.Bot.Dialogs;
using DirectoryOfTeachers.Bot.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Bot.Configures.ServicesExtensions
{
    public static class DialogsServiceExtensions
    {
        public static void AddDialogs(this ServiceCollection services)
        {
            services.AddSingleton<IHandler, DialogHandler>();
            services.AddSingleton<DialogStack>();
        }
    }
}
