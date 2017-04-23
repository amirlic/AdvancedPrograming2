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
    public class Model : IModel
    {
        private Dictionary<string, MultiPlayerGame> multiGames;
        private Dictionary<string, MultiPlayerGame> multiGamesArePlayed;
        private Dictionary<string, SinglePlayerGame> singleGames;
        private Dictionary<string, SinglePlayerGame> singleGamesArePlayed;

        public Model()
        {
            singleGames = new Dictionary<string, SinglePlayerGame>();
            singleGamesArePlayed = new Dictionary<string, SinglePlayerGame>();
            multiGames = new Dictionary<string, MultiPlayerGame>();
            multiGamesArePlayed = new Dictionary<string, MultiPlayerGame>();
        }

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerator = new DFSMazeGenerator();
            Maze maze = mazeGenerator.Generate(rows, cols);
            SinglePlayerGame game = new SinglePlayerGame();
            game.AddMaze(maze);
            singleGames.Add(name, game);
            return maze;
        }
        public Adapter Solve(string name, int algoritem)
        {
            Adapter maze = new Adapter(singleGames[name].GetMaze());
            SinglePlayerGame game = singleGames[name];
            singleGames.Remove(name);
            singleGamesArePlayed.Add(name, game);
            switch (algoritem)
            {
                case 0:
                    {
                        BFS<Position> bfs = new BFS<Position>();
                        Solution<Position> sol = bfs.Search(maze);
                        int num = bfs.GetNumberOfNodesEvaluated();
                        maze.AddSolution(sol);
                        break;
                    }
                case 1:
                    {
                        DFS<Position> dfs = new DFS<Position>();
                        Solution<Position> sol = dfs.Search(maze);
                        int num = dfs.GetNumberOfNodesEvaluated();
                        maze.AddSolution(sol);
                        break;
                    }
            }
            return maze;
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
