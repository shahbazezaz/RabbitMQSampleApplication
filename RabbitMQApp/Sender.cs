using ConnectionHelper;
using RabbitMQ.Client;
using System.Text;

public class Sender
{
    private readonly IConnectionHelper _connectionHelper;

    public Sender(IConnectionHelper connectionHelper)
    {
        _connectionHelper = connectionHelper;
    }

    public async Task SendMessageAsync(string queue, string message)
    {
        var connection = await _connectionHelper.CreateConnectionAsync();
        await using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync("", queue, body);
        Console.WriteLine($"[x] Sent: {message}");
    }

}