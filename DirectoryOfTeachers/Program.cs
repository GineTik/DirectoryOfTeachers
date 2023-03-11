using DirectoryOfTeachers.Bot.Configures;
using DirectoryOfTeachers.Framework.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DirectoryOfTeachers.Bot
{
    internal class Program
    {
        private static ServiceProvider _serviceProvider;

        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            new DIConfigure().Configure(services);
            _serviceProvider = services.BuildServiceProvider();

            TelegramBotClient client = new TelegramBotClient(ConfigurationManager.AppSettings["TelegramApi"]);
            client.StartReceiving(Update, Error);

            var me = await client.GetMeAsync();
            Console.WriteLine($"Start listening for @{me.Username}");

            Console.ReadKey();
        }

        private static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var handlers = _serviceProvider.GetServices<IHandler>();
            foreach (var handler in handlers)
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
                Console.WriteLine($"Error: {exception.Message}, \nHelpLink: {exception.HelpLink}, \nSource: {exception.Source}, \nStackTrace: {exception.StackTrace}");
            });
        }
    }
}