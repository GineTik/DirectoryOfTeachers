using DirectoryOfTeachers.Framework.Buttons;

namespace DirectoryOfTeachers.Framework.Factories.Interfaces
{
    public interface IButtonFactory
    {
        public Button CreateButton<TButton>(string text, object? data = null)
            where TButton : Button;
    }
}
