using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using SearchAlgorithmsLib;


namespace MVC
{
    public class SinglePlayerGame<T> : IGame
    {
        private TcpClient player1;
        private Solution<T> solution;
        private Maze maze;


        public void AddPlayer(TcpClient client)
        {
                this.player1 = client;
        }

        public void AddMaze(Maze maze)
        {
            this.maze = maze;
        }

        public TcpClient GetPlayer()
        {
            return this.player1;
        }

        public Maze GetMaze()
        {
            return this.maze;
        }

        public Solution<T> GetSolution()
        {
            return this.solution;
        }

        public void AddSolution(Solution<T> sol)
        {
            this.solution = sol;
        }
    }
}
