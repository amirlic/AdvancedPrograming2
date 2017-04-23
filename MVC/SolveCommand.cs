using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using SearchAlgorithmsLib;

namespace MVC
{
    class SolveCommand<T> : ICommand
    {
        private IModel model;
        public SolveCommand(IModel model)
        {
            this.model = model;
        }
        public string Execute(string[] args, TcpClient client)
        {
            string name = args[0];
            int algoritem = int.Parse(args[1]);
            Solution<T> sol = model.Solve(name, algoritem);
            model.ConnectToGame(name, client);
            Maze maze = game.GetMaze();
            return maze.ToJSON();
        }
    }
}
