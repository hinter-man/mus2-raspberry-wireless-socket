using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeApp.Client.Models
{
    public interface IWirelessSocket
    {
        public string Protocol { get; }
        public int Unit { get; set; }
        public int Id { get; set; }
    }
}
