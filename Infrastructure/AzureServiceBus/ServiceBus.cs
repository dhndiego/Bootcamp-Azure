using Azure.Messaging.ServiceBus;
using Domain.Interfaces.Interfaces;

namespace Infrastructure.AzureServiceBus
{
    public class ServiceBus : IServiceBus
    {
        private readonly ServiceBusClient _client;

        public ServiceBus(ServiceBusClient client)
        {
            _client = client;
        }

        public async Task<bool?> SendMessage(string queueName, string messageBody)
        {
            await using ServiceBusSender sender = _client.CreateSender(queueName);

            try
            {
                var message = new ServiceBusMessage(messageBody);
                await sender.SendMessageAsync(message);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }
    }
}
