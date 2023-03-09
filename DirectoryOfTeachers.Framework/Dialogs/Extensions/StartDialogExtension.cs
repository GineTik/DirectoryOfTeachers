using DirectoryOfTeachers.Framework.Commands;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Framework.Dialogs.Extensions
{
    public static class StartDialogExtension
    {
        public static async Task StartDialogAsync<TDialog>(this DialogStack stack, CommandParameters parameters)
            where TDialog : Dialog
        {
            if (stack == null)
                throw new InvalidOperationException("DialogStack is null");

            await stack.StartDialogAsync(typeof(TDialog), new DialogParameters
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
            });
        }
    }
}
