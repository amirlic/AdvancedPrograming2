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
        
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator mazeGenerate = new DFSMazeGenerator();
            mazeList.Add(mazeGenerate.Generate(rows, cols).Name, mazeGenerate.Generate(rows, cols));
            return mazeGenerate.Generate(rows, cols);
        }
        public Maze getMaze(string name)
        {

        }
        //TODO..
        public void Solve(string name, int algoritem) { }
        public void Start(string name, int rows, int cols) { }
        public List<string> NameOfGames() { return null; }
        public void Join(string name) { }
        public void Play(string move) { }
        public void Close(string name) { }
    }
}
