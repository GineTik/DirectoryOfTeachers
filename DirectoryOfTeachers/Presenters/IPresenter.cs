using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Presenters
{
    public interface IPresenter
    {
        Task PresentAsync(BaseParameters parameters, ITelegramBotClient bot);
    }

    public interface IPresenter<TModel>
    {
        Task PresentAsync(BaseParameters parameters, TModel model);
    }
}
