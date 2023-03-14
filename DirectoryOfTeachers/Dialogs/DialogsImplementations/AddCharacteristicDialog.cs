using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Dialogs.DialogSteps.AddCharacteristicDialog;
using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations
{
    public class AddCharacteristicDialog : Dialog
    {
        private readonly ITeacherCharacteristicService _service;

        public AddCharacteristicDialog(ITeacherCharacteristicService service)
        {
            SetNextStep(typeof(GetCharacteristicNameDialogStep));
            _service = service;
        }

        public override async Task StepsEndedCallback(DialogParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(Data);

            var addCharacteristicDTO = new AddTeacherCharacteristicDTO()
            {
                TeacherId = (int)Data,
                Name = DialogContext.GetMessage<GetCharacteristicNameDialogStep>().Text
            };

            var result = await _service.AddCharacteristicAsync(addCharacteristicDTO);
            await parameters.SendTextAnswerAsync($"Характеристика {(result ? "додана" : "чомусь не додалась")}");
        }
    }
}
