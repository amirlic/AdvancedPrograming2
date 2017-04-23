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
    public interface IModel<T>
    {
        Maze GenerateMaze(string name, int rows, int cols);
        Solution<T> Solve(string name, int algoritem);
        MultiPlayerGame Start(string name, int rows, int cols);
        List<string> NameOfGames();
        MultiPlayerGame Join(string name);
        void Play(string move);
        void Close(string name);
        void ConnectToGame(string mazeName, TcpClient client);
    }
}
