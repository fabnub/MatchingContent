using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MatchingDash.Model;
using MatchingDash.Helpers;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Messaging;
using System;
using MatchingDash.Views;

namespace MatchingDash.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        ///
        private IDialogService _dialogService;
        private INavigationDataService _navigationService;
        public RelayCommand GetOpenAdd { get; set; }
        public RelayCommand GetOpenEdit { get; set; }
        public RelayCommand GetOpenDelete { get; set; }
        public RelayCommand GetOpenSearch { get; set; }
        public RelayCommand GetOpenMatch { get; set; }
        
        /// <summary>
        /// The <see cref="CanOpenAdd" /> property's name.
        /// </summary>
        public const string OPropertyName = "CanOpenAdd";

        private bool _canOpenAdd = false;

        /// <summary>
        /// Sets and gets the O property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanOpenAdd
        {
            get
            {
                return _canOpenAdd;
            }

            set
            {
                if (_canOpenAdd == value)
                {
                    return;
                }

                _canOpenAdd = value;
                RaisePropertyChanged(OPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="CanOpenEdit" /> property's name.
        /// </summary>
        public const string CanOpenEditPropertyName = "CanOpenEdit";

        private bool _canOpenEdit = false;

        /// <summary>
        /// Sets and gets the MyProperty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanOpenEdit
        {
            get
            {
                return _canOpenEdit;
            }

            set
            {
                if (_canOpenEdit == value)
                {
                    return;
                }

                _canOpenEdit = value;
                RaisePropertyChanged(CanOpenEditPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="CanOpenDelete" /> property's name.
        /// </summary>
        public const string CanOpenDeletePropertyName = "CanOpenDelete";

        private bool _canOpenDelete = false;

        /// <summary>
        /// Sets and gets the CanOpenDelete property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanOpenDelete
        {
            get
            {
                return _canOpenDelete;
            }

            set
            {
                if (_canOpenDelete == value)
                {
                    return;
                }

                _canOpenDelete = value;
                RaisePropertyChanged(CanOpenDeletePropertyName);
            }
        }
        /// <summary>
        /// The <see cref="CanOpenPrint" /> property's name.
        /// </summary>
        public const string CanOpenPrintPropertyName = "CanOpenPrint";

        private bool _canOpenPrint = false;

        /// <summary>
        /// Sets and gets the CanOpenPrint property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanOpenPrint
        {
            get
            {
                return _canOpenPrint;
            }

            set
            {
                if (_canOpenPrint == value)
                {
                    return;
                }

                _canOpenPrint = value;
                RaisePropertyChanged(CanOpenPrintPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="CanOpenSearch" /> property's name.
        /// </summary>
        public const string CanOpenSearchPropertyName = "CanOpenSearch";

        private bool _canOpenSearch = false;

        /// <summary>
        /// Sets and gets the CanOpenSearch property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CanOpenSearch
        {
            get
            {
                return _canOpenSearch;
            }

            set
            {
                if (_canOpenSearch == value)
                {
                    return;
                }

                _canOpenSearch = value;
                RaisePropertyChanged(CanOpenSearchPropertyName);
            }
        }
        /// <summary>
        /// The <see cref="CanSelect" /> property's name.
        /// </summary>
        public const string CanSelectPropertyName = "CanSelect";

        private string _canSelect;

        /// <summary>
        /// Sets and gets the CanSelect property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CanSelect
        {
            get
            {
                return _canSelect;
            }

            set
            {
                if (_canSelect == value)
                {
                    return;
                }

                _canSelect = value;
                RaisePropertyChanged(CanSelectPropertyName);
            }
        } 
        public MainViewModel(DialogService dialogService,NavigationDataService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
            GetOpenAdd = new RelayCommand(OpenAdd);
            GetOpenEdit = new RelayCommand(OpenEdit);
            GetOpenDelete = new RelayCommand(OpenDelete);
            GetOpenSearch = new RelayCommand(OpenSearch);
            GetOpenMatch = new RelayCommand(OpenMatch);

        }
       
        private void OpenAdd()
        {
           // string key = "OpenAdd";
            DialogService ms = new DialogService("OpenAdd",DateTime.Now);
           // var MainMenu=SimpleIoc.Default.GetInstance<MainMenuViewModel>();
           
          //  MainMenu menu=SimpleIoc.Default.GetInstance<MainMenu>();
           

            var message = new NotificationMessage<DialogService>(this, ms, "ImportOption");
          //  INavigationDataService openmenu = new NavigationDataService();
          //  openmenu.NavigateTo(new Uri("/Views/MainMenu.xaml",UriKind.Relative));
          //  var menu = SimpleIoc.Default.GetInstance<MainMenuViewModel>();
            ImportMenuView menu = new ImportMenuView();
            Messenger.Default.Send(message);
           
            _navigationService.OpenUI(menu);
            
            
            
        }
        private void OpenEdit()
        {
        //    string key = "OpenEdit";
          //  var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();     
        }
        private void OpenDelete()
        {
       //     string key = "OpenDelete";
          //  var MainMenu = ServiceLocator.Current.GetInstance<MainMenuViewModel>();     
        }
        private void OpenSearch()
        {
            DialogService ms = new DialogService("OpenImport", DateTime.Now);
            var message = new NotificationMessage<DialogService>(this, ms, "ImportOption");
            ImportMenuView menu = new ImportMenuView();
            Messenger.Default.Send(message);
            _navigationService.OpenUI(menu);   
        }
        private void OpenMatch()
        {
            DialogService ms = new DialogService("OpenResult", DateTime.Now);
            var message = new NotificationMessage<DialogService>(this, ms, "ImportOption");
           //ResultView menu = new ResultView();
            ImportMenuView menu = new ImportMenuView();
            Messenger.Default.Send(message);
            _navigationService.OpenUI(menu);   
        }
    }
}