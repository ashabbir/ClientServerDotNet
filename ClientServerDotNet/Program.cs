using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientServerDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new SimpleServer();
            Thread listener;
            if (server.StartServer())
            {
                Console.WriteLine("server starting");
                Console.WriteLine("End point " + server.listener.LocalEndpoint);

                listener = new Thread(new ThreadStart(server.StartListeningForNewConnections));
                listener.Start();
                
                TestClient c = new TestClient();
                c.Connect();

                Console.WriteLine("Listener Dispatched");
                listener.Join();
              
            }
            else 
            {
                Console.WriteLine("server start up failed");
            }

            Console.WriteLine("Exiting main thread");
            Console.ReadLine();
        }
    }
}
