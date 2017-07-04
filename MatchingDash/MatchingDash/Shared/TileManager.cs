using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace MatchingDash.Shared
{
    class TileManager: Tile
    {
       // public delegate void MouseEventHandler(object sender,  MouseEventArgs e);
       //  public  event MouseEventHandler MouseEnter;
        public TileManager()
        {
         //   MouseEnter += new MouseEventHandler(Tile_MouseEnter);
         //   MouseEnter += new MouseEventHandler(Tile_MouseLeave);
          //  Background = new SolidColorBrush(System.Drawing.Color.Blue);
            
        }
        protected void Tile_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsEnabled)
            {
                BorderBrush = new SolidColorBrush(Color.FromArgb(0, 255, 0, 0));
                BorderThickness = new System.Windows.Thickness(2);
            }
        }

        protected void Tile_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (IsEnabled)
            {
                BorderBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
                BorderThickness = new System.Windows.Thickness(2);
            }
        }
    }
}
