using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Dialogs.DialogSteps.AddTeacherDialog;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations
{
    public class AddTeacherDialog : Dialog
    {
        private readonly ITeacherService _service;

        public AddTeacherDialog(ITeacherService service)
        {
            SetNextStep(typeof(NameDialogStep));
            _service = service;
            DialogContext.AddModel<AddTeacherDTO>();
        }

        public override async Task StepsEndedCallback(DialogParameters parameters)
        {
            var dto = DialogContext.GetModel<AddTeacherDTO>();

            bool result = await _service.AddTeacherAsync(dto);
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, $@"Вчителя {(result ? "додано" : "не додано (сталась якась помилка)")}");
        }
    }
}
