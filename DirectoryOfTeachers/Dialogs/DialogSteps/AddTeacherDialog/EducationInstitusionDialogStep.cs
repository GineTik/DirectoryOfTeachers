using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.AddTeacherDialog
{
    public class EducationInstitusionDialogStep : DialogStep
    {
        public override async Task InvokeAsync(DialogStepParameters parameters)
        {
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, "Введіть навчильний заклад вчителя");
        }

        public override async Task TakeResultAsync(DialogStepParameters parameters)
        {
            var model = parameters.DialogContext.GetModel<AddTeacherDTO>();
            model.EducationalInstitution = parameters.Message.Text;
        }
    }
}
