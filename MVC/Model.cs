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
    public class Model : IModel
    {
        private Dictionary<string, MultiplayerGame> multiGames;
        private Dictionary<string, MultiplayerGame> multiGamesArePlayed;
        private Dictionary<string, Maze> singleGames;

        public Model()
        {
            singleGames = new Dictionary<string, Maze>();
            multiGames = new Dictionary<string, MultiplayerGame>();
            multiGamesArePlayed = new Dictionary<string, MultiplayerGame>();
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(rows, cols);
            return maze;
        }
        public string Solve(string name, int algoritem)
        {

            
        }
        public MultiplayerGame Start(string name, int rows, int cols)
        {
            Maze maze = GenerateMaze(name, rows, cols);
            MultiplayerGame game = new MultiplayerGame();
            game.AddMaze(maze);
            multiGames.Add(name, game);
            return game;
        }

        public List<string> NameOfGames()
        {
            return null;
        }

        public MultiplayerGame Join(string name) {
            MultiplayerGame game = multiGames[name];

            multiGames.Remove(name);
            multiGamesArePlayed.Add(name, game);
            return game;
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
        }
    }
}
