using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Factories.Implementations;
using DirectoryOfTeachers.Framework.Factories.Interfaces;
using DirectoryOfTeachers.Framework.Handlers;
using DirectoryOfTeachers.Framework.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Framework.Configures.ServicesExtensions
{
    public static class ButtonServiceExtensions
    {
        public static void AddButtons(this ServiceCollection services)
        {
            services.AddSingleton<IHandler, ButtonHandler>();
            services.AddSingleton<ButtonStack>();
            services.AddTransient<IButtonFactory, ButtonFactory>();

            foreach (var type in ButtonHelper.GetButtonsTypes())
                services.AddTransient(type);
        }
    }
}
