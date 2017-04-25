using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace MVC
{
    class ClientHandler : IClientHandler
    {
        private Controller control;

        public ClientHandler()
        {
            this.control = new Controller();
        } 

        public void HandleClient(TcpClient client)
        {
            new Task(() =>
            {
                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);
                
                string commandLine = reader.ReadString();
                Console.WriteLine("Got command: {0}", commandLine);
                string result = control.ExecuteCommand(commandLine, client);
                writer.Write(result);

                client.Close();
            }).Start();
        }
    }
}
