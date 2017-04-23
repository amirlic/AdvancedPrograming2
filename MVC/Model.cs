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
    public class Model<T> : IModel<T>
    {
        private Dictionary<string, MultiPlayerGame> multiGames;
        private Dictionary<string, MultiPlayerGame> multiGamesArePlayed;
        private Dictionary<string, Maze> singleGames;

        public Model()
        {
            singleGames = new Dictionary<string, Maze>();
            multiGames = new Dictionary<string, MultiPlayerGame>();
            multiGamesArePlayed = new Dictionary<string, MultiPlayerGame>();
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(rows, cols);
            return maze;
        }
        public Solution<T> Solve(string name, int algoritem)
        {
            switch (algoritem)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        break;
                    }
            }
        }
        public MultiPlayerGame Start(string name, int rows, int cols)
        {
            Maze maze = GenerateMaze(name, rows, cols);
            MultiPlayerGame game = new MultiPlayerGame();
            game.AddMaze(maze);
            multiGames.Add(name, game);
            return game;
        }

        public List<string> NameOfGames()
        {
            return null;
        }

        public MultiPlayerGame Join(string name) {
            MultiPlayerGame game = multiGames[name];

            multiGames.Remove(name);
            multiGamesArePlayed.Add(name, game);
            return game;
        }

        public void Play(string move) { }

        public void Close(string name) { }

        public Dictionary<string, MultiPlayerGame> getMultiplayerGames()
        {
            return multiGames;
        }

        public void ConnectToGame(string mazeName, TcpClient client)
        {
            multiGames[mazeName].AddPlayer(client);
        }
    }
}
