using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace LoanShark.Messaging.OctoBus
{
    /// <summary>
    /// http://www.fbombcode.com/title/Rabbit_MQ_Message_Queues
    /// </summary>
    class MessageReceiver
    {
        static readonly Semaphore semaphore = new Semaphore(2, 2);

        public event EventHandler<Message> OnMessageReceived;

        private EventingBasicConsumer _consumer;
        private IConnection _connection;
        private IModel _model;
        private bool _isStarted;
        private string _queueName;

        public MessageReceiver()
        {
            
        }

        public void Start()
        {
            if (!_isStarted)
            {
                _isStarted = true;
                _model = _connection.CreateModel();
                _consumer.Received += consumer_Received;
                IDictionary<string, object> dict = null;
                //if (MessageStringProperties != null)
                //{
                //    dict = MessageStringProperties.ToDictionary(k => k.Key, j => (object)j.Value);
                //}

                _model.QueueDeclare(_queueName, true, false, false, dict);

                _model.BasicQos(0, 1, false);
                _model.BasicConsume(_queueName, true, _consumer);
            }
        }

        void consumer_Received(IBasicConsumer sender, BasicDeliverEventArgs args)
        {
            semaphore.WaitOne();
            Task T = Task.Factory.StartNew(
                () =>
                {
                    var message = Encoding.UTF8.GetString(args.Body);
                    int dots = message.Split('.').Length - 1;
                    //var arg = new QueueMessageEventArgs(message);
                   // MessageReceived.Invoke(this, arg);
                    semaphore.Release();
                });
        }

        public void Stop()
        {
            if (_isStarted)
            {
                _isStarted = false;
                _model.Close();
                _model.Dispose();
                _consumer.Received -= consumer_Received;
            }
        }
        
    }
}
