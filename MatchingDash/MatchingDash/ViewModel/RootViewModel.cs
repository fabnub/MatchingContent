using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MatchingDash.Model;
using MatchingDash.Helpers;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Messaging;
using MatchingDash.Views;
using Microsoft.Win32;

namespace MatchingDash.ViewModel
{
    public class RootViewModel:ViewModelBase
    {
        private OpenFileDialog _file;
        private Nullable<bool> _result;
        private IDialogService _dialogService;
        private INavigationDataService _navigationService;
        private bool _isEnabledAddTeacher = false;
        private string _selectedPath;
        public string SelectedPath
        {
            get { return _selectedPath; }
            set { _selectedPath = value; }
        }
        public bool IsEnabledAddTeacher
        {
            get { return _isEnabledAddTeacher; }
            set { _isEnabledAddTeacher = value; RaisePropertyChanged("IsEnabledAddTeacher"); }
        }
        private bool _isEnabledAddStudent = false;
        public bool IsEnabledAddStudent
        {
            get { return _isEnabledAddStudent; }
            set { _isEnabledAddStudent = value; RaisePropertyChanged("IsEnabledAddStudent"); }
        }
        private bool _isEnabledEditTeacher = false;
        public bool IsEnabledEditTeacher
        {
            get { return _isEnabledEditTeacher; }
            set { _isEnabledEditTeacher = value; RaisePropertyChanged("IsEnabledEditTeacher"); }
        }
        private bool _isEnabledEditStudent = false;
        public bool IsEnabledEditStudent
        {
            get { return _isEnabledEditStudent; }
            set { _isEnabledEditStudent = value; RaisePropertyChanged("IsEnabledEditStudent"); }
        }
        private bool _isEnabledDeleteTeacher = false;
        public bool IsEnabledDeleteTeacher
        {
            get { return _isEnabledDeleteTeacher; }
            set { _isEnabledDeleteTeacher = value; RaisePropertyChanged("IsEnabledDeleteTeacher"); }
        }
        private bool _isEnabledDeleteStudent = false;
        public bool IsEnabledDeleteStudent
        {
            get { return _isEnabledDeleteStudent; }
            set { _isEnabledDeleteStudent = value; RaisePropertyChanged("IsEnabledDeleteStudent"); }
        }
        private bool _isEnabledImportStudent = false;
        public bool IsEnabledImportStudent
        {
            get { return _isEnabledImportStudent; }
            set { _isEnabledImportStudent = value; }
        }
        private bool _isEnabledImportTeacher = false;
        public bool IsEnabledImportTeacher
        {
            get { return _isEnabledImportTeacher; }
            set { _isEnabledImportTeacher = value; }
        }
        private string _isEnabledType ="";
        public string IsEnabledType
        {
            get { return _isEnabledType; }
            set { _isEnabledType = value;}
        }
        public RelayCommand GetOpenTeacher { get; set; }
        public RelayCommand GetOpenStudent{ get; set; }
        //public RelayCommand GetOpenAddTeacher { get; set; }
        //public RelayCommand GetOpenEditTeacher { get; set; }
        //public RelayCommand GetOpenDeleteTeacher { get; set; }
        //public RelayCommand GetOpenSearchTeacher { get; set; }
        //public RelayCommand GetOpenAddStudent { get; set; }
        //public RelayCommand GetOpenEditStudent { get; set; }
        //public RelayCommand GetOpenDeleteStudent { get; set; }
        //public RelayCommand GetOpenSearchStudent { get; set; }
        //public RelayCommand GetOpenPrint { get; set; }
         public RootViewModel(IDialogService dialogService,INavigationDataService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            IsEnabledAddStudent = false;
            IsEnabledAddTeacher = false;
            IsEnabledEditStudent = false;
            IsEnabledEditTeacher = false;
            IsEnabledDeleteStudent = false;
            IsEnabledDeleteTeacher = false;
            IsEnabledImportStudent = false;
            IsEnabledImportTeacher = false;
            IsEnabledType = "";
            _file = new OpenFileDialog();
            _file.FileName = "Document";
            _file.DefaultExt = ".xlsx";
            _file.Filter = "All files (*.*)|*.*";
          //  _dataService = dataService;
            Messenger.Default.Register<NotificationMessage<DialogService>>(this, HandleMenuOption);
            //GetOpenAddTeacher = new RelayCommand(OpenAddTeacher);
            //GetOpenAddStudent = new RelayCommand(OpenAddStudent);
            //GetOpenEditTeacher = new RelayCommand(OpenEditTeacher);
            //GetOpenEditStudent = new RelayCommand(OpenEditStudent);
            //GetOpenDeleteTeacher = new RelayCommand(OpenDeleteTeacher);
            //GetOpenDeleteStudent = new RelayCommand(OpenDeleteStudent);
            //GetOpenSearchTeacher = new RelayCommand(OpenSearchTeacher);
            //GetOpenSearchStudent = new RelayCommand(OpenSearchStudent);
          //  GetOpenPrint = new RelayCommand(OpenPrint);
            GetOpenStudent = new RelayCommand(OpenStudent);
            GetOpenTeacher = new RelayCommand(OpenTeacher);
             
            
            //HandleMenu();
        }
         private void HandleMenuOption(NotificationMessage<DialogService> message)
         {
             //throw new NotImplementedException();

             DialogService _DialogService = message.Content;
             //_dialogService.Setvalues(_DialogService.Text, _DialogService.Timestamp);
             string MessageType = message.Notification;
             if (MessageType == "RootOption")
             {
                 IsEnabledAddStudent = false;
                 IsEnabledAddTeacher = false;
                 IsEnabledEditStudent = false;
                 IsEnabledEditTeacher = false;
                 IsEnabledDeleteStudent = false;
                 IsEnabledDeleteTeacher = false;
                 IsEnabledImportStudent = false;
                 IsEnabledImportTeacher = false;
                 IsEnabledType = "";
                 if (_DialogService.Text == "OpenAddCI")
                 {
                     IsEnabledAddStudent = true;
                     IsEnabledAddTeacher = true;
                     IsEnabledType = "CI";
                 }
                 if (_DialogService.Text == "OpenAddTeachStep2")
                 {
                     IsEnabledAddStudent = true;
                     IsEnabledAddTeacher = true;
                     IsEnabledType = "TeachStep2";
                 }
                 if (_DialogService.Text == "OpenEditCI")
                 {
                     IsEnabledEditStudent = true;
                     IsEnabledEditTeacher = true;
                     IsEnabledType = "CI";
                 }
                 if (_DialogService.Text == "OpenDeleteCI")
                 {
                     IsEnabledDeleteStudent = true;
                     IsEnabledDeleteTeacher = true;
                     IsEnabledType = "CI";
                 }
                 if (_DialogService.Text == "OpenImportCI")
                 {
                     IsEnabledImportStudent = true;
                     IsEnabledImportTeacher = true;
                     IsEnabledType = "CI";
                 }
                 if (_DialogService.Text == "OpenPrint")
                 {

                 }
                 if (_DialogService.Text == "OpenImportStep1")
                 {
                     IsEnabledImportStudent = true;
                     IsEnabledImportTeacher = true;
                     IsEnabledType = "TeachStep1";
                 }
                 if (_DialogService.Text == "OpenImportStep2")
                 {
                     IsEnabledImportStudent = true;
                     IsEnabledImportTeacher = true;
                     IsEnabledType = "TeachStep2";
                 }
                 if (_DialogService.Text == "OpenImportCombo")
                 {
                     IsEnabledImportStudent = true;
                     IsEnabledImportTeacher = true;
                     IsEnabledType = "Combo";
                 }

             }
         }
         private void OpenAddStudent()
         {
             // string key = "OpenAdd";
             DialogService ms = new DialogService("OpenAddStudent", DateTime.Now);
             // var MainMenu=SimpleIoc.Default.GetInstance<MainMenuViewModel>();

             //  MainMenu menu=SimpleIoc.Default.GetInstance<MainMenu>();


             var message = new NotificationMessage<DialogService>(this, ms, "MenuOption");
             //  INavigationDataService openmenu = new NavigationDataService();
             //  openmenu.NavigateTo(new Uri("/Views/MainMenu.xaml",UriKind.Relative));
             //  var menu = SimpleIoc.Default.GetInstance<MainMenuViewModel>();
             StudentCIView menu = new StudentCIView();
             Messenger.Default.Send(message);

             _navigationService.OpenUI(menu);



         }
         private void OpenAddStudentStep2()
         {      
             DialogService ms = new DialogService("OpenAddStudent", DateTime.Now);         
             var message = new NotificationMessage<DialogService>(this, ms, "MenuOption");           
             StudentStep2View menu = new StudentStep2View();
             Messenger.Default.Send(message);
             _navigationService.OpenUI(menu);
         }
         
