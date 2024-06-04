using EasyNetQ;

namespace TickService
{
    public class MessageClient
    {
        private readonly IBus _bus;
         public MessageClient(IBus bus)
         {
             _bus = bus;
         }

         public void Send<T>(T message, string topic)
         {
            _bus.PubSub.Publish(message, topic);
         }
         
         public void Listen<T>(Action<T> messageHandler, string topic) 
         {
            _bus.PubSub.Subscribe(topic, messageHandler);
         }
    }
}
