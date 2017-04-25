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
            Task t = new Task(() =>
            {
                using (NetworkStream stream = client.GetStream())
                using (BinaryReader reader = new BinaryReader(stream))
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    string line = "";
                    while (!line.Equals("close"))

                    {
                        line = reader.ReadString();
                        string result = this.control.ExecuteCommand(line, client);
                        Console.WriteLine(line);
                        writer.Write(result);
                        writer.Flush();
                    }
                }
                client.Close();
            });
            t.Start();
        }
    }
}
