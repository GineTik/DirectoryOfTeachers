using DirectoryOfTeachers.Bot.Dialogs.DialogsImplementations;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Dialogs;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Buttons
{
    public class AddCharacteristicButton : Button
    {
        private readonly DialogStack _stack;
        
        public AddCharacteristicButton(DialogStack stack)
        {
            _stack = stack;
        }

        public override async Task OnClick(ButtonParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(Data);

            var teacherId = (int)Data;
            await _stack.StartDialogAsync<AddCharacteristicDialog, ButtonParameters>(parameters, teacherId);
        }
    }
}
