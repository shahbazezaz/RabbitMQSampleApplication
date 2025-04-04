using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionHelper
{
    public interface IConnectionHelper
    {
        Task<IConnection> CreateConnectionAsync();
    }
}
