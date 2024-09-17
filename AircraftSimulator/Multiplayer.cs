using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AircraftSimulator
{
    public class Multiplayer
    {
        public static string Version { get; } = "1.0";
    }
    public class Server
    {
        public string IP = "localhost";
        public int Port = 1488;
        public HttpClient httpClient;
        public Socket Socket;
        public HttpClient HttpClient;
        
        public Server(string ip = "localhost", int port = 1488) 
        {
            Port = port;
            IP = ip;
            Socket = new Socket(SocketType.Seqpacket, ProtocolType.Tcp);
            HttpClient  = new HttpClient();
        }
        private byte[] StringToBytes(string s)
        {
            byte[] r = new byte[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                r[i] = (byte)s[i];
            }
            return r;
        }
        public void Connect()
        {
            Socket.Connect(IP, Port);
        }
        public async void Send(string method, string data = "")
        {
            StringContent content = new StringContent(
                    JsonSerializer.Serialize(new
                    {
                        method = method,
                        data = data
                    }),
                    Encoding.UTF8,
                    "application/json");
            using HttpResponseMessage r = await HttpClient.PostAsync($"http://{IP}:{Port}", content);
        }
        public double GetPing()
        {
            DateTime StartTime = DateTime.Now;
            Send("GetPing", "hi");
            return DateTime.Now.Subtract(StartTime).TotalMilliseconds;
        }
    }
}
