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
        private int gameKind;
        /**
          * @param gameKind an int indicating the game kind: 1 for single player and 2 for multiplayer
          **/
        public SinglePlayerModel(int gameKind)
        {
            this.gameKind = gameKind;
        }


        public int MazeRows { get; set; }
        public int MazeCols { get; set; }
        public string MazeName { get; set; }

        public void StartGame()
        {
            tcp = new Client(MazeName, MazeRows, MazeCols, gameKind);
            tcp.Start();
        }
    }
}
