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
    class SolveCommand : ICommand
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
            SinglePlayerGame<Position> game = model.Solve(name, algoritem);
            JObject solveObj = new JObject();
            solveObj["Name"] = game.GetMaze().Name;
            solveObj["Solution"] = game.GetSolution().ToString();
            solveObj["NodesEvaluated"] = game.GetSolution().GetNum().ToString();
            return solveObj.ToString();
        }
    }
}
