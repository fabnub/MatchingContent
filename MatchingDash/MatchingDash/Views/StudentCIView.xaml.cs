using MatchingDash.Model;
using MatchingDash.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MatchingDash.Views
{
    /// <summary>
    /// Interaction logic for StudentCIView.xaml
    /// </summary>
    public partial class StudentCIView : DockManager
    {
        public StudentCIView()
        {
            InitializeComponent();
        }
        private void DockManager_Closed(object sender, EventArgs e)
        {
            //SimpleIoc.Default.Unregister<MainMenu>();
        }

        private void PeopleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ItemCollection myresult = Record.Items;
            //  CollectionView _resultView=new
            ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
            _resultView.Filter = new Predicate<object>(ResultStudentFilter);
            _resultView.Refresh();
        }
        private bool ResultStudentFilter(object item)
        {
            Student customer = item as Student;

            bool resultat = customer.FirstName.ToLower().Contains(PeopleName.Text.ToLower());
            if (!resultat)
                resultat = customer.LastName.ToLower().Contains(PeopleName.Text.ToLower());
            return resultat;
        }
    }
}
