using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDP_ClientServer;

namespace UDP_Server
{
    class Program
    {

        private static readonly ServerService _serverService = new ServerService();
        static void Main(string[] args)
        {
            
            _serverService.Receive();
            _serverService.CloseServer();
        }
    }
}
