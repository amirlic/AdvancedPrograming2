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
    class Model : IModel
    {
        private Dictionary<string, Maze> singleplayerMazeList;
        private Dictionary<string, Maze> multiplayerMazeList;

        private Dictionary<string, List<TcpClient>> playersInMaze;

        public Model()
        {
            singleplayerMazeList = new Dictionary<string, Maze>();
            multiplayerMazeList = new Dictionary<string, Maze>();
            playersInMaze = new Dictionary<string, List<TcpClient>>();
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(rows, cols);
            return maze;
        }
        //TODO..
        public string Solve(string name, int algoritem)
        {

            
        }
        public string Start(string name, int rows, int cols)
        {
            Maze maze = GenerateMaze(name, rows, cols);
            multiplayerMazeList.Add(name, maze);
            return name;
        }

        public List<string> NameOfGames() { return null; }

        public string Join(string name) {
            Maze maze = multiplayerMazeList[name];
            return name;
        }

        public void Play(string move) { }

        public void Close(string name) { }

        public Dictionary<string, Maze> getMultiplayerMazes()
        {
            return multiplayerMazeList;
        }

        public void AddPlayer(string mazeName, TcpClient client)
        {
            List<TcpClient> players = playersInMaze[mazeName];
            if (players != null)
            {
                playersInMaze[mazeName].Add(client);
            } else
            {
                List<TcpClient> playerList = new List<TcpClient>();
                playerList.Add(client);
                playersInMaze.Add(mazeName, playerList);
            }
        }
    }
}
