using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using System.Runtime.Serialization.Formatters.Binary;

namespace LoanShark.Messaging.RabbitMQ
{
    public class Publisher
    {
        private ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _model;
        private string _commandExchange = "LoanShark.Commands";

        public Publisher()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = "192.168.220.30",
                UserName = "guest",
                Password = "guest"
            };

            _connection = _connectionFactory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare("LoanSharkQueue1", true, false, false, null);
            _model.ExchangeDeclare("LoanShark.Exchange1", "fanout");
            _model.ExchangeDeclare(_commandExchange, "fanout");
            _model.QueueBind("LoanSharkQueue1", "LoanShark.Exchange1", "");
        }

        //public void Send(string message)
        //{
        //    var properties = _model.CreateBasicProperties();
        //    properties.SetPersistent(true);

        //    var data = Encoding.ASCII.GetBytes(message);

        //    _model.BasicPublish("LoanShark.Exchange1", String.Empty, properties, data);
        //}

        public void Send<T>(T command)
        {
            var data = Serialize(command);
            var queueName =  command.GetType().FullName;

            _model.QueueDeclare(queueName, true, false, false, null);
            _model.QueueBind(queueName, _commandExchange, queueName);

            var properties = _model.CreateBasicProperties();
            properties.SetPersistent(true);

            _model.BasicPublish(_commandExchange, queueName, properties, data);
        }

        private byte[] Serialize<T>(T payload)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, payload);
                return ms.ToArray();
            }
        }

    }
}
