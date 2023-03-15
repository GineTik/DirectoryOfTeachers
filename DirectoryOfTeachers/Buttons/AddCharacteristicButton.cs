using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Buttons
{
    public class AddCharacteristicButton : Button
    {
        private readonly DialogStack _stack;
        private readonly ITeacherService _service;

        public AddCharacteristicButton(DialogStack stack, ITeacherService service)
        {
            _stack = stack;
            _service = service;
        }

        public override async Task OnClick(ButtonParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(Data);

            var teacherId = (int)Data;

            if (await _service.IsTeacherExistsAsync(teacherId) == false)
                await parameters.SendTextAnswerAsync("Такого вчителя вже не існує");
            else
                await _stack.StartDialogAsync<AddCharacteristicDialog, ButtonParameters>(parameters, teacherId);
        }
    }
}
