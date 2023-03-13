using DirectoryOfTeachers.Framework.Buttons;
using Microsoft.Extensions.DependencyInjection;

namespace DirectoryOfTeachers.Framework.Helpers
{
    public static class ButtonHelper
    {
        public static IEnumerable<Type> GetButtonsTypes()
        {
            return TypeHelper.GetTypes(t => t.BaseType == typeof(Button));
        }
    }
}
