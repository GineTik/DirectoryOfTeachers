using Telegram.Bot;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public abstract class CanInvokeCommandAttribute : Attribute
    {
        public string Message { get; set; }
        public abstract bool CanInvoke(Update update);
    }
}
