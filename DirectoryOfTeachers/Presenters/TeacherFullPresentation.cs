using DirectoryOfTeachers.Bot.Buttons;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Factories.Interfaces;
using DirectoryOfTeachers.Framework.Parameters;
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

        public async Task PresentAsync(BaseParameters parameters, TeacherFullDTO model)
        {
            ArgumentNullException.ThrowIfNull(model);

            var buttons = new List<Button>();

            if (model.Characteristics.Count() > 0)
                buttons.Add(_buttonFactory.CreateButton<DisplayTeacherCharacteristicsButton>("Проголосувати", model.Id));

            buttons.Add(_buttonFactory.CreateButton<RemoveTeacherButton>("Видалити вчителя", model.Id));
            buttons.Add(_buttonFactory.CreateButton<AddCharacteristicButton>("Додати нову характеристику", model.Id));

            var keyboard = new InlineKeyboardMarkup(buttons);

            var characteristics = String.Join("\n", model.Characteristics.Select(c => c.Name + " " + c.LikeCount));

            await parameters.SendTextAnswerAsync($"{model.Name} {model.EducationalInstitution}\n\n{characteristics}", replyMarkup: keyboard);
        }
    }
}
