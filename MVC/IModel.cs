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
        string Solve(string name, int algoritem);
        string Start(string name, int rows, int cols);
        List<string> NameOfGames();
        string Join(string name);
        void Play(string move);
        void Close(string name);
    }
}
