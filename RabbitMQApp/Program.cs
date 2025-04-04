using RabbitMQDemo.Shared;

public class Program
{
    public static async Task Main()
    {
        var connectionHelper = new RabbitMQConnection();
        var sender = new Sender(connectionHelper);

        await sender.SendMessageAsync("testQueue", "Hello");
        await sender.SendMessageAsync("testQueue", "Good morning");
        await sender.SendMessageAsync("testQueue", "How are you?");
    }
}