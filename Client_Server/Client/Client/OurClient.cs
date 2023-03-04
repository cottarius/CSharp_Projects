using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class OurClient
    {

        TcpClient tcpClient;
        StreamWriter writer;
        StreamReader? reader;

        public OurClient(string ipAddress, int portNumber)
        {
            tcpClient = new TcpClient(ipAddress, portNumber);
            writer = new StreamWriter(tcpClient.GetStream(), Encoding.UTF8);
            reader = new StreamReader(tcpClient.GetStream(), Encoding.UTF8);
            HandleCommunication();

        }

        void HandleCommunication()
        {
            reader = new StreamReader(tcpClient.GetStream(), Encoding.UTF8);
            while (true)
            {
                Console.Write("> ");
                string? outputMessage = Console.ReadLine();
                writer.WriteLine(outputMessage);
                writer.Flush();
                Console.WriteLine();
                string? inputMessage = reader.ReadLine();
                Console.WriteLine($"Сервер написал  - {inputMessage}");
            }
        }
    }
}

