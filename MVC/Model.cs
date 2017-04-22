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
        private Dictionary<string, MultiplayerGame> multiGames;
        private Dictionary<string, MultiplayerGame> multiGamesArePlayed;
        private Dictionary<string, Maze> singleplayerMazeList;

        private Dictionary<string, List<TcpClient>> playersInMaze;

        public Model()
        {
            singleplayerMazeList = new Dictionary<string, Maze>();
            multiGames = new Dictionary<string, MultiplayerGame>();
            multiGamesArePlayed = new Dictionary<string, MultiplayerGame>();
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
            MultiplayerGame game = new MultiplayerGame();
            game.AddMaze(maze);
            multiGames.Add(name, game);
            return name;
        }

        public List<string> NameOfGames()
        {
            return null;
        }

        public string Join(string name) {
            MultiplayerGame game = multiGames[name];

            multiGames.Remove(name);
            multiGamesArePlayed.Add(name, game);
            return name;/////TODO JSON
        }

        public void Play(string move) { }

        public void Close(string name) { }

        public Dictionary<string, MultiplayerGame> getMultiplayerGames()
        {
            return multiGames;
        }

        public void ConnectToGame(string mazeName, TcpClient client)
        {
            multiGames[mazeName].AddPlayer(client);
            /*
            List<TcpClient> players = playersInMaze[mazeName];
            if (players != null)
            {
                playersInMaze[mazeName].Add(client);
            } else
            {
                List<TcpClient> playerList = new List<TcpClient>();
                playerList.Add(client);
                playersInMaze.Add(mazeName, playerList);
            }*/
        }
    }
}
