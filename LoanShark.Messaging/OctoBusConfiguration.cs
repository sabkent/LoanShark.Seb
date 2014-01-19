using System.Configuration;

namespace LoanShark.Messaging
{
    public class OctoBusConfiguration : ConfigurationSection
    {
        public static OctoBusConfiguration Get()
        {
            return ConfigurationManager.GetSection("octobus") as OctoBusConfiguration;
        }

        [ConfigurationProperty(PropertyNames.Host)]
        public string Host
        {
            get { return base[PropertyNames.Host] as string; }
            set { base[PropertyNames.Host] = value; }
        }

        [ConfigurationProperty(PropertyNames.UserName)]
        public string UserName
        {
            get { return base[PropertyNames.UserName] as string; }
            set { base[PropertyNames.UserName] = value; }
        }


        [ConfigurationProperty(PropertyNames.Password)]
        public string Password
        {
            get { return base[PropertyNames.Password] as string; }
            set { base[PropertyNames.Password] = value; }
        }

        private static class PropertyNames
        {
            public const string Host = "host";
            public const string UserName = "userName";
            public const string Password = "password";
        }
    }
}
