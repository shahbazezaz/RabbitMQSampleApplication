using ConnectionHelper;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQReceiver
{
    public class Receiver
    {
        private readonly IConnectionHelper _connectionHelper;

        public Receiver(IConnectionHelper connectionHelper)
        {
            _connectionHelper = connectionHelper;
        }

        public async Task ReceiveMessagesAsync(string queue)
        {
            var connection = await _connectionHelper.CreateConnectionAsync();
            await using var channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            var consumer = new AsyncEventingBasicConsumer(channel);

            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[x] Received: {message}");
                await Task.CompletedTask;
            };

            await channel.BasicConsumeAsync(queue, autoAck: true, consumerTag: "", noLocal: false, exclusive: false, arguments: null, consumer: consumer);
        }
    }
}
