using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Framework.Parameters
{
    public class BaseParameters
    {
        public ITelegramBotClient BotClient { get; set; }

        public Update Update { get; set; }

        public long ChatId => 
            Update.Message?.Chat?.Id ?? 
            Update.CallbackQuery?.Message?.Chat?.Id ?? 
            -1;

        public Message? Message => 
            Update.Message ?? 
            Update.CallbackQuery?.Message;

        public async Task SendTextAnswerAsync(string text, IReplyMarkup? replyMarkup = null)
        {
            ArgumentNullException.ThrowIfNull(BotClient);
            await BotClient.SendTextMessageAsync(ChatId, text, replyMarkup: replyMarkup);
        }
    }
}
