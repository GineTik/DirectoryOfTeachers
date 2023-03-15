using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Bot.Dialogs.DialogSteps.FindTeacherDialog;
using DirectoryOfTeachers.Bot.Presenters;
using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations
{
    public class FindTeacherDialog : Dialog
    {
        private readonly ITeacherService _service;
        private readonly IPresenter<IEnumerable<TeacherShortDTO>> _presenter;

        public FindTeacherDialog(ITeacherService service, IPresenter<IEnumerable<TeacherShortDTO>> presenter)
        {
            _service = service;
            _presenter = presenter;

            SetNextStep(typeof(GetNameDialogStep));
        }

        public override async Task StepsEndedCallback(DialogParameters parameters)
        {
            TeacherShortDTO dto = new()
            {
                Name = DialogContext.GetMessage<GetNameDialogStep>().Text,
                EducationalInstitution = DialogContext.GetMessage<GetEducationInstitutionDialogStep>().Text,
            };
            await parameters.SendTextAnswerAsync($"Шукаю: Ім'я {dto.Name}, навчальний заклад {dto.EducationalInstitution}");

            var teachers = await _service.GetSimilarTeachersAsync(dto);
            await _presenter.PresentAsync(parameters, teachers);
        }
    }
}
