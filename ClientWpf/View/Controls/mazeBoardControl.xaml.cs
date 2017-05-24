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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClientWpf.ViewModel;

namespace ClientWpf.View.Controls
{
    /// <summary>
    /// Interaction logic for MazeBoardControl.xaml
    /// </summary>
    public partial class MazeBoardControl : UserControl
    {
        public MazeBoardControl()
        {
            InitializeComponent();
        }
        #region rows


        public int rows
        {

            get { return (int)GetValue(rowsProperty); }
            set { SetValue(rowsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for rows.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty rowsProperty =
            DependencyProperty.Register("rows", typeof(int), typeof(SinglePlayerViewModel), new PropertyMetadata(0));
        #endregion

        #region cols


        public int cols
        {
            get { return (int)GetValue(colsProperty); }
            set { SetValue(colsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for cols.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty colsProperty =
            DependencyProperty.Register("cols", typeof(int), typeof(SinglePlayerViewModel), new PropertyMetadata(0));
        #endregion

        public void printMaze()
        { }
        private void myCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            int noOfRecsInRow = 600 / rows;
            int noOfRecsInCol = 600 / cols;
            Path p1 = new Path();

            GeometryGroup GG1 = new GeometryGroup();
            Rect[,] mat = new Rect[rows, cols];
            for (int i = 0; i < noOfRecsInRow; i++)
            {
                for (int j = 0; j < noOfRecsInCol; j++)
                {
                    RectangleGeometry recG1 = new RectangleGeometry();
                    Rect a = new Rect();
                    a.Height = noOfRecsInCol;
                    a.Width = noOfRecsInRow;
                    a.Location = new Point(i, j);
                    recG1.Rect = a;
                    GG1.Children.Add(recG1);
                }
            }
            p1.Data = GG1;
            myCanvas.Children.Add(p1);

        }
    }
}