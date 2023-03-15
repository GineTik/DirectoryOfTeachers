using DirectoryOfTeachers.Bot.Buttons;
using DirectoryOfTeachers.Core.DTOs.TeacherCharacteristics;
using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Factories.Interfaces;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace DirectoryOfTeachers.Bot.Presenters
{
    public class CharacteristicsVotePresenters : IPresenter<IEnumerable<TeacherCharacteristicInfoDTO>>
    {
        private readonly IButtonFactory _buttonFactory;

        public CharacteristicsVotePresenters(IButtonFactory buttonFactory)
        {
            _buttonFactory = buttonFactory;
        }

        public async Task PresentAsync(BaseParameters parameters, IEnumerable<TeacherCharacteristicInfoDTO> models)
        {
            ArgumentNullException.ThrowIfNull(models);

            var buttons = new List<Button[]>();
            foreach (var model in models)
                buttons.Add(new[] { _buttonFactory.CreateButton<CharacteristicVoteButton>(model.Name, model.Id) });

            var keyboard = new InlineKeyboardMarkup(buttons);

            await parameters.BotClient.EditMessageTextAsync(parameters.ChatId, parameters.Message.MessageId, parameters.Message.Text, replyMarkup: keyboard);
        }
    }
}
