using Telegram.Bot.Types;
using Telegram.Bot;

namespace DirectoryOfTeachers.Framework.Parameters
{
    public class BaseParameters
    {
        public ITelegramBotClient BotClient { get; set; }
        public Update Update { get; set; }
        public long ChatId => Update.Message?.Chat?.Id ?? -1;
        public Message? Message => Update.Message;

        public async Task SendTextAnswerAsync(string text)
        {
            ArgumentNullException.ThrowIfNull(BotClient);
            await BotClient.SendTextMessageAsync(ChatId, text);
        }
    }
}
