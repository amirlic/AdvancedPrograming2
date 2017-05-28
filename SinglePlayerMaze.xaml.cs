using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClientWpf.View
{
    /// <summary>
    /// Interaction logic for SinglePlayerMaze.xaml
    /// </summary>
    public partial class SinglePlayerMaze : Window
    {







        public string MazeName2
        {
            get { return (string)GetValue(MazeName2Property); }
            set { SetValue(MazeName2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MazeName2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeName2Property =
            DependencyProperty.Register("MazeName2", typeof(string), typeof(Controls.MenuUserControl), new PropertyMetadata("Maze"));





        public int MazeRows2
        {
            get { return (int)GetValue(MazeRows2Property); }
            set { SetValue(MazeRows2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MazeRows2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeRows2Property =
            DependencyProperty.Register("MazeRows2", typeof(int), typeof(Controls.MenuUserControl), new PropertyMetadata(10));



        public int MazeCols2
        {
            get { return (int)GetValue(MazeCols2Property); }
            set { SetValue(MazeCols2Property, value); }
        }

        // Using a DependencyProperty as the backing store for MazeCols2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MazeCols2Property =
            DependencyProperty.Register("MazeCols2", typeof(int), typeof(Controls.MenuUserControl), new PropertyMetadata(10));



        
        public SinglePlayerMaze()
        {
            DataContext = this;
            InitializeComponent();
        }
        public SinglePlayerMaze(int rows, int cols)
        {
            this.MazeCols2 = cols;
            this.MazeRows2 = rows;
            DataContext = this;
            InitializeComponent();
        }
        public SinglePlayerMaze(int rows, int cols, string name)
        {
            this.MazeCols2 = cols;
            this.MazeRows2 = rows;
            this.MazeName2 = name;
            DataContext = this;
            InitializeComponent();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
