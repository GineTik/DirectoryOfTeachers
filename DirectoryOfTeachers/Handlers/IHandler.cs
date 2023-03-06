using Telegram.Bot;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Bot.Handlers
{
    public interface IHandler
    {
        bool CanHandle(Update update);
        Task HandleAsync(ITelegramBotClient botClient, Update update);
    }
}