         private void OpenTeacher()
         {
             if (IsEnabledType == "CI")
             {
                 if (IsEnabledAddTeacher)
                     OpenAddTeacher();
                 if (IsEnabledEditTeacher)
                     OpenEditTeacher();
                 if (IsEnabledDeleteTeacher)
                     OpenDeleteTeacher();
                 if (IsEnabledImportTeacher)
                     OpenImportTeacherCI();
             }
             if (IsEnabledType == "TeachStep2")
             {
                 if (IsEnabledAddTeacher)
                     OpenAddTeacherStep2();
                 if (IsEnabledEditTeacher)
                     OpenEditTeacher();
                 if (IsEnabledDeleteTeacher)
                     OpenDeleteTeacher();
                 if (IsEnabledImportTeacher)
                     OpenImportTeacherStep2();
             }
             if (IsEnabledType == "TeachStep1")
             {
                 if (IsEnabledAddTeacher)
                     OpenAddTeacherStep1();
                 if (IsEnabledEditTeacher)
                     OpenEditTeacher();
                 if (IsEnabledDeleteTeacher)
                     OpenDeleteTeacher();
                 if (IsEnabledImportTeacher)
                     OpenImportTeacherStep1();
             }
             if (IsEnabledType == "Combo")
             {
                 if (IsEnabledAddTeacher)
                     OpenAddTeacherCombo();
                 if (IsEnabledEditTeacher)
                     OpenEditTeacher();
                 if (IsEnabledDeleteTeacher)
                     OpenDeleteTeacher();
                 if (IsEnabledImportTeacher)
                     OpenImportTeacherCombo();
             }

         }

        

        
        private void OpenStudent(){
            if (IsEnabledType == "CI")
            {
                if (IsEnabledAddStudent)
                    OpenAddStudent();
                if (IsEnabledEditStudent)
                    OpenEditStudent();
                if (IsEnabledDeleteStudent)
                    OpenDeleteStudent();
                if (IsEnabledImportStudent)
                    OpenImportStudentCI();
            }
            if (IsEnabledType == "TeachStep2")
            {
                if (IsEnabledAddStudent)
                    OpenAddStudentStep2();
                if (IsEnabledEditStudent)
                    OpenEditStudent();
                if (IsEnabledDeleteStudent)
                    OpenDeleteStudent();
                if (IsEnabledImportStudent)
                    OpenImportStudentStep2();
            }
            if (IsEnabledType == "TeachStep1")
            {
                if (IsEnabledAddStudent)
                    OpenAddStudentStep1();
                if (IsEnabledEditStudent)
                    OpenEditStudent();
                if (IsEnabledDeleteStudent)
                    OpenDeleteStudent();
                if (IsEnabledImportStudent)
                    OpenImportStudentStep1();
            }
            if (IsEnabledType == "Combo")
            {
                if (IsEnabledAddStudent)
                    OpenAddStudentCombo();
                if (IsEnabledEditStudent)
                    OpenEditStudent();
                if (IsEnabledDeleteStudent)
                    OpenDeleteStudent();
                if (IsEnabledImportStudent)
                    OpenImportStudentCombo();
            }
        }


       
         private void OpenAddTeacher()
         {
             DialogService ms = new DialogService("OpenAddTeacher", DateTime.Now);       
             var message = new NotificationMessage<DialogService>(this, ms, "MenuOption");            
             MainMenu menu = new MainMenu();
             Messenger.Default.Send(message);
             _navigationService.OpenUI(menu);
         }
         private void OpenAddTeacherStep2()
         {
             DialogService ms = new DialogService("OpenAddTeacher", DateTime.Now);
             var message = new NotificationMessage<DialogService>(this, ms, "MenuOption");
             TeacherStep2View menu = new TeacherStep2View();
             Messenger.Default.Send(message);
             _navigationService.OpenUI(menu);
         }
         private void OpenAddStudentStep1()
         {
             throw new NotImplementedException();
         }
         private void OpenAddStudentCombo()
         {
             throw new NotImplementedException();
         }
         private void OpenImportTeacherCI()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertTeachCI");
         }
         private void OpenImportStudentCI()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertStudentCI");
         }
         private void OpenImportTeacherStep1()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertTeachStep1");
         }
         private void OpenImportStudentCombo()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertStudentCombo");
         }
         private void OpenImportStudentStep1()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertStudentStep1");
         }
         private void OpenImportTeacherCombo()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertTeachCombo");
         }

         private void OpenImportTeacherStep2()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertTeachStep2");
         }
         private void OpenImportStudentStep2()
         {
             _result = _file.ShowDialog();
             if (_result == true)
             {
                 SelectedPath = _file.FileName;
             }
             OpenConvertCSV("ConvertStudentStep2");
         }
         private void OpenConvertCSV(string selected)
         {
             DialogService ms = new DialogService(selected, DateTime.Now);
             var message = new NotificationMessage<DialogService>(this, ms, "ConvertOption");           
             var instance = SimpleIoc.Default.GetInstance<ConvertCSV>();
             instance._path = SelectedPath;
             Messenger.Default.Send(message);
         }
         private void OpenImportTeacherprojectInstru()
         {

         }
         private void OpenAddTeacherStep1()
         {
             throw new NotImplementedException();
         }
         private void OpenAddTeacherCombo()
         {
             throw new NotImplementedException();
         }
         private void OpenEditTeacher()
         {
             //    string key = "OpenEdit";
             //  var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();     
         }
         private void OpenEditStudent()
         {
             //    string key = "OpenEdit";
             //  var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();     
         }
         private void OpenDeleteTeacher()
         {
             //     string key = "OpenDelete";
             //  var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();     
         }
         private void OpenDeleteStudent()
         {
             //     string key = "OpenDelete";
             //  var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();     
         }
         private void OpenSearchTeacher()
         {
             //   string key = "OpenSearch";
             //   var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();      
         }
         private void OpenSearchStudent()
         {
             //   string key = "OpenSearch";
             //   var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();      
         }

    }
}
