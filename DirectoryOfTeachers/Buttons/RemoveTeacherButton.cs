using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Buttons
{
    public class RemoveTeacherButton : Button
    {
        private readonly ITeacherService _service;

        public RemoveTeacherButton(ITeacherService service)
        {
            _service = service;
        }

        public override async Task OnClick(ButtonParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(Data);
            var id = (int)Data;

            var result = await _service.RemoveTeacherAsync(id);
            await parameters.SendTextAnswerAsync($"Інформацію про викладача {(result ? "успішно видалено" : "не вдалось видалити")}");
        }
    }
}
