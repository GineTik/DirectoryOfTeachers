using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Presenters;
using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Buttons
{
    public class DisplayTeacherCharacteristicsButton : Button
    {
        private readonly ITeacherCharacteristicService _service;
        private readonly IPresenter<IEnumerable<TeacherCharacteristicInfoDTO>> _presenter;

        public DisplayTeacherCharacteristicsButton(ITeacherCharacteristicService service, IPresenter<IEnumerable<TeacherCharacteristicInfoDTO>> presenter)
        {
            _service = service;
            _presenter = presenter;
        }

        public override async Task OnClick(ButtonParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(Data);
            var teacherId = (int)Data;

            var characteristics = await _service.GetTeacherCharacteristicsAsync(teacherId);
            await _presenter.PresentAsync(parameters, characteristics);
        }
    }
}
