using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpf.Model
{
    public interface ISinglePlayerModel
    {
        int MazeRows { get; set; }
        int MazeCols { get; set; }
        string MazeName { get; set; }
    }
}
