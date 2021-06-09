using System.Text;
<<<<<<< Updated upstream
using NATS.Client;
=======
using SharedLib;
>>>>>>> Stashed changes

namespace Valuator
{
    public class NatsBroker : IMessageBroker
    {
        public void Publish(string key, string value)
        {
<<<<<<< Updated upstream
            using var connection = new ConnectionFactory().CreateConnection();
=======
            using var connection = NatsFactory.GetNatsConnection();
>>>>>>> Stashed changes
            connection.Publish(key, Encoding.UTF8.GetBytes(value));
        }
    }
}