using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class OurServer
    {
        TcpListener server;
        StreamReader reader;
        StreamWriter writer;

        public OurServer()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5555);
            server.Start();

            LoopClients();
        }

        private void LoopClients()
        {
            while(true)
            {
                TcpClient client = server.AcceptTcpClient();

                Thread thread = new Thread(() => HandelClient(client));
                thread.Start();
            }
        }

        void HandelClient(TcpClient client)
        {
            reader = new StreamReader(client.GetStream(), Encoding.UTF8);
            writer = new StreamWriter(client.GetStream(), Encoding.UTF8);

            while(true)
            {
                string? inputMessage = reader.ReadLine();
                Console.WriteLine($"Клиент написал - {inputMessage}");
                string? outputMessage = Console.ReadLine();
                writer.WriteLine(outputMessage);
                writer.Flush();
            }
        }
    }
}
