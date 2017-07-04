using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchingDash.Shared;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MahApps.Metro.Controls;

namespace MatchingDash.Helpers
{
    public class NavigationDataService: INavigationDataService
    {
        private const string QueryUriKey = "";
        //private DockManager _mainFrame;
        
        private NavigationWindow _navFrame=new NavigationWindow();
        public void GoBack()
        {
            if (EnsureMainFrame() && _navFrame.CanGoBack)
            {
                _navFrame.GoBack();
               // _main
            }
        }
        public void NavigateTo(Uri pageUri)
        {
            if (EnsureMainFrame())
            {
                _navFrame.Navigate(pageUri);

            }
        }
        private bool EnsureMainFrame()
        {
            if (_navFrame != null)
            {
                return true;
            }
            _navFrame = Application.Current.MainWindow as NavigationWindow;
            return _navFrame != null;
        }



        public void NavigateTo(Uri uri, object state)
        {
            throw new NotImplementedException();
            //if (EnsureMainFrame())
            //{
            //    //_Uri newuri
            //}
        }
        public void OpenUI(DockManager o){
            o.ShowDialog();
        }
        public void OpenWinUI(Window o)
        {
            o.ShowDialog();
        }
        public void ShowSecond(DockManager o, int index)
        {
            o.ToggleFlyout(index);
        }
      
    }
}
