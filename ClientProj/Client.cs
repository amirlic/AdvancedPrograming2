using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.Net;
using System.IO;
using System.Threading;


namespace ClientProj
{
    class Client
    {
        private TcpClient client;

        public Client()
        {
            this.client = new TcpClient();
        }

        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            this.client.Connect(ep);
            Console.WriteLine("You are connected");
            string request = "";
            string answer = "";

            NetworkStream stream = client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            while (true)
            {
                bool endGame = false;

                Console.WriteLine("please enter command to the server ");
                request = Console.ReadLine();
                writer.Write(request);
                writer.Flush();

                if ((request.StartsWith("close")  || request.StartsWith("join") ||
                request.StartsWith("play") || request.StartsWith("list") ||
                request.StartsWith("start")) && !endGame)
                {
                    Task recive = new Task(() =>
                        {
                           while (!answer.Equals("close"))
                           {
                               BinaryReader readerer = new BinaryReader(stream);
                               Console.WriteLine("Wait for ANSWER");
                               answer = readerer.ReadString();
                               Console.WriteLine("server answered to = {0}", answer);
                           }
                           endGame = true;
                       });
                       recive.Start();
                    //if (request.StartsWith("close")) { recive.Wait(); }

                    Task send = new Task(() =>
                        {
                            while (!answer.StartsWith("close"))
                            {
                                 BinaryWriter writerer = new BinaryWriter(stream);
                                 Console.WriteLine("please enter command to the server ");
                                 request = Console.ReadLine();
                                 Console.WriteLine("SENDING");
                                 writerer.Write(request);
                                 writerer.Flush();
                             }
                             endGame = true;
                         });
                         send.Start();
                         send.Wait();
                }
                else
                {
                    answer = reader.ReadString();
                    Console.WriteLine("server answered to = {0}", answer);
                }
            }
        }
    }
}
