using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Framework.Attributes
{
    public class RequiredParametersAttribute : CanInvokeCommandAttribute
    {
        public uint Count { get; set; }

        public RequiredParametersAttribute(uint count)
        {
            Count = count;
            Message = $"Ця команда потребує {Count} параметрів";
        }

        public override bool CanInvoke(Update update)
        {
            var queryParameters = update.Message.Text.Split(' ').ToList();
            queryParameters.RemoveAt(0);

            return queryParameters.Count >= Count;
        }
    }
}
