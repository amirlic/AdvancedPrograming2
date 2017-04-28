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

        }

        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            string request = "";
            string answer = "";
            bool endGame = false;

            while (true)
            {
                Console.WriteLine("please enter First command to the server ");
                request = Console.ReadLine();

                this.client = new TcpClient();
                this.client.Connect(ep);
                Console.WriteLine("You are connected");

                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);

                endGame = false;

                writer.Write(request);
                writer.Flush();

                if ((request.StartsWith("close")  || request.StartsWith("join") ||
                request.StartsWith("play") || request.StartsWith("list") ||
                request.StartsWith("start")) && !endGame)
                {
                    Task recive = new Task(() =>
                        {
                           while (!answer.Equals("close") && !endGame)
                           {
                                BinaryReader readerer = new BinaryReader(stream);

                                Console.WriteLine("Wait for ANSWER");
                                answer = readerer.ReadString();
                                Console.WriteLine("server answered to = {0}", answer);
                           }
                           Console.WriteLine("EndReciveTASK");
                           endGame = true;
                       });
                       recive.Start();
                    if (endGame) { recive.Wait(); }

                    Task send = new Task(() =>
                        {
                        while ((!request.StartsWith("close") || answer.StartsWith("close")) && !endGame)
                            {
                                BinaryWriter writerer = new BinaryWriter(stream);
                                Console.WriteLine("please enter command to the server ");
                                request = Console.ReadLine();
                                Console.WriteLine("SENDING");
                                writerer.Write(request);
                                writerer.Flush();
                            }
                            Console.WriteLine("EndSendTask");
                            endGame = true;
                         });
                         send.Start();
                         send.Wait();
                }
                else
                {
                    answer = reader.ReadString();
                    Console.WriteLine("server SinglePlayer answered to = {0}", answer);
                    endGame = true;
                    client.Close();
                }
            }
        }
    }
}
