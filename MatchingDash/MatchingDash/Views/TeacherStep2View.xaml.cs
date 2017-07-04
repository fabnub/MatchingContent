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
    /// Interaction logic for TeacherStep2View.xaml
    /// </summary>
    public partial class TeacherStep2View : DockManager
    {
        int count = 0;
        public TeacherStep2View()
        {
            InitializeComponent();
        }
        private void DockManager_Closed(object sender, EventArgs e)
        {
            //SimpleIoc.Default.Unregister<MainMenu>();
        }
        private void Grid_TextInput(object sender, TextCompositionEventArgs e)
        {
            
        }
        private void PeopleName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ItemCollection myresult = Record.Items;
            //  CollectionView _resultView=new
            ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
            _resultView.Filter = new Predicate<object>(ResultTeacherFilter);
            _resultView.Refresh();
        }
        private bool ResultTeacherFilter(object item)
        {
            // ItemCollection myresult = resultgrid.Items;
            TeacherStep2 customer = item as TeacherStep2;

            bool resultat = customer.FirstName.ToLower().Contains(PeopleName.Text.ToLower());
            if (!resultat)
                resultat = customer.LastName.ToLower().Contains(PeopleName.Text.ToLower());
            return resultat;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count> 0)
            {
                count = ++count;
                if (count == 6)
                    add.IsEnabled = true;
            }

        }

        private void subject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                count = ++count;
                if (count == 6)
                    add.IsEnabled = true;
            }
        }

        private void grade_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if(e.NewValue.HasValue)
                count = ++count;
            if (count == 6)
                add.IsEnabled = true;
        }

        private void start_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            count = ++count;
            if (count == 6)
                add.IsEnabled = true;
        }

        private void end_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            count = ++count;
            if (count == 6)
                add.IsEnabled = true;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            count = 0;
            
           // stepResult.Items.Refresh();
        }
        public void TableRefresher()
        {
            stepResult.Items.Refresh();
        }
        public void MenuRefresher()
        {
            stepResult.Items.Refresh();
           
        }
        //private void Grid_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    stepResult.Items.Refresh();
        //}
    }
}
