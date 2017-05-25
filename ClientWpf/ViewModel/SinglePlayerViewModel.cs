using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MazeLib;
using ClientWpf.Model;

namespace ClientWpf.ViewModel
{
    class SinglePlayerViewModel : ViewModel
    {
        private SinglePlayerModel model;

        public SinglePlayerViewModel()
        {
            //we pass 1 as the game kind because it is a single player game
            this.model = new SinglePlayerModel(1);
        }

        public string MazeName
        {
            get { return model.MazeName; }
            set
            {
                model.MazeName = value;
                NotifyPropertyChanged("MazeName");
            }
        }

        public int MazeRows
        {
            get { return model.MazeRows; }
            set
            {
                model.MazeRows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }

        public int MazeCols
        {
            get { return model.MazeCols; }
            set
            {
                model.MazeCols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        public Position MyLocation {
            get { return model.MyLocation; }
            set
            {
                model.MyLocation = value;
                NotifyPropertyChanged("MyLocation");
            }
        }
        public Position OtherLocation {
            get { return model.OtherLocation; }
            set
            {
                model.OtherLocation = value;
                NotifyPropertyChanged("OtherLocation");
            }
        }
        public Position FinishLocation {
            get { return model.FinishLocation; }
            set
            {
                model.FinishLocation = value;
                NotifyPropertyChanged("FinishLocation");
            }
        }

        public void Game()
        {
            this.model.StartGame();
        }

        public void MoveRight()
        {
            this.model.Right();
        }

        public void MoveLeft()
        {
            this.model.Left();
        }

        public void MoveDown()
        {
            this.model.Down();
        }

        public void MoveUp()
        {
            this.model.Up();
        }

    }
}
