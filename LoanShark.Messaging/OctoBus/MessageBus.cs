using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Messaging.OctoBus
{
    public sealed class MessageBus : IMessageBus
    {
        private IMessageChannel _messageChannel;

        public MessageBus()
        {

            _messageChannel = GetChannel();
        }

        public void Publish<T>(T message)
        {
            throw new NotImplementedException();
        }

        public ICallback Send<T>(T message)
        {
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            _messageChannel.Send(data);

            return null;
        }


        private IMessageChannel GetChannel()
        {
            if (_messageChannel == null)
            {
                _messageChannel = new RabbitMqMessageChannel();
            }

            return _messageChannel;
        }

        private byte[] Serialize<T>(T payload)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(payload));
            
            //using (var ms = new MemoryStream())
            //{
            //    new BinaryFormatter().Serialize(ms, payload);
            //    return ms.ToArray();
            //}
        }
       
    }
}
