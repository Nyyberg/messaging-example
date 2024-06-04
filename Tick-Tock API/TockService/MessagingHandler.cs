
using EasyNetQ;
using SharedMessages;

namespace TickService
{
    public class MessagingHandler : BackgroundService
    {
        private void HandleTickMessage(TickMessage message)
        {
            Console.WriteLine($"Got Tick: {message.Message}");
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            var messageClient = new MessageClient(
                RabbitHutch.CreateBus("host=rabbitmq;port=5672;virtualhost=/;username=guest;password=guest")
                );

            messageClient.Listen<TickMessage>(HandleTickMessage, "tick-message");

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
