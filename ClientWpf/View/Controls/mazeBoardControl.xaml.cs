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
    /// Interaction logic for mazeBoardControl.xaml
    /// </summary>
    public partial class mazeBoardControl : UserControl
    {
        public mazeBoardControl()
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void printMaze()
        { }
        private void myCanvas_Loaded(object sender, RoutedEventArgs e)
        {
           
            Rectangle[,] mat = new Rectangle[rows, cols];

        }

}
}
