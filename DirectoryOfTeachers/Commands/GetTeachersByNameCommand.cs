using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Presenters;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Attributes;
using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Commands
{
    [Command("/get_teachers_by_name")]
    [RequiredParameters(1, Message = "Ви забули уточнити ім'я :)")]
    public class GetTeachersByNameCommand : Command
    {
        private readonly ITeacherService _service;
        private readonly IPresenter<IEnumerable<TeacherShortDTO>> _presenter;

        public GetTeachersByNameCommand(ITeacherService service, IPresenter<IEnumerable<TeacherShortDTO>> presenter)
        {
            _service = service;
            _presenter = presenter;
        }

        public override async Task InvokeAsync(CommandParameters parameters)
        {
            var name = parameters.QueryParameters[0];
            await parameters.SendTextAnswerAsync("Шукаю: " + name);

            var teachers = await _service.GetTeachersByContainsNameAsync(name);
            await _presenter.PresentAsync(parameters, teachers);
        }
    }
}
