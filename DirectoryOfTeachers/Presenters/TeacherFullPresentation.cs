using DirectoryOfTeachers.Bot.Buttons;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Factories.Interfaces;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Bot.Presenters
{
    public class TeacherFullPresentation : IPresenter<TeacherFullDTO>
    {
        private readonly IButtonFactory _buttonFactory;

        public TeacherFullPresentation(IButtonFactory buttonFactory)
        {
            _buttonFactory = buttonFactory;
        }

        public async Task PresentAsync(long chatId, ITelegramBotClient bot, TeacherFullDTO model)
        {
            var keyboard = new InlineKeyboardMarkup(
                _buttonFactory.CreateButton<AddCharacteristicButton>("Додати нову характеристику", model.Id));

            ArgumentNullException.ThrowIfNull(model);

            var characteristics = String.Join("\n", model.Characteristics.Select(c => c.Name + " " + c.LikeCount));

            await bot.SendTextMessageAsync(chatId, $"{model.Name} {model.EducationalInstitution}\n\n{characteristics}", replyMarkup: keyboard);
        }
    }
}
