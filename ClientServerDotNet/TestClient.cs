using System;
using System.IO;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace ClientServerDotNet
{
    class TestClient
    {

        public TestClient()
        {
           
        }

        public void Connect() 
        {
            TcpClient client = new TcpClient();
            client.Connect(SimpleServer.GetLocalIP(), 9911);
        }
    }
}
