using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_ClientServer
{
    class ServerService
    {
      
        private readonly UdpClient _server;
        public IPEndPoint _remoteEndPoint = null;
        private readonly int _usersLimit;
        private readonly int port = 5001;
        private readonly string currentIpAddress = @"192.168.0.104";

        public int Port => port;

        public string CurrentIpAddress => currentIpAddress;

        public ServerService(
          
        
            int userLimit = 100
            )
        {
           
            _remoteEndPoint = null;
            _server = new UdpClient(port);
            _usersLimit = userLimit;
           

        }

     

        

        public void Receive()
        {
            while (true)
            {

                byte[] buffer = new byte[1024];
                SafeReceive(ref buffer);
                Console.WriteLine(Encoding.UTF8.GetString(buffer));

                SafeSendAsync(buffer);
            }
           


        }
        private async void SafeSendAsync(byte[] buffer)
        {
            try
            {
                await _server.SendAsync(buffer, buffer.Length, _remoteEndPoint);

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
            catch (SocketException)
            {
                DisplayNetworkErrorMessage();
            }
        }
        public void CloseServer()
        {
            _server.Close();
        }


    }
}
