using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Presenters;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Factories.Interfaces;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Bot.Buttons
{
    public class DisplayFullTeacherButton : Button
    {
        private readonly ITeacherService _service;
        private readonly IPresenter<TeacherFullDTO> _presenter;

        public DisplayFullTeacherButton(ITeacherService service, IPresenter<TeacherFullDTO> presenter)
        {
            _service = service;
            _presenter = presenter;
        }

        public override async Task OnClick(ButtonParameters parameters)
        {
            if (Data == null)
                throw new ArgumentNullException(nameof(Data));

            var teacherDTO = (TeacherShortDTO)Data;
            var teacher = await _service.GetTeacherAsync(teacherDTO);

            await _presenter.PresentAsync(parameters, teacher);
        }
    }
}
