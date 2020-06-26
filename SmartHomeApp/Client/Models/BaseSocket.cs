using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHomeApp.Client.Models
{
    public abstract class BaseSocket : IWirelessSocket
    {
        public string Name { get; set; }
        public string[] Labels { get; set; }
        public State State { get; set; } = State.OFF;
        public abstract int Unit { get; set; }
        public abstract int Id { get; set; }
        public abstract string Protocol { get; }
    }
}
