using DirectoryOfTeachers.Framework.Buttons;
using DirectoryOfTeachers.Framework.Parameters;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Framework.Handlers
{
    public class ButtonHandler : IHandler
    {
        private readonly ButtonStack _stack;

        public ButtonHandler(ButtonStack stack)
        {
            _stack = stack;
        }

        public bool CanHandle(Update update)
        {
            if (update.CallbackQuery == null)
                return false;

            string guid = update?.CallbackQuery?.Data;

            if (guid == null)
                return false;

            return true;
        }

        public async Task HandleAsync(ITelegramBotClient botClient, Update update)
        {
            string guid = update?.CallbackQuery?.Data;

            if (_stack.Buttons.ContainsKey(Guid.Parse(guid)) == false)
            {
                await DeleteButtonAsync(botClient, update);
                return;
            }

            var button = _stack.Buttons[Guid.Parse(guid)];

            if (button == null)
                throw new InvalidOperationException("button don't added in services or don't inherit Button");

            await button.OnClick(new ButtonParameters
            {
                BotClient = botClient,
                Update = update,
            });
        }

        private async Task DeleteButtonAsync(ITelegramBotClient botClient, Update update)
        {
            string guid = update?.CallbackQuery?.Data;
            var callbackId = update.CallbackQuery.Id;
            var keyboard = update.CallbackQuery.Message.ReplyMarkup.InlineKeyboard.ElementAt(0)
                .Where(b => b.CallbackData != guid).ToArray();

            await botClient.EditMessageReplyMarkupAsync(update.CallbackQuery.Message.Chat.Id, update.CallbackQuery.Message.MessageId, keyboard);
            await botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "Ця кнопка вже не працює");
        }
    }
}
