
using EasyNetQ;
using SharedMessages;

namespace TickService
{
    public class MessagingHandler : BackgroundService
    {
        private void HandleTockMessage(TockMessage message)
        {
            Console.WriteLine($"Got Tock: {message.Message}");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var messageClient = new MessageClient(
                RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualhost=/;username=guest;password=guest")
                );

            messageClient.Listen<TockMessage>(HandleTockMessage, "tock-message");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
