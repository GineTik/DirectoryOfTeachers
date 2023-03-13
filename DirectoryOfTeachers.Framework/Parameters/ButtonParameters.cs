namespace DirectoryOfTeachers.Framework.Parameters
{
    public class ButtonParameters : BaseParameters
    {
        public new long ChatId => Update.CallbackQuery?.Message?.Chat?.Id ?? -1;
    }
}
