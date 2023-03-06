using Telegram.Bot.Types;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Parameters
{
    public class BaseParameters
    {
        public ITelegramBotClient BotClient { get; set; }
        public Update Update { get; set; }
        public long ChatId => Update.Message.Chat.Id;
        public Message Message => Update.Message;
    }
}
