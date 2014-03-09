using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LoanShark.Messaging.OctoBus
{
    public class MessageBroker : IMessageBroker
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;
        private string _commandExchange = "LoanShark.Commands";

        public MessageBroker()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare("LoanShark.Messaging", true, false, false, null);

            _model.ExchangeDeclare(_commandExchange, "fanout");
            _model.QueueBind("LoanShark.Messaging", _commandExchange, "");

            using (var connection = _connectionFactory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer();
                consumer.Received += (sender, args) =>
                {
                    var body = args.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Debug.WriteLine("Message: " + message);
                };

                channel.BasicConsume("LoanShark.Messaging", true, consumer);
            }
        }
    }
}
