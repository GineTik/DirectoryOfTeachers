using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Buttons;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Factories.Interfaces;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/get_teachers_by_name")]
    public class GetTeachersByNameCommand : Command
    {
        private readonly ITeacherService _service;
        private readonly IButtonFactory _buttonFactory;

        public GetTeachersByNameCommand(ITeacherService service, IButtonFactory buttonFactory)
        {
            _service = service;
            _buttonFactory = buttonFactory;
        }

        public override async Task InvokeAsync(CommandParameters parameters)
        {
            if (parameters.QueryParameters.Count == 0)
            {
                await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, "Ви забули уточнити ім'я :)");
                return;
            }

            var name = parameters.QueryParameters[0];
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, "Шукаю: " + name);

            var teachers = await _service.GetTeachersByContainsNameAsync(name);

            string result = teachers.Count() == 0 ? "Нічого не знайдено" : "Ось що вдалось знайти";

            List<Button[]> buttons = new List<Button[]>();

            foreach (var teacher in teachers)
                buttons.Add(new[] {
                    _buttonFactory.CreateButton<DisplayFullTeacherButton>($"{teacher.Name} {teacher.EducationalInstitution}", teacher) });

            var keyboard = new InlineKeyboardMarkup(buttons); 
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, result, replyMarkup: keyboard);
        }
    }
}
