using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MatchingDash.Shared
{
    class Bordure: Border
    {
        public Bordure()
        {
            MouseEnter += new MouseEventHandler(Tile_MouseEnter);
            MouseEnter += new MouseEventHandler(Tile_MouseLeave);
        }
        protected void Tile_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsEnabled)
            {
                BorderBrush = new SolidColorBrush(Color.FromArgb(0, 255, 120, 120));
               // BorderThickness = new System.Windows.Thickness(2);
            }
        }

        protected void Tile_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsEnabled)
            {
                BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
              //  BorderThickness = new System.Windows.Thickness(2);
            }
        }
    }
}
