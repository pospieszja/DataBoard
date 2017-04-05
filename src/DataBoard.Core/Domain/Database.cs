using System;
using System.Text.RegularExpressions;

namespace DataBoard.Core.Domain
{
    public class Database
    {
        private static readonly Regex IPAddressRegex = new Regex("^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$");
        public Guid Id { get; private set; }
        public string IPAddress { get; private set; }
        public Engine Engine { get; private set; }

        public Database()
        {
            
        }
        
        public Database(string ipAddress)
        {
            Id = Guid.NewGuid();
            SetIPAdress(ipAddress);
        }

        public void SetIPAdress(string ipAddress)
        {
            if(!IPAddressRegex.IsMatch(ipAddress))
            {
                throw new Exception("IP address is invalid.");
            }

            if (IPAddress == ipAddress)
            {
                return;
            }

            IPAddress = ipAddress;
        }
    }

}