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
using MahApps.Metro.Controls;
using MatchingDash.Shared;
//using MahApps.Metro.Controls.Dialogs;

namespace MatchingDash.Views
{
    /// <summary>
    /// Interaction logic for RootView.xaml
    /// </summary>
    public partial class RootView : DockManager
    {
        public RootView()
        {
            InitializeComponent();
        }
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            //base.OnContentChanged(oldContent, newContent);

           // StackPanel panel = new StackPanel();
           // Button button = new Button();
           // button.Content = "Test";
           // panel.Children.Add(button);

        //    ((IAddChild)newContent).AddChild(panel);

        }
        //private async void ShowProgressDialog(object sender, RoutedEventArgs e)
        //{
        //    var controller = await this.ShowProgressAsync("Please wait...", "We are baking some cupcakes!");

        //    await Task.Delay(5000);

        //    controller.SetCancelable(true);

        //    double i = 0.0;
        //    while (i < 6.0)
        //    {
        //        double val = (i / 100.0) * 20.0;
        //        controller.SetProgress(val);
        //        controller.SetMessage("Baking cupcake: " + i + "...");

        //        if (controller.IsCanceled)
        //            break; //canceled progressdialog auto closes.

        //        i += 1.0;

        //        await Task.Delay(2000);
                
        //    }

        //    await controller.CloseAsync();

        //    if (controller.IsCanceled)
        //    {
        //        await this.ShowMessageAsync("No cupcakes!", "You stopped baking!");
        //    }
        //    else
        //    {
        //        await this.ShowMessageAsync("Cupcakes!", "Your cupcakes are finished! Enjoy!");
        //    }
        //}
    }
}
