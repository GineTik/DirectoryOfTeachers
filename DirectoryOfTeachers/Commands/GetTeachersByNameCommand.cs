using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/get_teachers_by_name")]
    public class GetTeachersByNameCommand : Command
    {
        private readonly ITeacherService _service;

        public GetTeachersByNameCommand(ITeacherService service)
        {
            _service = service;
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

            var result = "Нічого не знайдено";
            if (teachers.Count() != 0)
                result = String.Join("\n", teachers.Select(t => t.Name + " " + t.EducationalInstitution));

            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, result);
        }
    }
}
