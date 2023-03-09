using System.Reflection;

namespace DirectoryOfTeachers.Framework.Helpers
{
    public static class TypeHelper
    {
        public static IEnumerable<Type> GetTypes(Predicate<Type>? predicate = null)
        {
            if (predicate == null)
                return Assembly.GetEntryAssembly()?.GetTypes() ?? new Type[0];

            return Assembly.GetEntryAssembly()?.GetTypes()
               .Where(t => predicate(t)) ?? new Type[0];
        }
    }
}
