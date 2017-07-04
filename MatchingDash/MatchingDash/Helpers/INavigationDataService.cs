using MatchingDash.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MatchingDash.Helpers
{
    public interface INavigationDataService
    {
        void GoBack();
        void NavigateTo(Uri uri);
        void NavigateTo(Uri uri, object state);
        void OpenUI(DockManager o);
        void OpenWinUI(Window o);
    }
}
