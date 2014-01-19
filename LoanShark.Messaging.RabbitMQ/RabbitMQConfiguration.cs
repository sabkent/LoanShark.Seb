using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Messaging.RabbitMQ
{
    public class RabbitMQConfiguration : ConfigurationSection
    {
        [ConfigurationProperty(PropertyNames.Host)]
        public string Host
        {
            get { return base[PropertyNames.Host] as string; }
        }


        private static class PropertyNames
        {
            public const string Host = "host";
        }
    }
}
