using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Presenters
{
    public interface IPresenter
    {
        Task PresentAsync(long chatId, ITelegramBotClient bot);
    }

    public interface IPresenter<TModel>
    {
        Task PresentAsync(long chatId, ITelegramBotClient bot, TModel model);
    }
}
