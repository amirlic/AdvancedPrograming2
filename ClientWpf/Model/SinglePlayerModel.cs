using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpf.Model
{
    public class SinglePlayerModel : ISinglePlayerModel
    {
        private Client tcp;
        /**
          * @param gameKind an int indicating the game kind: 1 for single player and 2 for multiplayer
          **/
        public SinglePlayerModel(int gameKind)
        {
            tcp = new Client(MazeName, MazeRows, MazeCols, gameKind);
            tcp.Start();
        }


        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public string MazeName { get; set; }
    }
}
