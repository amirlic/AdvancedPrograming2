using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;

namespace MVC
{
    class Model : IModel
    {
        private Dictionary<string, Maze> mazeList;
        private Dictionary<string, string> mazeSolutionsDict;///////////
        private Dictionary<string, Maze> mazeGamesDict;///////////

        public Maze GenerateMaze(string name, int rows, int cols)
        {
            mazeSolutionsDict = new Dictionary<string, string>();////////////
            mazeGamesDict = new Dictionary<string, Maze>();////////////
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            mazeList.Add(mazeGenerate.Generate(rows, cols).Name, mazeGenerate.Generate(rows, cols));
            return mazeGenerate.Generate(rows, cols);
        }
        //TODO..
        public string Solve(string name, int algoritem)
        {
            
        }
        public string Start(string name, int rows, int cols) { }
        public List<string> NameOfGames() { return null; }
        public string Join(string name) { }
        public void Play(string move) { }
        public void Close(string name) { }
    }
}
