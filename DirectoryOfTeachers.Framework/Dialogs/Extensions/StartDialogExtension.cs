using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Framework.Dialogs.Extensions
{
    public static class StartDialogExtension
    {
        public static async Task StartDialogAsync<TDialog, TParameter>(this DialogStack stack, TParameter parameters, object? data = null)
            where TDialog : Dialog
            where TParameter : BaseParameters
        {
            if (stack == null)
                throw new InvalidOperationException("DialogStack is null");

            await stack.StartDialogAsync(typeof(TDialog), new DialogParameters
            {
                BotClient = parameters.BotClient,
                Update = parameters.Update,
            }, data);
        }
    }
}
