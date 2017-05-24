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
using System.Configuration;
using MazeLib;

namespace ClientWpf
{
    class Client
    {
        //the socket to send and receive data to and from the server
        private TcpClient client;

        //the number of rows for the maze to be generated
        private int noRows;

        //the number of collumns for the maze to be generated
        private int noCol;

        //an int indicating game kind: 1 for single player and 2 for multiplayer
        private int gameKind;

        //the name of the maze to be generated
        private string nameOfMaze;

        private Maze maze;

        public Client(string name, int rows, int cols, int gameKind)
        {
            this.noRows = rows;
            this.noCol = cols;

            this.nameOfMaze = name;

            this.gameKind = gameKind;

            this.maze = null;
        }

        public void Start()
        {
            //IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"),
            //int.Parse(ConfigurationManager.AppSettings["port"]));
            //the visual dont recognize this...

            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);

            string request = "";
            string answer = "";
            bool endGame = false;

            //while (true)
            //{
                
                //creating the string to send to the server in order to receive the new maze
                request = "generate " + this.nameOfMaze + " " + this.noRows + " " + this.noCol;
                

                this.client = new TcpClient();
                this.client.Connect(ep);

                NetworkStream stream = client.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);

                endGame = false;

                //sending the maze generating request to the server
                writer.Write(request);
                writer.Flush();

                //multiplayer handling
                if ((request.StartsWith("close") || request.StartsWith("join") ||
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
                    maze = MazeLib.Maze.FromJSON(answer);
                    Console.WriteLine("server SinglePlayer generated maze = {0}", answer);
                    endGame = true;
                    client.Close();
                }
            }
        //}
        public Maze getMaze()
        {
            if(this.maze == null)
            {
                throw new System.NullReferenceException("maze is null");
            }
            return this.maze;
        }
    }
}

