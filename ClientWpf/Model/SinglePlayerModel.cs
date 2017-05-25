using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpf.Model
{
    public class SinglePlayerModel : GameModel
    {
        private Client tcp;
        private int gameKind;
        string mazeName;
        int mazeRows , mazeCols;

        /**
          * @param gameKind an int indicating the game kind: 1 for single player and 2 for multiplayer
          **/
        public SinglePlayerModel(int gameKind)
        {
            this.gameKind = gameKind;
            mazeName = "a";
        }

        public string MazeName
        {
            get { return mazeName; }
            set
            {
                mazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }

        public int MazeRows
        {
            get { return Properties.Settings.Default.MazeRows; }
            set { Properties.Settings.Default.MazeRows = value; }
        }
        public int MazeCols
        {
            get { return Properties.Settings.Default.MazeCols; }
            set { Properties.Settings.Default.MazeCols = value; }
        }

        public void StartGame()
        {
            tcp = new Client(MazeName, MazeRows, MazeCols, gameKind);
            tcp.Start();
        }
    }
}
