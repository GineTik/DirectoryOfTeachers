namespace DirectoryOfTeachers.Framework.Buttons
{
    public class ButtonStack
    {
        public Dictionary<Guid, Button> Buttons { get; set; }

        public ButtonStack()
        {
            Buttons = new Dictionary<Guid, Button>();
        }
    }
}
