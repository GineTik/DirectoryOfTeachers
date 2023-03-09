using DirectoryOfTeachers.Framework.Dialogs;

namespace DirectoryOfTeachers.Framework.Helpers
{
    public static class DialogHelper
    {
        public static IEnumerable<Type> GetDialogsTypes()
        {
            return TypeHelper.GetTypes(
                type => type.BaseType == typeof(Dialog));
        }

        public static IEnumerable<Type> GetDialogsStepsTypes()
        {
            return TypeHelper.GetTypes(
                type => type.BaseType == typeof(DialogStep));
        }
    }
}
