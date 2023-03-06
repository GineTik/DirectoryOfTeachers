using DirectoryOfTeachers.Bot.Handlers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Bot
{
    internal class Program
    {
        private static List<IHandler> _handlers;

        static Program()
        {
            var dialogHandler = new DialogHandler();
            _handlers = new List<IHandler>()
            {
                new CommandHandler(dialogHandler),
                dialogHandler
            };
        }

        public static async Task Main(string[] args)
        {
            TelegramBotClient client = new TelegramBotClient("6297259263:AAGFl9aJtYf0f4m2tarQwlZBtwcJLTZTHdM");
            client.StartReceiving(Update, Error);

            var me = await client.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");

            Console.ReadKey();
        }

        private static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            foreach (var handler in _handlers)
            {
                if (handler.CanHandle(update))
                {
                    await handler.HandleAsync(botClient, update);
                    return;
                }
            }
        }

        private static async Task Error(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            await Task.Run(() =>
            {
                Console.WriteLine($"Error: {exception.Message}");
            });
        }
    }
}