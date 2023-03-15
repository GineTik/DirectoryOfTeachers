using DirectoryOfTeacher.BussinessLogic.Services.Interfaces;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Parameters;

namespace DirectoryOfTeachers.Bot.Buttons
{
    public class CharacteristicVoteButton : Button
    {
        private readonly ITeacherCharacteristicService _service;

        public CharacteristicVoteButton(ITeacherCharacteristicService service)
        {
            _service = service;
        }

        public override async Task OnClick(ButtonParameters parameters)
        {
            ArgumentNullException.ThrowIfNull(Data);
            var characteristicId = (int)Data;

            var result = await _service.VoteByCharacteristicAsync(characteristicId, parameters.Update.CallbackQuery.From.Id);
            await parameters.SendTextAnswerAsync($"Дякуємо за відклик: нинішній рейтинг цієї характеристики => {result}");
        }
    }
}
