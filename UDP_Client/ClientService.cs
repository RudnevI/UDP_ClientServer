using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UDP_Client
{
    internal class ClientService : IDisposable
    {
        public int Port { get; set; } = 5001;

        public string CurrentIpAddress => _currentIpAddress;

        private readonly UdpClient _server;
        public IPEndPoint _remoteEndPoint = null;
        private readonly string _currentIpAddress = @"192.168.0.104";
   

        public ClientService(
            
      
          
            int userLimit = 100

            )
        {

            
            _remoteEndPoint = new IPEndPoint(IPAddress.Parse(_currentIpAddress), Port);
            _server = new UdpClient();
            


        }


        public void Receive()
        {
            while (true)
            {
                
                
                Console.Write("--> ");
                byte[] buffer = Encoding.UTF8.GetBytes(Console.ReadLine());

                SafeSend(buffer);
                SafeReceive(ref buffer);
                Console.WriteLine(Encoding.UTF8.GetString(buffer));
            }


        }

        public void SendEnMasse()
        {
           IEnumerable<Thread> threads =  Enumerable.Range(0, 100).Select(x => new Thread(() => {

                string serialized = JsonConvert.SerializeObject(new User().Random());
                byte[] buffer = Encoding.UTF8.GetBytes(serialized);
                SafeSend(buffer);
            }));

           foreach(Thread thread in threads)
            {
                thread.Start();
            }
           
        }
        public void Dispose()
        {
            _server.Close();
            GC.SuppressFinalize(this);
        }

        private async Task SafeSendAsync(byte[] buffer)
        {
            try
            {

                await _server.SendAsync(buffer, buffer.Length, _remoteEndPoint);

            }
            catch(SocketException)
            {
                DisplayNetworkErrorMessage();
            }
        }

        private void SafeSend(byte[] buffer)
        {
            try
            {
                _server.Send(buffer, buffer.Length, _remoteEndPoint);
            }
            catch (SocketException)
            {
                DisplayNetworkErrorMessage();
            }
        }
        private void DisplayNetworkErrorMessage()
        {
            Console.WriteLine("Failed to send due to network problems");
        }

        private void SafeReceive(ref byte[] buffer)
        {
            try
            {
                buffer = _server.Receive(ref _remoteEndPoint);
            }
            catch(SocketException)
            {
                DisplayNetworkErrorMessage();
            }
        }

    }
}
