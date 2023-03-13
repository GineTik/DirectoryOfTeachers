using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/get_teachers_by_education_institution")]
    public class GetTeachersByEducationInstitutionCommand : Command
    {
        private readonly ITeacherService _service;

        public GetTeachersByEducationInstitutionCommand(ITeacherService service)
        {
            _service = service;
        }

        public override async Task InvokeAsync(CommandParameters parameters)
        {
            if (parameters.QueryParameters.Count == 0)
            {
                await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, "Ви забули уточнити навчильний заклад :)");
                return;
            }

            var ei = parameters.QueryParameters[0];

            var teachers = await _service.GetTeachersByContainsEducationalInstitutionAsync(ei);

            var result = "Нічого не знайдено";
            if (teachers.Count() != 0)
                result = String.Join("\n", teachers.Select(t => t.Name + " " + t.EducationalInstitution));

            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, result);
        }
    }
}
