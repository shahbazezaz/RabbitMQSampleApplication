using ConnectionHelper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace RabbitMQDemo.Shared
{
    public class RabbitMQConnection : IConnectionHelper, IDisposable
    {
        private readonly ConnectionFactory _factory;
        private IConnection? _connection;

        public RabbitMQConnection()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public async Task<IConnection> CreateConnectionAsync()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = await Task.Run(() => _factory.CreateConnectionAsync());
            }
            return _connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}