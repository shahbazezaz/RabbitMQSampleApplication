# RabbitMQ .NET 8 Sample Application

This solution demonstrates how to use RabbitMQ with .NET 8, leveraging the latest RabbitMQ.Client version 7.1.2. It includes an asynchronous connection helper, a sender to publish messages, and a receiver to consume messages.

## Project Structure

```
D:/sample/rabbitmq/
│-- ConnectionHelper/          # Manages RabbitMQ connections asynchronously
│-- RabbitMQApp/               # Main application entry point
│-- RabbitMQReceiver/          # Handles message consumption
│-- RabbitMQSampleApplication/ # Sends messages to the queue
```

## Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [RabbitMQ Server](https://www.rabbitmq.com/download.html)
- Ensure RabbitMQ is running locally (default: `localhost:5672`)
- Install the latest RabbitMQ.Client library:
  ```sh
  dotnet add package RabbitMQ.Client --version 7.1.2
  ```

## Installation & Setup
1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/RabbitMQSampleApplication.git
   cd RabbitMQSampleApplication
   ```
2. Restore dependencies:
   ```sh
   dotnet restore
   ```
3. Run the receiver to listen for messages:
   ```sh
   dotnet run --project RabbitMQReceiver
   ```
4. In a new terminal, send messages:
   ```sh
   dotnet run --project RabbitMQSampleApplication
   ```

## Usage
- The sender (`RabbitMQSampleApplication`) publishes messages to the queue.
- The receiver (`RabbitMQReceiver`) listens and processes messages.

## Code Overview
- **ConnectionHelper**: Establishes an asynchronous connection using `CreateConnectionAsync()`.
- **Sender**: Publishes messages to a queue.
- **Receiver**: Listens for messages and processes them asynchronously.

## Troubleshooting
- Ensure RabbitMQ is running (`rabbitmq-server` command).
- Verify your connection settings match RabbitMQ’s configuration.
- Check logs for errors (`dotnet run` output).

## License
This project is open-source and available under the [MIT License](LICENSE).

---
**Author:** Shahbaz Ezaz Ansari  
**GitHub:** [Shahbaz Ezaz Ansari](https://github.com/shahbazezaz/)

