using MatchingDash.Shared;
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
using MatchingDash.Model;
using System.ComponentModel;
using System.Text.RegularExpressions;
using GalaSoft.MvvmLight.Ioc;
using MatchingDash.ViewModel;
using GalaSoft.MvvmLight.Command;

namespace MatchingDash.Views
{
    /// <summary>
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : DockManager
    {
        public ResultView()
        {
            InitializeComponent();
        }
        private void DockManager_Closed(object sender, EventArgs e)
        {
            //SimpleIoc.Default.Unregister<MainMenu>();
        }

        private void PeopleName_TextChanged(object sender, TextChangedEventArgs e)
       {
            if (Identity.Text == "Teacher")
            {
    
                //DataGridRow  myrow=resultgrid.ItemContainerGenerator.ContainerFromIndex
                ItemCollection myresult = resultgrid.Items;
              //  CollectionView _resultView=new
              
                ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
                _resultView.Filter = new Predicate<object>(ResultTeacherFilter);
                _resultView.Refresh();
               
            }
            if (Identity.Text == "Student")
            {
                ItemCollection myresult = resultgrid.Items;
                ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
                _resultView.Filter = new Predicate<object>(ResultStudentFilter);
                _resultView.Refresh();
            }
            
        }

        private bool ResultTeacherFilter(object item)
        {         
             // ItemCollection myresult = resultgrid.Items;
                TableResult customer = item as TableResult;
            
                bool resultat = customer.TeacherName.ToLower().Contains(PeopleName.Text.ToLower());  
               return customer.TeacherName.ToLower().Contains(PeopleName.Text.ToLower());           
        }
        private bool ResultStudentFilter(object item)
        {
            TableResult customer = item as TableResult;
            return customer.StudentName.ToLower().Contains(PeopleName.Text.ToLower());  
        }

        private void info_eff_Click(object sender, RoutedEventArgs e)
        {
            TableResult cellitem = (TableResult)resultgrid.SelectedItem;
           var instance= SimpleIoc.Default.GetInstance<ResultViewModel>();
           if (instance.ExecuteDetails.CanExecute(cellitem)) 
           instance.ExecuteDetails.Execute(cellitem);                  
        }

        private void People_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (NoIdentity.Text == "Teacher")
            {

                //DataGridRow  myrow=resultgrid.ItemContainerGenerator.ContainerFromIndex
                ItemCollection myresult = Record.Items;
                //  CollectionView _resultView=new

                ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
                _resultView.Filter = new Predicate<object>(ResultTeacherFilter);
                _resultView.Refresh();

            }
            if (NoIdentity.Text == "Student")
            {
                ItemCollection myresult = Record.Items;
                ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
                _resultView.Filter = new Predicate<object>(ResultStudentFilter);
                _resultView.Refresh();
            }
        }

        private void eff_Click(object sender, RoutedEventArgs e)
        {
            TableResult cellitem = (TableResult)Record.SelectedItem;
            var instance = SimpleIoc.Default.GetInstance<ResultViewModel>();
            if (instance.ExecuteDetails.CanExecute(cellitem))
                instance.ExecuteDetails.Execute(cellitem);   
        }

       

      
    }
}
