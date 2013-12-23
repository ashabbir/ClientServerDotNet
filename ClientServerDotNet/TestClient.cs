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
            
                using (TcpClient client = new TcpClient())
                {
                    client.Connect(SimpleServer.GetLocalIP(), 9911);
                    Stream stm = client.GetStream();
                    //this is sending a message to the server
                    ASCIIEncoding asen = new ASCIIEncoding();
                    string str = "Heelo i m " ;
                    byte[] b = asen.GetBytes(str);
                    stm.Write(b, 0, b.Length);
                }
          
           
          
        }
    }
}
