using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Handlers;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Framework.Configures.ServicesExtensions
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
