using System;
using System.Reflection;
using RabbitMQ.Client;

namespace LoanShark.Messaging
{
    public class OctoBus : IMessageBus
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly IConnection _connection;
        private readonly IModel _model;

        public OctoBus()
        {
            var configuration = OctoBusConfiguration.Get();

            _connectionFactory = new ConnectionFactory
            {
                HostName = configuration.Host,
                UserName = configuration.UserName,
                Password = configuration.Password
            };

            _connection = _connectionFactory.CreateConnection();
        }

        public void Publish<T>(T message)
        {
            var messageType = message.GetType();
            var messageName = messageType.Namespace + "." + messageType.Name;

            var exchangeName = String.Format("{0}:{1}", messageName, messageType.Assembly.GetName().Name);
            var queueName = String.Format("{0}.{1}", messageName, Assembly.GetExecutingAssembly().GetName().Name);

            var model = _connection.CreateModel();

            model.ExchangeDeclare(exchangeName, ExchangeTypes.Topic);
            model.QueueDeclare(queueName, true, false, false, null);
            model.QueueBind(queueName, exchangeName, String.Empty);
        }

        private static class ExchangeTypes
        {
            public const string Fanout = "fanout";
            public const string Topic = "topic";
        }
    }
}
