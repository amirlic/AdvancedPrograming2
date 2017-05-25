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
using ClientWpf.ViewModel;

namespace ClientWpf.View
{
    /// <summary>
    /// Interaction logic for SinglePlayerMenu.xaml
    /// </summary>
    public partial class SinglePlayerMenu : Window
    {
        private SinglePlayerViewModel vm;
        public SinglePlayerMenu()
        {
            InitializeComponent();
            vm = new SinglePlayerViewModel();
            DataContext = vm;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            vm.Game();
            SinglePlayerMaze win = new SinglePlayerMaze();
            win.ShowDialog();
        }


    }
}
