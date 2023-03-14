using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Framework.Buttons
{
    public abstract class Button : InlineKeyboardButton
    {
        public object? Data { get; set; }

        public Button() : base("")
        { }

        public abstract Task OnClick(ButtonParameters parameters);
    }
}
