using MatchingDash.Shared;
using MatchingDash.Views;
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
//using MatchingDash.Shared;
namespace MatchingDash
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DockManager
    {
        public MainWindow()
        {
            //object o = null;
            //base.InitializeComponent();
            InitializeComponent();
        }

        private void Tile_MouseEnter(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled)
            {
                this.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            }
        }

        private void Tile_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.IsEnabled)
            {
                this.BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            }
        }

        private void TileManager_MouseEnter(object sender, MouseEventArgs e)
        {

        }
    }
}
