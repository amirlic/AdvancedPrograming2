using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using MazeGeneratorLib;

namespace MVC
{
    public interface IModel
    {
       Maze GenerateMaze(string name, int rows, int cols);
    }
}
