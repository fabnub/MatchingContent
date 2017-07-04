using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MatchingDash.Model;
using MatchingDash.Helpers;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Windows;
using MatchingDash.Shared;
using MatchingDash.Views;
using MahApps.Metro.Controls;
using System.Windows.Controls;
using System.ComponentModel;
using System.Windows.Data;

namespace MatchingDash.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {
        private  IDataService _dataService;
        private  IDialogService _dialogService;
        private  INavigationDataService _navigationService;
        private List<Student> _students = null;
        public List<Student> Students
        {
            get { return _students; }
            set { _students = value; RaisePropertyChanged("Students"); }
        }
        private List<Teacher> _teachers = null;
        public List<Teacher> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; RaisePropertyChanged("Teachers"); }
        }
        /// <summary>
        /// The <see cref="MenuChecked" /> property's name.
        /// </summary>
        public const string MenuCheckedPropertyName = "MenuChecked";

        private string _menuChecked=String.Empty;

        /// <summary>
        /// Sets and gets the MenuChecked property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MenuChecked
        {
            get
            {
                return _menuChecked;
            }

            set
            {
                if (_menuChecked == value)
                {
                    return;
                }

                _menuChecked = value;
                RaisePropertyChanged(MenuCheckedPropertyName);
            }
        }
        private string _peopleName = string.Empty;
        public string PeopleName
        {
            get { return _peopleName; }
            set { _peopleName = value; RaisePropertyChanged("PeopleName"); }
        }
        private bool _isEnabledFirstName=false;
        public bool IsEnabledFirstName
        {
            get { return _isEnabledFirstName; }
            set { _isEnabledFirstName = value; RaisePropertyChanged("IsEnabledFirstName"); }
        }
        private bool _isEnabledLastName=false;
        public bool IsEnabledLastName
        {
            get { return _isEnabledLastName; }
            set { _isEnabledLastName = value; RaisePropertyChanged("IsEnabledLastName"); }
        }
        private bool _isEnabledEmail = false;
        public bool IsEnabledEmail
        {
            get { return _isEnabledEmail; }
            set { _isEnabledEmail = value; RaisePropertyChanged("IsEnabledEmail"); }
        }
        private bool _isEnabledMajor = false;
        public bool IsEnabledMajor
        {
            get { return _isEnabledMajor; }
            set { _isEnabledMajor = value; RaisePropertyChanged("IsEnabledMajor"); }
        }
        private bool _isEnabledAddress = false;
        public bool IsEnabledAddress
        {
            get { return _isEnabledAddress; }
            set { _isEnabledAddress = value; RaisePropertyChanged("IsEnabledAddress"); }
        }
        private bool _isEnabledPhone = false;
        public bool IsEnabledPhone
        {
            get { return _isEnabledPhone; }
            set { _isEnabledPhone = value; RaisePropertyChanged("IsEnabledPhone"); }
        }
        private bool _isEnabledAlternativePhone = false;
        public bool IsEnabledAlternativePhone
        {
            get { return _isEnabledAlternativePhone; }
            set { _isEnabledAlternativePhone = value; RaisePropertyChanged("IsEnabledAlternativePhone"); }
        }
        private bool _isEnabledSchedule = false;
        public bool IsEnabledSchedule
        {
            get { return _isEnabledSchedule; }
            set { _isEnabledSchedule = value; RaisePropertyChanged("IsEnabledSchedule"); }
        }
        private bool _isEnabledTransportation = false;
        public bool IsEnabledTransportation
        {
            get { return _isEnabledTransportation; }
            set { _isEnabledTransportation = value; RaisePropertyChanged("IsEnabledTransportation"); }
        }
        private bool _isEnabledDrive = false;
        public bool IsEnabledDrive
        {
            get { return _isEnabledDrive; }
            set { _isEnabledDrive = value; RaisePropertyChanged("IsEnabledDrive"); }
        }
        private bool _isEnabledTeaching = false;
        public bool IsEnabledTeaching
        {
            get { return _isEnabledTeaching; }
            set { _isEnabledTeaching = value; RaisePropertyChanged("IsEnabledTeaching"); }
        }
        private bool _isEnabledPartner = false;
        public bool IsEnabledPartner
        {
            get { return _isEnabledPartner; }
            set { _isEnabledPartner = value; RaisePropertyChanged("IsEnabledPartner"); }
        }
        private bool _isEnabledSchool = false;
        public bool IsEnabledSchool
        {
            get { return _isEnabledSchool; }
            set { _isEnabledSchool = value; RaisePropertyChanged("IsEnabledSchool"); }
        }
        private bool _isEnabledPreferredPartner = false;
        public bool IsEnabledPreferredPartner
        {
            get { return _isEnabledPreferredPartner; }
            set { _isEnabledPreferredPartner = value; RaisePropertyChanged("IsEnabledPreferredPartner"); }
        }
        private bool _isEnabledDentonDistrict = false;
        public bool IsEnabledDentonDistrict
        {
            get { return _isEnabledDentonDistrict; }
            set { _isEnabledDentonDistrict = value; RaisePropertyChanged("IsEnabledDentonDistrict"); }
        }
        private bool _isEnabledForthWorthDistrict = false;
        public bool IsEnabledForthWorthDistrict
        {
            get { return _isEnabledForthWorthDistrict; }
            set { _isEnabledForthWorthDistrict = value; RaisePropertyChanged("IsEnabledForthWorthDistrict"); }
        }
        private bool _isEnabledLewisvilleDistrict = false;
        public bool IsEnabledLewisvilleDistrict
        {
            get { return _isEnabledLewisvilleDistrict; }
            set { _isEnabledLewisvilleDistrict = value; RaisePropertyChanged("IsEnabledLewisvilleDistrict"); }
        }
        private bool _isEnabledMckinneyDistrict = false;
        public bool IsEnabledMckinneyDistrict
        {
            get { return _isEnabledMckinneyDistrict; }
            set { _isEnabledMckinneyDistrict = value; RaisePropertyChanged("IsEnabledMckinneyDistrict"); }
        }
        private bool _isEnabledAlg1 = false;
        public bool IsEnabledAlg1
        {
            get { return _isEnabledAlg1; }
            set { _isEnabledAlg1 = value; RaisePropertyChanged("IsEnabledAlg1"); }
        }
        private bool _isEnabledGeom = false;
        public bool IsEnabledGeom
        {
            get { return _isEnabledGeom; }
            set { _isEnabledGeom = value; RaisePropertyChanged("IsEnabledGeom"); }
        }
        private bool _isEnabledAlg2 = false;
        public bool IsEnabledAlg2
        {
            get { return _isEnabledAlg2; }
            set { _isEnabledAlg2 = value; RaisePropertyChanged("IsEnabledAlg2"); }
        }
        private bool _isEnabledMathModel = false;
        public bool IsEnabledMathModel
        {
            get { return _isEnabledMathModel; }
            set { _isEnabledMathModel = value; RaisePropertyChanged("IsEnabledMathModel"); }
        }
        private bool _isEnabledPreCal = false;
        public bool IsEnabledPreCal
        {
            get { return _isEnabledPreCal; }
            set { _isEnabledPreCal = value; RaisePropertyChanged("IsEnabledPreCal"); }
        }
        private bool _isEnabledBiology = false;
        public bool IsEnabledBiology
        {
            get { return _isEnabledBiology; }
            set { _isEnabledBiology = value; RaisePropertyChanged("IsEnabledBiology"); }
        }
        private bool _isEnabledAnatomyPhysiology = false;
        public bool IsEnabledAnatomyPhysiology
        {
            get { return _isEnabledAnatomyPhysiology; }
            set { _isEnabledAnatomyPhysiology = value; RaisePropertyChanged("IsEnabledAnatomyPhysiology"); }
        }
        private bool _isEnabledWillingChemestry = false;
        public bool IsEnabledWillingChemestry
        {
            get { return _isEnabledWillingChemestry; }
            set { _isEnabledWillingChemestry = value; RaisePropertyChanged("IsEnabledWillingChemestry"); }
        }
        private bool _isEnabledAnythingElse = false;
        public bool IsEnabledAnythingElse
        {
            get { return _isEnabledAnythingElse; }
            set { _isEnabledAnythingElse = value; RaisePropertyChanged("IsEnabledAnythingElse"); }
        }
        private string _FirstName ;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; RaisePropertyChanged("FirstName"); }
        }

        private string _LastName ;
        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; RaisePropertyChanged("LastName"); }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; RaisePropertyChanged("Email"); }
        }
        private string _Major;
        public string Major
        {
            get { return _Major; }
            set { _Major = value; RaisePropertyChanged("Major"); }
        }
        private string _Address ;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; RaisePropertyChanged("Address"); }
        }
        private string _year;
        public string Year
        {
            get { return _year; }
            set { _year = value; RaisePropertyChanged("Year"); }
        }
        private string _Phone ;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; RaisePropertyChanged("Phone"); }
        }
        private string _AlternativePhone ;
        public string AlternativePhone
        {
            get { return _AlternativePhone; }
            set { _AlternativePhone = value; RaisePropertyChanged("AlternativePhone"); }
        }
        private List<Availability> _Schedule ;
        public List<Availability> Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; RaisePropertyChanged("Schedule"); }
        }
        //private List<Teacher> _recordList;
        //public List<Teacher> RecordList
        //{
        //    get { return _recordList; }
        //    set { _recordList = value; RaisePropertyChanged("RecordList"); }
        //}
        private string _Transportation ;
        public string Transportation
        {
            get { return _Transportation; }
            set { _Transportation = value; RaisePropertyChanged("Transportation"); }
        }
        private string _Drive ;
        public string Drive
        {
            get { return _Drive; }
            set { _Drive = value; RaisePropertyChanged("Drive"); }
        }
        private string _Teaching ;
        public string Teaching
        {
            get { return _Teaching; }
            set { _Teaching = value; RaisePropertyChanged("Teaching"); }
        }
        private string _Partner ;
        public string Partner
        {
            get { return _Partner; }
            set { _Partner = value; RaisePropertyChanged("Partner"); }
        }
        private string _School ;
        public string School
        {
            get { return _School; }
            set { _School = value; RaisePropertyChanged("School"); }
        }
        private string _PreferredPartner;
        public string PreferredPartner
        {
            get { return _PreferredPartner; }
            set { _PreferredPartner = value; RaisePropertyChanged("PreferredPartner"); }
        }
        private int _DentonDistrict = 0;
        public int DentonDistrict
        {
            get { return _DentonDistrict; }
            set { _DentonDistrict = value; RaisePropertyChanged("DentonDistrict"); }
        }
        private int _ForthWorthDistrict = 0;
        public int ForthWorthDistrict
        {
            get { return _ForthWorthDistrict; }
            set { _ForthWorthDistrict = value; RaisePropertyChanged("ForthWorthDistrict"); }
        }
        private int _LewisvilleDistrict = 0;
        public int LewisvilleDistrict
        {
            get { return _LewisvilleDistrict; }
            set { _LewisvilleDistrict = value; RaisePropertyChanged("LewisvilleDistrict"); }
        }
        private int _MckinneyDistrict = 0;
        public int MckinneyDistrict
        {
            get { return _MckinneyDistrict; }
            set { _MckinneyDistrict = value; RaisePropertyChanged("MckinneyDistrict"); }
        }
        private int _Alg1 = 0;
        public int Alg1
        {
            get { return _Alg1; }
            set { _Alg1 = value; RaisePropertyChanged("Alg1"); }
        }
        private int _Geom = 0;
        public int Geom
        {
            get { return _Geom; }
            set { _Geom = value; RaisePropertyChanged("Geom"); }
        }
        private int _Alg2=0 ;
        public int Alg2
        {
            get { return _Alg2; }
            set { _Alg2 = value; RaisePropertyChanged("Alg2"); }
        }
        private int _MathModel = 0;
        public int MathModel
        {
            get { return _MathModel; }
            set { _MathModel = value; RaisePropertyChanged("MathModel"); }
        }
        private int _PreCal = 0;
        public int PreCal
        {
            get { return _PreCal; }
            set { _PreCal = value; RaisePropertyChanged("PreCal"); }
        }
        private int _Biology = 0;
        public int Biology
        {
            get { return _Biology; }
            set { _Biology = value; RaisePropertyChanged("Biology"); }
        }
        private int _AnatomyPhysiology = 0;
        public int AnatomyPhysiology
        {
            get { return _AnatomyPhysiology; }
            set { _AnatomyPhysiology = value; RaisePropertyChanged("AnatomyPhysiology"); }
        }
        private string _WillingChemestry;
        public string WillingChemestry
        {
            get { return _WillingChemestry; }
            set { _WillingChemestry = value; RaisePropertyChanged("WillingChemestry"); }
        }
        private string _AnythingElse ;
        public string AnythingElse
        {
            get { return _AnythingElse; }
            set { _AnythingElse = value; RaisePropertyChanged("AnythingElse"); }
        }
        private bool _isTeacher;
        public bool IsTeacher
        {
            get { return _isTeacher; }
            set { _isTeacher = value; }
        }
      //  private bool _isEnabledTeacher = false;
        //public bool IsEnabledTeacher
        //{
        //    get { return _isEnabledTeacher; }
        //    set { _isEnabledTeacher = value; RaisePropertyChanged("IsEnabledTeacher"); }
        //}
        private bool _canSave = false;
        public bool CanSave
        {
            get { return _canSave; }
            set { _canSave = value; RaisePropertyChanged("CanSave"); }
        }
        private bool _canViewRecord = false;
        public bool CanViewRecord
        {
            get { return _canViewRecord; }
            set { _canViewRecord = value; RaisePropertyChanged("CanViewRecord"); }
        }
        private bool _canViewResult = false;
        public bool CanViewResult
        {
            get { return _canViewResult; }
            set { _canViewResult = value; RaisePropertyChanged("CanViewResult"); }
        }
        public string Response{get;set;}
        private string _selectionType;
        public string SelectionType
        {
            get { return _selectionType; }
            set { _selectionType = value; RaisePropertyChanged("SelectionType"); }
        }
        public RelayCommand ExecuteSave { get; set; }
        public RelayCommand ExecuteRecord { get; set; }
        public RelayCommand ExecuteResult { get; set; }
        public RelayCommand ExecuteReset { get; set; }
        public RelayCommand RefreshRecord { get; set; }
        //public MainMenuViewModel(string MenuOption){
        //    _menuChecked = MenuOption; 
        //}
        public MainMenuViewModel(IDataService dataService,IDialogService dialogService,INavigationDataService navigationService)
        {
            _dialogService = dialogService;
            _navigationService = navigationService;
            _dataService = dataService;
            Messenger.Default.Register<NotificationMessage<DialogService>>(this, HandleMenuOption);
            ExecuteSave = new RelayCommand(Save);
            ExecuteReset = new RelayCommand(Reset);
            ExecuteRecord = new RelayCommand(LoadRecord);
            ExecuteResult = new RelayCommand(LoadResult);
            RefreshRecord = new RelayCommand(UpdateViewRecord);
            
            //HandleMenu();
        }

        private void HandleMenuOption(NotificationMessage<DialogService> message)
        {
            //throw new NotImplementedException();
           
            DialogService _DialogService = message.Content;
             _dialogService.Setvalues(_DialogService.Text,_DialogService.Timestamp);
            string MessageType = message.Notification;
            if (MessageType == "MenuOption")
            {
                if (_DialogService.Text == "OpenAddTeacher")
                {
                    IsEnabledFirstName = true;
                    IsEnabledLastName = true;
                    IsEnabledEmail = true;
                    IsEnabledMajor = true;
                    IsEnabledAddress = true;
                    IsEnabledPhone = true;
                    IsEnabledAlternativePhone = true;
                    IsEnabledSchedule = true;
                    IsEnabledTransportation = true;
                    IsEnabledDrive = true;
                    IsEnabledTeaching = true;
                    IsEnabledPartner = true;
                    IsEnabledSchool = true;
                    IsEnabledPreferredPartner = true;
                    IsEnabledDentonDistrict = true;
                    IsEnabledForthWorthDistrict = true;
                    IsEnabledLewisvilleDistrict = true;
                    IsEnabledMckinneyDistrict = true;
                    IsEnabledAnythingElse = true;
                    IsEnabledAlg1 = true;
                    IsEnabledAlg2 = true;
                    IsEnabledGeom = true;
                    IsEnabledPreCal = true;
                    IsEnabledMathModel = true;
                    IsEnabledBiology = true;
                    IsEnabledAnatomyPhysiology = true;
                    IsEnabledWillingChemestry = true;
                    CanSave = true;
                    CanViewRecord = false;
                    CanViewResult = false;
                    IsTeacher = true;
                    Schedule = this.addAvailability();
                    
                }
                if (_DialogService.Text == "OpenAddStudent")
                {
                    IsEnabledFirstName = true;
                    IsEnabledLastName = true;
                    IsEnabledEmail = true;
                    IsEnabledMajor = true;
                    IsEnabledAddress = true;
                    IsEnabledPhone = true;
                    IsEnabledAlternativePhone = true;
                    IsEnabledSchedule = true;
                    IsEnabledTransportation = true;
                    IsEnabledDrive = true;
                    IsEnabledTeaching = true;
                    IsEnabledPartner = true;
                    IsEnabledSchool = true;
                    IsEnabledPreferredPartner = true;
                    IsEnabledDentonDistrict = true;
                    IsEnabledForthWorthDistrict = true;
                    IsEnabledLewisvilleDistrict = true;
                    IsEnabledMckinneyDistrict = true;
                    IsEnabledAnythingElse = true;
                    //IsEnabledAlg1 = true;
                    //IsEnabledAlg2 = true;
                    //IsEnabledGeom = true;
                    //IsEnabledPreCal = true;
                    //IsEnabledMathModel = true;
                    //IsEnabledBiology = true;
                    //IsEnabledAnatomyPhysiology = true;
                    //IsEnabledWillingChemestry = true;
                    CanSave = true;
                    CanViewRecord = false;
                    CanViewResult = false;
                    IsTeacher = false;
                    Schedule = this.addAvailability();

                }
                if (_DialogService.Text == "OpenEdit")
                {

                }
                if (_DialogService.Text == "OpenDelete")
                {

                }
                if (_DialogService.Text == "OpenSearch")
                {

                }
                if (_DialogService.Text == "OpenPrint")
                {

                }

            }
        }
        private void getStudentCollection()
        {
            Students = _dataService.RefreshStudent().Result.ToList();
        }
        private void getTeacherCollection()
        {
            Teachers = _dataService.RefreshTeacher().Result.ToList();

        }
        private void AddNewRecord()
        {
           
            if(IsTeacher==true){
                 Teacher myteacher=new Teacher(){FirstName=FirstName,LastName=LastName,Email=Email,Major=Major,IsTeacher=true
                     ,Phone=Phone,Address=Address,AlternativePhone=AlternativePhone,Schedule=Schedule,Transportation=Transportation
                 ,WillingToDrive=Drive,WillingToTeach=Teaching,Partner=Partner,School=School,PreferedPartner=PreferredPartner,DistrictDenton=DentonDistrict,DistrictForthWorth=ForthWorthDistrict,DistrictLewisville=LewisvilleDistrict,DistrictMckinney=MckinneyDistrict
                 ,MathAlg1=Alg1,MathGeom=Geom,MathAlg2=Alg2,MathModels=MathModel,MathPreCal=PreCal,Biology=Biology,AnatomyPhysiology=AnatomyPhysiology,WillingToTeachChemestry=WillingChemestry,AnythingElseScheduling=AnythingElse};
                 Response = "false";
                 Task<string> addresponse = _dataService.AddTeacher(myteacher);                           
                 Response = addresponse.Result;
            }
            else
            {
                Student mystudent = new Student()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Major = Major,
                    IsTeacher = false
                    ,
                    Phone = Phone,
                    Address = Address,
                    AlternativePhone = AlternativePhone,
                    Schedule = Schedule,
                    Transportation = Transportation
                    ,
                    WillingToDrive = Drive,
                    WillingToTeach = Teaching,
                    Partner = Partner,
                    School = School,
                    PreferedPartner = PreferredPartner,
                    DistrictDenton = DentonDistrict,
                    DistrictForthWorth = ForthWorthDistrict,
                    DistrictLewisville = LewisvilleDistrict,
                    DistrictMckinney = MckinneyDistrict
                    ,
                    //MathAlg1 = Alg1,
                    //MathGeom = Geom,
                    //MathAlg2 = Alg2,
                    //MathModels = MathModel,
                    //MathPreCal = PreCal,
                    //Biology = Biology,
                    //AnatomyPhysiology = AnatomyPhysiology,
                    //WillingToTeachChemestry = WillingChemestry,
                    AnythingElseScheduling = AnythingElse
                };
                Response = "false";
                Task<string> addresponse = _dataService.AddStudent(mystudent);
                Response = addresponse.Result;


            }
        }
        private void Delete()
        {

        }
        private void Reset()
        {
            setdefaults();
        }
        private void Save()
        {
            //TODO progress Bar
            DialogService dia = new DialogService();
            if (_dialogService.getText()=="OpenAddTeacher")
            {
                MainMenu menu = Application.Current.Windows.OfType<MainMenu>().SingleOrDefault(x => x.IsActive);
                dia.ProgressDialog(menu, "Saving");
                AddNewRecord();
                SetIsEnabledDefaults();
                if (Response == "success")
                {
                    dia.progressTerminated(menu, "Saved");
                    CanSave = true;
                    CanSave = true;
                    CanViewRecord = true;
                    CanViewResult = true;
                    EnableFields();
                    Reset();
                }
                else
                {

                }
            }
            else if (_dialogService.getText() == "OpenAddStudent")
            {
                StudentCIView menu = Application.Current.Windows.OfType<StudentCIView>().SingleOrDefault(x => x.IsActive);
                dia.ProgressDialog(menu, "Saving");
                AddNewRecord();
                SetIsEnabledDefaults();
                if (Response == "success")
                {
                    dia.progressTerminated(menu, "Saved");
                    CanSave = true;
                    CanSave = true;
                    CanViewRecord = true;
                    CanViewResult = true;
                    EnableFields();
                    Reset();
                }
            }
            //End Progress Bar
        }
        private void UpdateRecord()
        {

        }
        private void RowSelected()
        {

        }
        private void LoadRecord()
        {
            //TODO LOAD DATA
            if (IsTeacher)
            {
                MainMenu menu = Application.Current.Windows.OfType<MainMenu>().SingleOrDefault(x => x.IsActive);
                var flyout = menu.Flyouts.Items[0] as Flyout;
                getTeacherCollection();
              //  menu.Record.ItemsSource = Students;
                //  }
                if (flyout == null)
                {
                    return;
                }
                flyout.IsOpen = !flyout.IsOpen;
            }else           
            {
                StudentCIView menu = Application.Current.Windows.OfType<StudentCIView>().SingleOrDefault(x => x.IsActive);
                var flyout = menu.Flyouts.Items[0] as Flyout;
                getStudentCollection();
             //   menu.Record.ItemsSource = Students;
                //  }
                if (flyout == null)
                {
                    return;
                }
                flyout.IsOpen = !flyout.IsOpen;
            }

        }
        private void UpdateViewRecord()
        {
            if (IsTeacher)
            {
                MainMenu menu = Application.Current.Windows.OfType<MainMenu>().SingleOrDefault(x => x.IsActive);
                ItemCollection myresult = menu.Record.Items ;
                //  CollectionView _resultView=new
                ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
                _resultView.Filter = new Predicate<object>(ResultTeacherFilter);
                _resultView.Refresh();
            }
            else
            {

            }
            
        }
        private void LoadResult()
        {
            DialogService ms = new DialogService("CI", DateTime.Now);
            var message = new NotificationMessage<DialogService>(this, ms, "ResultOption");
            ResultView menu = new ResultView();
            Messenger.Default.Send(message);
            _navigationService.OpenUI(menu);

        }
        public List<Availability> addAvailability()
        {
            List<Availability> mytime = new List<Availability>();
            mytime.Add(new Availability() { Time = "7:30-8:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "8:00-8:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "8:30-9:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "9:00-9:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "9:30-10:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "10:00-10:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "10:30-11:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "11:00-11:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "11:30-12:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "12:00-12:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "12:30-1:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "1:00-1:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "1:30-2:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "2:00-2:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "2:30-3:00", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "3:00-3:30", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            return mytime;
        }
        private void SetIsEnabledDefaults()
        {
            IsEnabledFirstName = false;
            IsEnabledLastName = false;
            IsEnabledEmail = false;
            IsEnabledMajor = false;
            IsEnabledAddress = false;
            IsEnabledPhone = false;
            IsEnabledAlternativePhone = false;
            IsEnabledSchedule = false;
            IsEnabledTransportation = false;
            IsEnabledDrive = false;
            IsEnabledTeaching = false;
            IsEnabledPartner = false;
            IsEnabledSchool = false;
            IsEnabledPreferredPartner = false;
            IsEnabledDentonDistrict = false;
            IsEnabledForthWorthDistrict = false;
            IsEnabledLewisvilleDistrict = false;
            IsEnabledMckinneyDistrict = false;
            IsEnabledAnythingElse = false;
            IsEnabledAlg1 = false;
            IsEnabledAlg2 = false;
            IsEnabledGeom = false;
            IsEnabledPreCal = false;
            IsEnabledMathModel = false;
            IsEnabledBiology = false;
            IsEnabledAnatomyPhysiology = false;
            IsEnabledWillingChemestry = false;
            CanSave = false;
            CanViewRecord = false;
            CanViewResult = false;
           
        }
        private void setdefaults()
        {
            FirstName = string.Empty;
                    LastName = string.Empty;
                    Email = string.Empty;
                    Major = string.Empty;
                
                    Phone =string.Empty;
                    Address = string.Empty;
                    AlternativePhone = string.Empty;
                   // Schedule = 
                    Transportation = string.Empty;                 
                    Drive = string.Empty;
                    Teaching = string.Empty;
                    Partner = string.Empty;
                    School = string.Empty;
                    PreferredPartner = string.Empty;
                     DentonDistrict=0;
                     ForthWorthDistrict=0;
                     LewisvilleDistrict=0;
                     MckinneyDistrict=0;
                     Alg1=0;
                    Geom=0;
                    Alg2=0;
                    MathModel=0;
                    PreCal=0;
                    Biology=0;
                    AnatomyPhysiology=0;
                    WillingChemestry=string.Empty;
                    AnythingElse = string.Empty;
        }
        private void EnableFields()
        {
            IsEnabledFirstName = true;
            IsEnabledLastName = true;
            IsEnabledEmail = true;
            IsEnabledMajor = true;
            IsEnabledAddress = true;
            IsEnabledPhone = true;
            IsEnabledAlternativePhone = true;
            IsEnabledSchedule = true;
            IsEnabledTransportation = true;
            IsEnabledDrive = true;
            IsEnabledTeaching = true;
            IsEnabledPartner = true;
            IsEnabledSchool = true;
            IsEnabledPreferredPartner = true;
            IsEnabledDentonDistrict = true;
            IsEnabledForthWorthDistrict = true;
            IsEnabledLewisvilleDistrict = true;
            IsEnabledMckinneyDistrict = true;
            IsEnabledAnythingElse = true;
            IsEnabledAlg1 = true;
            IsEnabledAlg2 = true;
            IsEnabledGeom = true;
            IsEnabledPreCal = true;
            IsEnabledMathModel = true;
            IsEnabledBiology = true;
            IsEnabledAnatomyPhysiology = true;
            IsEnabledWillingChemestry = true;
        }
        private bool ResultTeacherFilter(object item)
        {
            // ItemCollection myresult = resultgrid.Items;
            Teacher customer = item as Teacher;
            //Match matches = Regex.Match(customer.TeacherName, PeopleName.Text);
            // customer.TeacherName.Where(s=>s.)
            //     return customer.TeacherName.Contains(matches.Groups[1].Value);
            bool resultat = customer.FirstName.ToLower().Contains(PeopleName.ToLower());
            if(!resultat)
                  resultat = customer.LastName.ToLower().Contains(PeopleName.ToLower());
            return resultat;
        }
    }
}
    

