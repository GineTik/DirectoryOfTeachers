using DirectoryOfTeachers.Bot.Buttons;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Factories.Interfaces;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Bot.Presenters
{
    public class TeachersShortPresenter : IPresenter<IEnumerable<TeacherShortDTO>>
    {
        private readonly IButtonFactory _buttonFactory;

        public TeachersShortPresenter(IButtonFactory buttonFactory)
        {
            _buttonFactory = buttonFactory;
        }

        public async Task PresentAsync(BaseParameters parameters, IEnumerable<TeacherShortDTO> models)
        {
            if (models == null)
                throw new ArgumentNullException(nameof(models));

            string result = models.Count() == 0 ? "Нічого не знайдено" : "Ось що вдалось знайти";

            List<Button[]> buttons = new List<Button[]>();
            foreach (var teacher in models)
                buttons.Add(new[] {
                    _buttonFactory.CreateButton<DisplayFullTeacherButton>($"{teacher.Name} {teacher.EducationalInstitution}", teacher) });

            var keyboard = new InlineKeyboardMarkup(buttons);
            await parameters.SendTextAnswerAsync(result, replyMarkup: keyboard);
        }
    }
}
