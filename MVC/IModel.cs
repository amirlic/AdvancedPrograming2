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
        void Solve(string name, int algoritem);
        void Start(string name, int rows, int cols);
        List<string> NameOfGames();
        void Join(string name);
        void Play(string move);
        void Close(string name);
    }
}
