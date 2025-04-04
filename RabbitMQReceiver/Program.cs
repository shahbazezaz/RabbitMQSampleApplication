using RabbitMQReceiver;
using RabbitMQDemo.Shared;

public class Program
{
    public static async Task Main()
    {
        var connectionHelper = new RabbitMQConnection();
        var receiver = new Receiver(connectionHelper);

        await receiver.ReceiveMessagesAsync("testQueue");
        Console.ReadLine();
    }
}
