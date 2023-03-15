using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Presenters;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/get_teachers_by_education_institution")]
    [RequiredParametersAttribute(1, Message = "Ви забули уточнити навчильний заклад :)")]
    public class GetTeachersByEducationInstitutionCommand : Command
    {
        private readonly ITeacherService _service;
        private readonly IPresenter<IEnumerable<TeacherShortDTO>> _presenter;

        public GetTeachersByEducationInstitutionCommand(ITeacherService service, IPresenter<IEnumerable<TeacherShortDTO>> presenter)
        {
            _service = service;
            _presenter = presenter;
        }

        public override async Task InvokeAsync(CommandParameters parameters)
        {
            var ei = parameters.QueryParameters[0];
            await parameters.SendTextAnswerAsync("Шукаю: " + ei);

            var teachers = await _service.GetTeachersByContainsEducationalInstitutionAsync(ei);
            await _presenter.PresentAsync(parameters, teachers);
        }
    }
}
