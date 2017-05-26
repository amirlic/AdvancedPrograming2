using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWpf.Model
{
    public class SinglePlayerModel : GameModel
    {
        private string name;
        /**
          * @param gameKind an int indicating the game kind: 1 for single player and 2 for multiplayer
          **/
        public SinglePlayerModel()
        {
            name = " ";
        }

        public string MazeName
        {
            get { return name; }
            set
            {
                name = value;
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
    }
}
