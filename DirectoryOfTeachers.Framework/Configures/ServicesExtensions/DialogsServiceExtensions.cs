using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Handlers;
using DirectoryOfTeachers.Framework.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Framework.Configures.ServicesExtensions
{
    public static class DialogsServiceExtensions
    {
        public static void AddDialogs(this ServiceCollection services)
        {
            services.AddSingleton<IHandler, DialogHandler>();
            services.AddSingleton<DialogStack>();

            foreach (var type in DialogHelper.GetDialogsTypes())
                services.AddTransient(type);

            foreach (var type in DialogHelper.GetDialogsStepsTypes())
                services.AddTransient(type);
        }
    }
}
