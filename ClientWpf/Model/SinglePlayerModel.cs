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
        private Client tcp;
        private int gameKind;
        private string mazeName;
        private int mazeRows , mazeCols;
        private Position myLocation;
        private Position otherLocation;
        private Position finishLocation;

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

        public Position MyLocation { get; set; }
        public Position OtherLocation { get; set; }
        public Position FinishLocation { get; set; }

        public void StartGame()
        {
            tcp = new Client(MazeName, MazeRows, MazeCols, gameKind);
            tcp.Start();
            Maze maze = tcp.getMaze();
            this.myLocation = maze.InitialPos;
            //this.otherLocation;
            this.finishLocation = maze.GoalPos;
        }
    }
}
