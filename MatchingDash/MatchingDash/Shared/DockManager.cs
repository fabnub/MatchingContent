using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using MahApps.Metro;

namespace MatchingDash.Shared
{
    public partial class DockManager: MetroWindow
    {
        public DockManager()
        {
            //this.RightWindowCommands
           
            //Owner = this;
            getSettings();
            
        }
        private void getSettings()
        {
       
        WindowStartupLocation = WindowStartupLocation.CenterOwner;
        ResizeMode = ResizeMode.CanResizeWithGrip;
        //Uri iconUri = new Uri("pack://MatchingDash:,,,/Pics/LeftCorner.ico", UriKind.RelativeOrAbsolute);
        //Icon = BitmapFrame.Create(iconUri);
        var theme = ThemeManager.DetectAppStyle(Application.Current);
        var accent = ThemeManager.GetAccent("Green");
        ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        ShowIconOnTitleBar = true;
        TitleCaps = true;
        FontSize = 12;
        FontWeight = FontWeights.SemiBold;
        BorderThickness = new Thickness(1);
        GlowBrush = null;
        BorderBrush = this.FindResource("AccentColorBrush") as Brush;   
        //SelectiveScrollingOrientation scroll = SelectiveScrollingOrientation.Both;
        WindowCommands sidewindow = new WindowCommands();
       // Background = new SolidColorBrush(Color.FromRgb(176, 196, 222));
        }
        public void ToggleFlyout(int index)
        {
            var flyout = this.Flyouts.Items[index] as Flyout;
            if (flyout == null)
            {
                return;
            }

            flyout.IsOpen = !flyout.IsOpen;
            flyout.Position = Position.Right;
        }
    }
}
