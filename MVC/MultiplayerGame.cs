using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;

namespace MVC
{
    class MultiplayerGame : IGame
    {
        private TcpClient player1;
        private TcpClient player2;
        private Maze maze;


        public void AddPlayer(TcpClient client)
        {
            if (player1 == null)
            {
                this.player1 = client;
            }
            else if (player2 != null)
            {
                this.player2 = client;
            }
            else if (player2 != null && player1 != null)
            {
                Console.WriteLine("ERORR 2 PLEYERS ALREDY JOIN");
            }
        }

        public void AddMaze(Maze maze)
        {
            this.maze = maze;
        }

        public TcpClient GetPlayer()
        {
            return this.player1;
        }

        public TcpClient GetPlayer2()
        {
            return this.player2;
        }

        public string GetMaze()
        {
            return this.maze.Name;
        }
    }
}
