using System.Diagnostics;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client.Events;

namespace LoanShark.Messaging.OctoBus
{
    class RabbitMqMessageChannel : IMessageChannel
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;
        private string _commandExchange = "LoanShark.Commands";

        private IConnection _serverConnection;

        public EventHandler<Message> OnMessageReceived { get; set; }

        public RabbitMqMessageChannel()
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
            //Task.Run(() => RunServer());

            //Task.Factory.StartNew(()=>RunServer(), TaskCreationOptions.LongRunning);
        }

        public void Send(byte[] data)
        {
            var properties = _model.CreateBasicProperties();
            properties.SetPersistent(true);

            _model.BasicPublish(_commandExchange, "", properties, data);
        }

        public void Dispose()
        {
            SafeDispose(_model);
            SafeDispose(_connection);
            //_model.Dispose();
        }
        /// <summary>
        /// http://fygt.wordpress.com/2013/06/08/c-sharp_event_based_queue/
        /// </summary>
        protected Task RunServer()
        {
            Debug.WriteLine("Run Server");
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //channel.QueueDeclare("LoanShark.Messaging", true, false, false, null);

                    var consumer = new QueueingBasicConsumer(channel);
                    channel.BasicConsume("LoanShark.Messaging", false, consumer);

                    while (true)
                    {
                        var basicDeliveryArgs = (BasicDeliverEventArgs)consumer.Queue.Dequeue();

                        var body = basicDeliveryArgs.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Debug.WriteLine("Message: " + message);
                        channel.BasicAck(basicDeliveryArgs.DeliveryTag, false);
                    }
                }
            }
        }

        private Action<IDisposable> SafeDispose = disposable =>
        {
            try
            {
                disposable.Dispose();
            }
            catch
            {
            }
        };

        
    }

    
}
