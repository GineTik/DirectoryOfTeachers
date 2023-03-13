using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Framework.Buttons
{
    public class Button : InlineKeyboardButton
    {
        public object? Data { get; set; }

        public Button() : base("")
        { }

        public virtual async Task OnClick(ButtonParameters parameters) { }
    }
}
