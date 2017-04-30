using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using MVC;

namespace ConsoleApp1
{
    class Program
    {
        public void CompareSolvers()
        {
            DFSMazeGenerator mazeGen = new DFSMazeGenerator();
            Maze m = mazeGen.Generate(100, 100);
            BFS<Position> bfs = new BFS<Position>();
            Solution<Position> sol = bfs.Search(new Adapter(m));
            DFS<Position> dfs = new DFS<Position>();
            Solution<Position> sol1 = dfs.Search(new Adapter(m));
            Console.WriteLine("BFS:");
            Console.WriteLine(bfs.GetNumberOfNodesEvaluated());
            Console.WriteLine("DFS:");
            Console.WriteLine(dfs.GetNumberOfNodesEvaluated());
            Console.ReadKey();
        }
    }
}

