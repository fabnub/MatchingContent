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
using System.Windows.Threading;


namespace MatchingDash.ViewModel
{
    public class ImportMenuViewModel:ViewModelBase
    {
        private IDialogService _dialogService;
        private INavigationDataService _navigationService;
        public RelayCommand GetOpenCI { get; set; }
        public RelayCommand GetOpenTeachStep1 { get; set; }
        public RelayCommand GetOpenTeachStep2 { get; set; }
        public RelayCommand GetOpenprojectInstru { get; set; }
        public RelayCommand GetOpenCombo { get; set; }
        private bool _isEnabledAdd = false;
        public bool IsEnabledAdd
        {
            get { return _isEnabledAdd; }
            set { _isEnabledAdd = value;}
        }
        private bool _isEnabledEdit = false;
        public bool IsEnabledEdit
        {
            get { return _isEnabledEdit; }
            set { _isEnabledEdit = value; }
        }
        private bool _isEnabledDelete = false;
        public bool IsEnabledDelete
        {
            get { return _isEnabledDelete; }
            set { _isEnabledDelete = value; }
        }
        private bool _isEnabledImport = false;
        public bool IsEnabledImport
        {
            get { return _isEnabledImport;}
            set { _isEnabledImport = value;}
        }
        private bool _isEnabledResult = false;
        public bool IsEnabledResult
        {
            get { return _isEnabledResult; }
            set { _isEnabledResult = value; }
        }
        private bool _isEnabledMentorTeacher = false;
        public bool IsEnabledMentorTeacher
        {
            get { return _isEnabledMentorTeacher; }
            set { _isEnabledMentorTeacher = value; }
        }
        private string _progress;
        public string progress
        {
            get { return _progress; }
            set { _progress = value; RaisePropertyChanged("progress"); }
        }
           public ImportMenuViewModel(IDialogService dialogService,INavigationDataService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            IsEnabledAdd = false;
            IsEnabledEdit = false;
            IsEnabledDelete = false;
            IsEnabledImport = false;
            IsEnabledMentorTeacher = false;
            Messenger.Default.Register<NotificationMessage<DialogService>>(this, HandleMenuOption);
            GetOpenCI = new RelayCommand(OpenCI);
            GetOpenTeachStep1 = new RelayCommand(OpenTeachStep1);
            GetOpenTeachStep2 = new RelayCommand(OpenTeachStep2);
            GetOpenprojectInstru = new RelayCommand(OpenprojectInstru);
            GetOpenCombo = new RelayCommand(OpenCombo);
           

        }
           private void HandleMenuOption(NotificationMessage<DialogService> message)
           {
               //throw new NotImplementedException();

               DialogService _DialogService = message.Content;
               _dialogService.Setvalues(_DialogService.Text, _DialogService.Timestamp);
               string MessageType = message.Notification;
               if (MessageType == "ImportOption")
               {
                   IsEnabledAdd = false;
                   IsEnabledEdit = false;
                   IsEnabledDelete = false;
                   IsEnabledImport = false;
                   IsEnabledResult = false;
                   IsEnabledMentorTeacher = false;
                   if (_DialogService.Text == "OpenImport")
                   {
                       IsEnabledImport = true;
                   }
                   if (_DialogService.Text == "OpenAdd")
                   {
                       IsEnabledAdd = true;                   
                   }
                   if (_DialogService.Text == "OpenResult")
                   {
                       IsEnabledResult = true;
                   }
               }
           }
           private void OpenCI()
           {
               if (IsEnabledAdd)
                   OpenAddCI();
               if (IsEnabledImport)
                   OpenImportCI();
               if (IsEnabledResult)
                   OpenResultCI();
               //if (IsEnabledDelete)
               //   // OpenAddTeachStep2();
               //if (IsEnabledImport)
               //  //  OpenAddprojectInstru();
               //if (IsEnabledMentorTeacher)
                 //  OpenAddMentor();

           }
        private void OpenCombo(){
            if (IsEnabledAdd)
                OpenAddCombo();
            if (IsEnabledImport)
                OpenImportCombo();
            if (IsEnabledResult)
                OpenResultCombo();
        }
           private void OpenResultCI()
           {
               DialogService ms = new DialogService("CI", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "ResultOption");
               ResultView menu = new ResultView();
               Messenger.Default.Send(message);
               menu.Loaded += (s, e) =>
               {
                   ms.ResultBarProgress(menu, (ResultViewModel)menu.DataContext);
               };
               _navigationService.OpenUI(menu);
               _navigationService.OpenUI(menu);   
           }
           private void OpenResultCombo()
           {
               DialogService ms = new DialogService("Combo", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "ResultOption");
               ResultView menu = new ResultView();
               Messenger.Default.Send(message);
               menu.Loaded += (s, e) =>
               {
                   ms.ResultBarProgress(menu, (ResultViewModel)menu.DataContext);
               };
               _navigationService.OpenUI(menu);
               _navigationService.OpenUI(menu);
           }
           private void OpenTeachStep1()
           {
               if (IsEnabledResult)
                   OpenResultTeachStep1();
               if (IsEnabledImport)
                   OpenImportTeachStep1();
           }
        /*   private delegate void UpdateProgress(DialogService ds,ResultView res, ResultViewModel vm);
           private void handlerUpdate(DialogService ds,ResultView res, ResultViewModel vm)
           {
               ds.ResultBarProgress(res, vm);
           }*/
           private void OpenResultTeachStep1()
           {
               DialogService ms = new DialogService("TeachStep1", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "ResultOption");                 
               ResultView menu = new ResultView();                   
               Messenger.Default.Send(message);
            //   UpdateProgress update=handlerUpdate;
               //Dispatcher.CurrentDispatcher.Invoke(update,DispatcherPriority.Normal);
               //handlerUpdate(ms,menu,(ResultViewModel)menu.DataContext);
    //           Dispatcher.CurrentDispatcher.Invoke(new Action(()=> ms.ResultBarProgress(menu, (ResultViewModel)menu.DataContext)), DispatcherPriority.Background);
               //handlerUpdate(ms, menu, (ResultViewModel)menu.DataContext);
               
              menu.Loaded += (s, e) =>
               {
                   ms.ResultBarProgress(menu, (ResultViewModel)menu.DataContext);
               };               
               _navigationService.OpenUI(menu);
                 
           }
           private void OpenTeachStep2()
           {
               if (IsEnabledAdd)
                   OpenAddTeachStep2();
               if (IsEnabledImport)
                   OpenImportTeachStep2();
               if (IsEnabledResult)
                   OpenResultStep2();
           }

