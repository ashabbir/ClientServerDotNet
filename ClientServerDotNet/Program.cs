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
            Thread BroadCaster;
            if (server.StartServer())
            {
                Console.WriteLine("server starting");
                Console.WriteLine("End point " + server.listener.LocalEndpoint);

                listener = new Thread(new ThreadStart(server.StartListeningForNewConnections));
                listener.Start();
                Console.WriteLine("Listener Dispatched");
                BroadCaster = new Thread(new ThreadStart(server.StartBroadcasting));
                BroadCaster.Start();
                Console.WriteLine("BroadCaster Dispatched");
          
                
                listener.Join();
                BroadCaster.Join();
              
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
