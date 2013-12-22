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
            if (server.StartServer())
            {
                Console.WriteLine("server starting");
                Console.WriteLine("End point " + server.listener.LocalEndpoint);

                var t = new Thread(new ThreadStart(server.StartListening));
                t.Start();
                
                TestClient c = new TestClient();
                c.Connect();
              
            }
            else 
            {
                Console.WriteLine("server start up failed");
            }
            Console.WriteLine("Listener Dispatched");
            Console.ReadLine();
        }
    }
}
