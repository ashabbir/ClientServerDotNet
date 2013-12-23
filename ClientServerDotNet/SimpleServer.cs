using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ClientServerDotNet
{

    /// <summary>
    /// server class has 
    /// a listener
    /// and a list of sockets 
    /// </summary>
    class SimpleServer
    {
        public IPAddress ipAddress { get; set; }
        public TcpListener listener { get; set; }
        public Socket socket { get; set; }
        public List<Thread> SocketThreads { get; set; }


        public bool StartServer()
        {
            SocketThreads = new List<Thread>();
            var toreturn = true;
            try
            {
                ipAddress = IPAddress.Parse(GetLocalIP());
                listener = new TcpListener(ipAddress, 9911);
                listener.Start();

            }
            catch (Exception)
            {
                //kill it
                toreturn = false;
            }

            return toreturn;
        }



        public void StartListeningForNewConnections()
        {
            try
            {
                while (true)
                {
                    var socket = listener.AcceptSocket();
                    
                        ServerConnection c = new ServerConnection()
                        {
                            Id = "A",
                            Socket = socket
                        };
                        var t = new Thread(new ThreadStart(c.ReceiveMessages));
                        t.Start();
                        SocketThreads.Add(t);
                   
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {

            }

        }




        class ServerConnection
        {
            public Socket Socket { get; set; }
            public string Id { get; set; }

            public void ReceiveMessages()
            {
                while(true) 
                {
                    byte[] b = new byte[1000];
                    int k = Socket.Receive(b);
                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(Convert.ToChar(b[i]));
                    }
                    Console.WriteLine();
                    }
            }
        }



        public static string GetLocalIP()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }
    }


}
