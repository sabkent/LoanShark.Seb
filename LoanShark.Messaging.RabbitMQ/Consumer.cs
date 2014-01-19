using Autofac;
using LoanShark.Application.Messaging;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LoanShark.Messaging.RabbitMQ
{
    public class Consumer : IMessageConsumer
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;
        private Subscription _subscription;
        private bool _enabled = true;
        private string _commandExchange = "LoanShark.Commands";

        private delegate void ConsumeDelegate();

        private IComponentContext _componentContext;

        public Consumer(IComponentContext componentContext)
        {
            _componentContext = componentContext;

            _connectionFactory = new ConnectionFactory
            {
                HostName = "192.168.220.30",
                UserName = "guest",
                Password = "guest"
            };

            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();            
        }

        public void Start()
        {
            var applyForLoanQueue = "LoanShark.Core.Origination.Commands.ApplyForLoan";
            _subscription = new Subscription(_model, applyForLoanQueue, false);

            var consumer = new ConsumeDelegate(Poll);
            consumer.Invoke();
        }

        private void Poll()
        {
            while (_enabled)
            {
                var deliveryArgs = _subscription.Next();

                var data = deliveryArgs.Body;

                var command = Deserialize(data);

                var handlerType = typeof (IHandleCommand<>).MakeGenericType(new[] {command.GetType()});

                dynamic handler = _componentContext.Resolve(handlerType); //HACK
                
                if (handler != null)
                {
                    handler.Handle(command); //dynamic HACK
                    _subscription.Ack(deliveryArgs);
                }
            }
        }

        private void Process<T>(IHandleCommand<T> handler, T command)
        {
            
        }

        private object Deserialize(byte[] data)
        {
            var bin = new BinaryFormatter();
            using (var ms = new MemoryStream(data))
                return bin.Deserialize(ms) ;
        }
    }
}
