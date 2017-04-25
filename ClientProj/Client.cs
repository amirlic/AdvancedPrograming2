using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;

namespace ClientProj
{
    class Client
    {
        private TcpClient client;

        public Client()
        {

        }

        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            while (true)
            {
                client = new TcpClient();
                client.Connect(ep);
                Console.WriteLine("You are connected");

                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);

                // Send data to server
                Console.Write("Please enter a number: ");
                string command = Console.ReadLine();
                writer.Write(command);

                // Get result from server
                string result = reader.ReadString();
                Console.WriteLine("Result = {0}", result);
            }
        }
    }
}
