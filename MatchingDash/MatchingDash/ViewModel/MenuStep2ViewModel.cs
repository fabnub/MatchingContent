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
    public class MenuStep2ViewModel : ViewModelBase
    {
        private IDataService _dataService;
        private IDialogService _dialogService;
        private INavigationDataService _navigationService;
        private List<StudentStep2> _students = null;
        List<Availability> data;
        public List<StudentStep2> Students
        {
            get { return _students; }
            set { _students = value; RaisePropertyChanged("Students"); }
        }
        private List<TeacherStep2> _teachers = null;
        public List<TeacherStep2> Teachers
        {
            get { return _teachers; }
            set { _teachers = value; RaisePropertyChanged("Teachers"); }
        }
        private string _peopleName = string.Empty;
        public string PeopleName
        {
            get { return _peopleName; }
            set { _peopleName = value; RaisePropertyChanged("PeopleName"); }
        }
        private List<string> _mydays = null;
        public List<string> Mydays
        {
            get { return _mydays; }
            set { _mydays = value; RaisePropertyChanged("Mydays"); }
        }
        private string _FirstName;
        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; RaisePropertyChanged("FirstName"); }
        }

        private string _LastName;
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
        private string _course;
        public string Course
        {
            get { return _course; }
            set { _course = value; RaisePropertyChanged("Course"); }
        }
        private string _pair;
        public string Pair
        {
            get { return _pair; }
            set { _pair = value; RaisePropertyChanged("Pair"); }
        }
        private string _major;
        public string Major
        {
            get { return _major; }
            set { _major = value; RaisePropertyChanged("Major"); }
        }
        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; RaisePropertyChanged("Address"); }
        }
        private string _school;
        public string School
        {
            get { return _school; }
            set { _school = value; RaisePropertyChanged("School"); }
        }
        private string _schoolPhone;
        public string SchoolPhone
        {
            get { return _schoolPhone; }
            set { _schoolPhone = value; RaisePropertyChanged("SchoolPhone"); }
        }
        private string _Phone;
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; RaisePropertyChanged("Phone"); }
        }
        private string _AlternativePhone;
        public string AlternativePhone
        {
            get { return _AlternativePhone; }
            set { _AlternativePhone = value; RaisePropertyChanged("AlternativePhone"); }
        }
        private List<Availability> _Schedule;
        public List<Availability> Schedule
        {
            get { return _Schedule; }
            set { _Schedule = value; RaisePropertyChanged("Schedule"); }
        }
        private string _room;
        public string Room
        {
            get { return _room; }
            set { _room = value; RaisePropertyChanged("Room"); }
        }
        private string _preferredContact;
        public string PreferredContact
        {
            get { return _preferredContact; }
            set { _preferredContact = value; RaisePropertyChanged("PreferredContact"); }
        }
        private string _day;
        public string Day
        {
            get { return _day; }
            set { _day = value; RaisePropertyChanged("Day"); }
        }
        private string _subject;
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; RaisePropertyChanged("Subject"); }
        }
        private int _grade;
        public int Grade
        {
            get { return _grade; }
            set { _grade = value; RaisePropertyChanged("Grade"); }
        }
        private string _startTime;
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; RaisePropertyChanged("StartTime"); }
        }
        private string _endTime;
        public string EndTime
        {
            get { return _endTime; }
            set { _endTime = value; RaisePropertyChanged("EndTime"); }
        }
        private bool _isEnabledAddSchedule = false;
        public bool IsEnabledAddSchedule
        {
            get { return _isEnabledAddSchedule; }
            set { _isEnabledAddSchedule = value; RaisePropertyChanged("IsEnabledAddSchedule"); }
        }
        private List<Avail> _teachSchedule;
        public List<Avail> TeachSchedule
        {
            get { return _teachSchedule; }
            set { _teachSchedule = value; RaisePropertyChanged("TeachSchedule"); }
        }
        private bool _isTeacher;
        public bool IsTeacher
        {
            get { return _isTeacher; }
            set { _isTeacher = value; }
        }
        private string _Transportation;
        public string Transportation
        {
            get { return _Transportation; }
            set { _Transportation = value; RaisePropertyChanged("Transportation"); }
        }
        private string _Drive;
        public string Drive
        {
            get { return _Drive; }
            set { _Drive = value; RaisePropertyChanged("Drive"); }
        }
        private string _district;
        public string District
        {
            get { return _district; }
            set { _district = value; RaisePropertyChanged("District"); }
        }
        private string _Teaching;
        public string Teaching
        {
            get { return _Teaching; }
            set { _Teaching = value; RaisePropertyChanged("Teaching"); }
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
        private string _preferredDays;
        public string PreferredDays
        {
            get { return _preferredDays; }
            set { _preferredDays = value; RaisePropertyChanged("PreferredDays"); }
        }
        private string _year;
        public string Year
        {
            get { return _year; }
            set { _year = value; RaisePropertyChanged("Year"); }
        }
        private string _campus;
        public string Campus
        {
            get { return _campus; }
            set { _campus = value; RaisePropertyChanged("Campus"); }
        }
        private string _town;
        public string Town
        {
            get { return _town; }
            set { _town = value; RaisePropertyChanged("Town"); }
        }
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
        public string Response { get; set; }
        public RelayCommand ExecuteAddSchedule { get; set; }
        public RelayCommand ExecuteSave { get; set; }
        public RelayCommand ExecuteRecord { get; set; }
        public RelayCommand ExecuteResult { get; set; }
        public RelayCommand ExecuteReset { get; set; }
        public RelayCommand RefreshRecord { get; set; }
        public MenuStep2ViewModel(IDataService dataService, IDialogService dialogService, INavigationDataService navigationService)
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
            ExecuteAddSchedule = new RelayCommand(AddTeachSchedule);
            TeachSchedule = new List<Avail>();
            Mydays = new List<string>();
            addDays();
            setdefaults();
        }

        
        private void HandleMenuOption(NotificationMessage<DialogService> message)
        {
            //throw new NotImplementedException();

            DialogService _DialogService = message.Content;
            _dialogService.Setvalues(_DialogService.Text, _DialogService.Timestamp);
            string MessageType = message.Notification;
            if (MessageType == "MenuOption")
            {
                if (_DialogService.Text == "OpenAddTeacher")
                {
                    CanSave = true;
                    CanViewRecord = false;
                    CanViewResult = false;
                    IsTeacher = true;
                    IsEnabledAddSchedule = false;
                  //  TeachSchedule = this.addAvailability();
                }
                if (_DialogService.Text == "OpenAddStudent")
                {
                    CanSave = true;
                    CanViewRecord = false;
                    CanViewResult = false;
                    IsEnabledAddSchedule = false;
                    IsTeacher = false;
                    Schedule = this.addAvailability();
                }
            }
        }
        private void getStudentCollection()
        {
            Students = _dataService.RefreshStudentStep2().Result.ToList();
        }
        private void getTeacherCollection()
        {
            Teachers = _dataService.RefreshTeacherStep2().Result.ToList();

        }
        private void addDays()
        {
            Mydays.Add("Monday");
            Mydays.Add("Tuesday");
            Mydays.Add("Wednesday");
            Mydays.Add("Thursday");
            Mydays.Add("Friday");
        }
        private void AddNewRecord()
        {

            if (IsTeacher == true)
            {
                TeacherStep2 myteacher = new TeacherStep2()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Email = Email,
                    Course = Course,
                    IsTeacher = true
                    ,
                    District=District,
                    Pair=Pair,
                    Phone = Phone,
                    School = School,
                    SchoolPhone = SchoolPhone,
                    Schedule = TeachSchedule,
                    Room = Room,                   
                    PreferredContact = PreferredContact,
                    NoSchedulingDay="",
                    ClassBackToBack="",
                    AttendMentorMatching=""
                    
                };
                Response = "false";
                Task<string> addresponse = _dataService.AddTeacherStep2(myteacher);
                Response = addresponse.Result;
            }
            else
            {
                StudentStep2 mystudent = new StudentStep2()
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
                    BilingualClass="",
                    Section="",

                    WillingToDrive = Drive,
                    WillingToTeach = Teaching,
                    PreferredDays = PreferredDays,
                    Year = Year,
                    Campus = Campus,
                    Town = Town,
                    DistrictDenton = DentonDistrict,
                    DistrictForthWorth = ForthWorthDistrict,
                    DistrictLewisville = LewisvilleDistrict,
                    DistrictMckinney = MckinneyDistrict,
                    AnythingElseScheduling=""
                  
                };
                Response = "false";
                Task<string> addresponse = _dataService.AddStudentStep2(mystudent);
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
            if (_dialogService.getText() == "OpenAddTeacher")
            {
                TeacherStep2View menu = Application.Current.Windows.OfType<TeacherStep2View>().SingleOrDefault(x => x.IsActive);
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
                    menu.TableRefresher();
                }
                else
                {

                }
            }
            else if (_dialogService.getText() == "OpenAddStudent")
            {
                StudentStep2View menu = Application.Current.Windows.OfType<StudentStep2View>().SingleOrDefault(x => x.IsActive);
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
                    Schedule.Clear();
                   // Schedule = data;
                    Reset();
                    menu.TableRefresher();
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
                TeacherStep2View menu = Application.Current.Windows.OfType<TeacherStep2View>().SingleOrDefault(x => x.IsActive);
                var flyout = menu.Flyouts.Items[0] as Flyout;
                getTeacherCollection();
                //  menu.Record.ItemsSource = Students;
                //  }
                if (flyout == null)
                {
                    return;
                }
                flyout.IsOpen = !flyout.IsOpen;
            }
            else
            {
                StudentStep2View menu = Application.Current.Windows.OfType<StudentStep2View>().SingleOrDefault(x => x.IsActive);
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
                ItemCollection myresult = menu.Record.Items;
                //  CollectionView _resultView=new
                ICollectionView _resultView = CollectionViewSource.GetDefaultView(myresult);
              //  _resultView.Filter = new Predicate<object>(ResultTeacherFilter);
                _resultView.Refresh();
            }
            else
            {

            }

        }
        private void LoadResult()
        {
            DialogService ms = new DialogService("TeachStep2", DateTime.Now);
            var message = new NotificationMessage<DialogService>(this, ms, "ResultOption");
            ResultView menu = new ResultView();
            Messenger.Default.Send(message);
            _navigationService.OpenUI(menu);

        }
         public List<Availability> addAvailability()
        {
            List<Availability> mytime = new List<Availability>();
            //mytime.Clear();
            mytime.Add(new Availability() { Time = "7:30 AM-8:00 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "8:00 AM-8:30 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "8:30 AM-9:00 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "9:00 AM-9:30 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "9:30 AM-10:00 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "10:00 AM-10:30 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "10:30 AM-11:00 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "11:00 AM-11:30 AM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "11:30 AM-12:00 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "12:00 PM-12:30 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "12:30 PM-1:00 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "1:00 PM-1:30 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "1:30 PM-2:00 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "2:00 PM-2:30 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "2:30 PM-3:00 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "3:00 PM-3:30 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
            mytime.Add(new Availability() { Time = "3:30 PM-4:00 PM", Monday = false, Tuesday = false, Wednesday = false, Thursday = false, Friday = false });
           // data = mytime;
             return mytime;
        }
         private void AddTeachSchedule()
         {

             TeachSchedule.Add(new Avail() { Days = Day, Subject = Subject, Grade = Grade, StartTime = StartTime, EndTime = EndTime });
             IsEnabledAddSchedule = false;
             TeacherStep2View menu = Application.Current.Windows.OfType<TeacherStep2View>().SingleOrDefault(x => x.IsActive);
             Day = string.Empty;
             StartTime = string.Empty;
             EndTime = string.Empty;
             Subject = string.Empty;
             Grade = 0;
             menu.TableRefresher();
         }
         private void SetIsEnabledDefaults()
         {
             CanSave = false;
             CanViewRecord = false;
             CanViewResult = false;
             IsEnabledAddSchedule = false;
         }

         private void setdefaults()
         {
             Day = string.Empty;
             StartTime = string.Empty;
             EndTime = string.Empty;
             FirstName = string.Empty;
             LastName = string.Empty;
             School = string.Empty;
             SchoolPhone = string.Empty;
             Phone = string.Empty;
             AlternativePhone = string.Empty;
             Room = string.Empty;
             Email = string.Empty;
             Subject = string.Empty;
             Pair = string.Empty;
             PreferredContact = string.Empty;
             Major = string.Empty;
             Year = string.Empty; 
             Grade = 0;
             District = string.Empty;
             DentonDistrict = 0;
             LewisvilleDistrict = 0;
             MckinneyDistrict = 0;
             ForthWorthDistrict = 0;
             Transportation = string.Empty;
             Drive = string.Empty;
             PreferredDays = string.Empty;
             Campus = string.Empty;
             Teaching = string.Empty;
             TeachSchedule.Clear();            
              
         }
         private void EnableFields()
         {
         }
    }
}
