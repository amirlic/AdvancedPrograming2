using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpf.Model
{
    public class SinglePlayerModel : ISinglePlayerModel
    {
        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public string MazeName { get; set; }
    }
}
