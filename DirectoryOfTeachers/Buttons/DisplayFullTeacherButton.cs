using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Buttons
{
    public class DisplayFullTeacherButton : Button
    {
        private readonly ITeacherService _service;

        public DisplayFullTeacherButton(ITeacherService service)
        {
            _service = service;
        }

        public override async Task OnClick(ButtonParameters parameters)
        {
            if (Data == null)
                throw new ArgumentNullException(nameof(Data));

            var teacherDTO = (TeacherShortDTO)Data;
            var teacher = await _service.GetTeacher(teacherDTO);
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, $"{teacher.Name} {teacher.EducationalInstitution} {teacher.Characteristics.Count()}");
        }
    }
}
