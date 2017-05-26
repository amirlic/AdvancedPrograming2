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
using MazeLib;

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
            //myCanvas_Loaded();
        }

             #region rows
        
        
            public int MazeRows
            {
        
                  get { return (int)GetValue(rowsProperty); }
                  set { SetValue(rowsProperty, value); }
            }
        
               // Using a DependencyProperty as the backing store for rows.  This enables animation, styling, binding, etc...
              public static readonly DependencyProperty rowsProperty =
              DependencyProperty.Register("rows", typeof(int), typeof(MazeBoardControl), new PropertyMetadata(10));
            #endregion


        #region cols
        
        
        public int MazeCols
           {
                get { return (int)GetValue(colsProperty); }
                set { SetValue(colsProperty, value); }
           }
        
               // Using a DependencyProperty as the backing store for cols.  This enables animation, styling, binding, etc...
              public static readonly DependencyProperty colsProperty =
                 DependencyProperty.Register("cols", typeof(int), typeof(MazeBoardControl), new PropertyMetadata(10));
            #endregion

        public void printMaze()
        { }
        private void myCanvas_Loaded(object sender, RoutedEventArgs e)
        {
            int noOfRecsInRow = 600 / MazeRows;
            int noOfRecsInCol = 600 / MazeCols;
            System.Console.WriteLine("{0},{1}", noOfRecsInRow, noOfRecsInCol);

            for (int i = 0; i < noOfRecsInRow; i++)
            {
                for (int j = 0; j < noOfRecsInCol; j++)
                {

                    Rectangle rec = new Rectangle();
                    rec.Height = noOfRecsInCol;
                    rec.Width = noOfRecsInRow;
                    if (j > 3) { rec.Fill = new SolidColorBrush(Colors.Beige); }
                    else { rec.Fill = new SolidColorBrush(Colors.Black); }
                    Canvas.SetTop(rec, i * noOfRecsInCol);
                    Canvas.SetLeft(rec, j * noOfRecsInRow);
                    myCanvas.Children.Add(rec);

                }
            }
        }
    }
}