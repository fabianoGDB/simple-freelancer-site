using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Services.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _connectionFactory;

        public MessageBusService()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",

            };
        }

        public void Publish(string queue, byte[] data)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                        );

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: data
                        );
                }
            }
        }
    }
}
