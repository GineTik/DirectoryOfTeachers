using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Factories.Interfaces;

namespace DirectoryOfTeachers.Framework.Factories.Implementations
{
    public class ButtonFactory : IButtonFactory
    {
        private readonly IServiceProvider _provider;
        private readonly ButtonStack _stack;

        public ButtonFactory(IServiceProvider provider, ButtonStack stack)
        {
            _provider = provider;
            _stack = stack;
        }

        public Button CreateButton<TButton>(string text, object? data = null)
            where TButton : Button
        {
            var button = (Button)_provider.GetService(typeof(TButton));
            button.Text = text;
            button.Data = data;

            var guid = Guid.NewGuid();
            button.CallbackData = guid.ToString();

            _stack.Buttons.Add(guid, button);

            return button;
        }
    }
}
