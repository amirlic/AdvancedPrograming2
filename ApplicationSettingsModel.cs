using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using MazeLib;
using ClientWpf.Model;
using ClientWpf;

namespace ClientWpf.Model
{
    public class ApplicationSettingsModel : ISettingsModel
    {
        private int rows = 3;
        private int cols = 3;

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public string ServerIP
        {
            get { return Properties.Settings.Default.ServerIP; }
            set { Properties.Settings.Default.ServerIP = value; }
        }
        public int ServerPort
        {
            get { return Properties.Settings.Default.ServerPort; }
            set { Properties.Settings.Default.ServerPort = value; }
        }

        public int MazeRows
        {
            get { return rows; }
            set
            {
                rows = value;
                NotifyPropertyChanged("MazeRows");
            }
        }

        public int MazeCols
        {
            get { return cols; }
            set
            {
                cols = value;
                NotifyPropertyChanged("MazeCols");
            }
        }

        public int SearchAlgorithm
        {
            get { return Properties.Settings.Default.SearchAlgorithm; }
            set { Properties.Settings.Default.SearchAlgorithm = value; }
        }

        public void SaveSettings()
        {
            Properties.Settings.Default.Save();
        }
    }
}
