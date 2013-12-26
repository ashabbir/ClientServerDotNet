using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using ChatLib;
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
        public List<ServerConnection> Connections { get; set; }

        public Queue<string> IncommingMessages { get; set; }


        public bool StartServer()
        {
            Connections = new List<ServerConnection>();
            SocketThreads = new List<Thread>();
            IncommingMessages = new Queue<string>();
            var toreturn = true;
            try
            {
                ipAddress = IPAddress.Parse(StaticHelper.GetLocalIP());
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

        public void StartBroadcasting()
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            while (true)
            {
                while (IncommingMessages.Count != 0)
                {
                    var msg = IncommingMessages.Dequeue();
                    foreach (var item in Connections)
                    {
                        item.Socket.Send(asen.GetBytes(msg));
                    }
                }
                 
              
            }
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
                        Socket = socket,
                        Incomming = IncommingMessages

                    };
                    Connections.Add(c);
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



        public class ServerConnection
        {
            public Socket Socket { get; set; }
            public string UserName { get; set; }
            public Queue<string> Incomming { get; set; }
            ASCIIEncoding asen = new ASCIIEncoding();

            public void ReceiveMessages()
            {

                byte[] ub = new byte[10000];
                int j = Socket.Receive(ub);
                UserName = asen.GetString(ub);
                

                while (true)
                {
                    byte[] b = new byte[10000];
                    int k = Socket.Receive(b);

                    for (int i = 0; i < k; i++)
                    {
                        Console.Write(Convert.ToChar(b[i]));
                    }
                    if (k > 0)
                    {
                        string msg = UserName + ": " + asen.GetString(b); ;
                        Incomming.Enqueue(msg);
                        Console.WriteLine();
                    }
                }
            }

        }




    }


}
