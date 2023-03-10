using DirectoryOfTeachers.Framework.Dialogs;

namespace DirectoryOfTeachers.Framework.Factories.Interfaces
{
    public interface IDialogStepFactory
    {
        DialogStep Create(Type stepType, Dialog owner);
    }
}
