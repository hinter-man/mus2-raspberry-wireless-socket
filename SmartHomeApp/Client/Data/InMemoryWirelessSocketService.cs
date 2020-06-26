using SmartHomeApp.Client.Data.Interfaces;
using SmartHomeApp.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartHomeApp.Client.Data
{
    public class InMemoryWirelessSocketService : IWirelessSocketService
    {
        private static List<BaseSocket> _wirelessSockets = new List<BaseSocket>
        {
            new IntertechnoWirelessSocket
            {
                Name = "Wohnwand",
                Labels = new string [] { "playstation", "tv"},
                Id = 0,
                Unit = 0,
            },
            new IntertechnoWirelessSocket
            {
                Name = "Schlafzimmer",
                Labels = new string [] { "tv", "lampe"},
                Unit = 0,
                Id = 1,
                State = State.OFF
            },
            new IntertechnoWirelessSocket
            {
                Name = "Küche",
                Labels = new string [] { "mikrowelle", "kaffeemaschine", "wasserkocher" },
                Unit = 0,
                Id = 2,
            }
        };

        private string _basePilightQueryParams = "/send?protocol={0}&unit={1}&id={2}&{3}=1";

        private readonly HttpClient _httpClient;

        public InMemoryWirelessSocketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public BaseSocket AddWirelessSocket(BaseSocket wirelessSocket)
        {
            _wirelessSockets.Add(wirelessSocket);
            return wirelessSocket;
        }

        public void DeleteWirelessSocket(string name)
        {
            var wirelessSocket = _wirelessSockets.First(n => n.Name == name);
            _wirelessSockets.RemoveAt(_wirelessSockets.IndexOf(wirelessSocket));

        }

        public BaseSocket GetWirelessSocketByName(string name)
        {
            return _wirelessSockets.First(n => n.Name == name);
        }

        public List<BaseSocket> GetWirelessSockets()
        {
            return _wirelessSockets;
        }

        public async Task<bool> ToggleWirelessSocketState(BaseSocket wirelessSocket)
        {
            try
            {
                var requestParams = SetPilightQueryParams(wirelessSocket);
                var request = new HttpRequestMessage(HttpMethod.Get, requestParams);
                var response = await _httpClient.SendAsync(request);

            }
            catch (Exception e)
            {
                // nothing to do here
            }
            return true;
        }

        public BaseSocket UpdateWirelessSocket(string name, BaseSocket wirelessSocket)
        {
            if (wirelessSocket.Name != name)
            {
                throw new ArgumentException("name does not name of wireless socket");
            }

            var socket = _wirelessSockets.First(n => n.Name == name);
            socket = wirelessSocket;

            return socket;
        }

        private string SetPilightQueryParams(BaseSocket baseSocket)
        {
            return string.Format(
                _basePilightQueryParams,
                baseSocket.Protocol,
                baseSocket.Unit,
                baseSocket.Id,
                baseSocket.State == State.ON ? "on" : "off");
        }
    }
}
