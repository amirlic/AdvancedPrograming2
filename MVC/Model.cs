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
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            DFSMazeGenerator maze = new DFSMazeGenerator();
            return maze.Generate(rows, cols);
        }
    }
}
