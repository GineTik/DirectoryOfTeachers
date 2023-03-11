using DirectoryOfTeachers.Core.DTOs.Teacher;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;

namespace DirectoryOfTeachers.Bot.Dialogs.DialogSteps.AddTeacherDialog
{
    public class NameDialogStep : DialogStep
    {
        public override async Task InvokeAsync(DialogStepParameters parameters)
        {
            await parameters.BotClient.SendTextMessageAsync(parameters.ChatId, "Введіть ім'я вчителя");
            NextStep<EducationInstitusionDialogStep>();
        }

        public override async Task TakeResultAsync(DialogStepParameters parameters)
        {
            var model = parameters.DialogContext.GetModel<AddTeacherDTO>();
            model.Name = parameters.Message.Text;
        }
    }
}
