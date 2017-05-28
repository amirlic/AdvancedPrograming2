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
        private int rows;
        private int cols;
        /**
          * @param gameKind an int indicating the game kind: 1 for single player and 2 for multiplayer
          **/
        public SinglePlayerModel()
        {
            name = " ";
            rows = 0;
            cols = 0;
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
            get { return rows; }
            set { rows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }
        public int MazeCols
        {
            get { return cols; }
            set {cols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }
    }
}
