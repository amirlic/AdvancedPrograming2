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

            NetworkStream stream = client.GetStream();
            BinaryReader reader = new BinaryReader(stream);
            BinaryWriter writer = new BinaryWriter(stream);

            bool isWrite = false;
            bool isRead = true;


            while (true)
            {

                Console.WriteLine("please enter command to the server ");
                request = Console.ReadLine();
                writer.Write(request);
                writer.Flush();
                if (request.StartsWith("close") || request.StartsWith("join") ||
                request.StartsWith("play") || request.StartsWith("list") ||
                request.StartsWith("start"))
                {
                    while (true)
                    {
                        while (isRead)
                        {
                            Task recive = new Task(() =>
                            {
                                BinaryReader readerer = new BinaryReader(stream);
                                Console.WriteLine("MORE ANSWER");
                                string answer = readerer.ReadString();
                                Console.WriteLine("server answered to = {0}", answer);
                                isRead = false;
                                isWrite = true;
                                Thread.Sleep(800);
                            });
                            recive.Start();
                            recive.Wait();
                        }
                        while (isWrite)
                        {
                            Task send = new Task(() =>
                            {
                                BinaryWriter writerer = new BinaryWriter(stream);
                                Console.WriteLine("please enter command to the server ");
                                request = Console.ReadLine();
                                Console.WriteLine("SENDING");
                                writerer.Write(request);
                                writerer.Flush();
                                Thread.Sleep(800);
                                isRead = true;
                                isWrite = false;
                            });
                            send.Start();
                            send.Wait();
                        }
                    }
                }
                else
                {
                    string answer = reader.ReadString();
                    Console.WriteLine("server answered to = {0}", answer);
                }
            }
            /*
            while (true)
            {
                if (request.StartsWith("join"))
                {
                    string answer = reader.ReadString();
                    Console.WriteLine("server answered to = {0}", answer);
                }
                bool endWriting = false;
                bool gameEnd = false;
                Task ongoing = new Task(() =>
                {

                    writer.Flush();

                    while (!gameEnd)
                    {
                        if (!endWriting)
                        {
                            Console.WriteLine("entered to the game");
                            endWriting = true;
                        }
                        string msg = reader.ReadString();

                        if (!msg.StartsWith("start"))
                            Console.WriteLine(msg);

                    }
                });
                ongoing.Start();
                Thread.Sleep(800);
                bool endConnection = false;
                while (!endConnection)
                {
                    if (canContinue)
                    {
                        Console.WriteLine("enter a command");
                        request = Console.ReadLine();

                    }
                    if (!endConnection)
                    {
                        if (canContinue)
                        {
                            writer.Write(request);
                            canContinue = true;
                        }
                    }
                }
                endConnection = true;
            }*/
        }
    }
}