           private void OpenResultStep2()
           {
               DialogService ms = new DialogService("TeachStep2", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "ResultOption");
               ResultView menu = new ResultView();
               Messenger.Default.Send(message);
               menu.Loaded += (s, e) =>
               {
                   ms.ResultBarProgress(menu, (ResultViewModel)menu.DataContext);
               };
               _navigationService.OpenUI(menu);
               _navigationService.OpenUI(menu);   
           }
           private void OpenprojectInstru()
           {
               if (IsEnabledImport)
                   OpenImportprojectInstru();
           }

           private void OpenAddCI()
           {
               // string key = "OpenAdd";
               DialogService ms = new DialogService("OpenAddCI", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");            
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu);
           }
           private void OpenAddCombo()
           {
               // string key = "OpenAdd";
               DialogService ms = new DialogService("OpenAddCombo", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu);
           }
           private void OpenAddTeachStep1()
           {
               DialogService ms = new DialogService("OpenAddTeachStep1", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu);  
           }
           private void OpenAddTeachStep2()
           {
               DialogService ms = new DialogService("OpenAddTeachStep2", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu); 
           }
           private void OpenAddprojectInstru()
           {
               DialogService ms = new DialogService("OpenAddProjectInstru", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu);  
           }
           private void OpenAddMentor()
           {
               //    string key = "OpenPrint";
               //   var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();
           }
           private void OpenImportCI()
           {
               DialogService ms = new DialogService("OpenImportCI", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu);  
           }
           private void OpenImportTeachStep1()
           {
               DialogService ms = new DialogService("OpenImportStep1", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu);  
           }
           private void OpenImportTeachStep2()
           {
               DialogService ms = new DialogService("OpenImportStep2", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu);  
           }
           private void OpenImportprojectInstru()
           {
               //    string key = "OpenPrint";
               //   var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();
           }
           private void OpenImportCombo()
           {
               DialogService ms = new DialogService("OpenImportCombo", DateTime.Now);
               var message = new NotificationMessage<DialogService>(this, ms, "RootOption");
               RootView menu = new RootView();
               Messenger.Default.Send(message);
               _navigationService.OpenUI(menu); 
           }

    }
}
