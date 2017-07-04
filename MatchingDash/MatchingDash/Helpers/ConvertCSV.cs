using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MatchingDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatchingDash.Helpers;
using FileHelpers;
using System.IO;
using MatchingDash.Views;
using System.Windows;
using System.Text.RegularExpressions;
using MatchingDash.Shared;

namespace MatchingDash.Helpers
{
    public class ConvertCSV : ViewModelBase
    {
        private IDataService _dataService;
        private IDialogService _dialogService;
        private INavigationDataService _navigationService;
        string default_path = Directory.GetCurrentDirectory();
        string target_path = @"\DataInfo";
        public string _path;
        private string _district,_section;
        int number,counter,idmarker=1;
        string line;
        string sPattern;
        char lastChar = '\0';
        string[] separatorName = { "," },separatorDay={",","or","-"," ","and","&"},otherSeparatorName={" "},scatterDay={" "};
        string[] names=new string[2];
        string[] grades;
        string[] subjects;
        string[] daysofschool,backs;
        string course;
        string preferred;
        string pair;
        string _classBack;
        List<string> lines;
        string Nodays,attend;
        string Response;
        bool Mon, Tue, Wed, Thu, Fri;
        List<InterpreterCSV.Avail> scheduler, schedulerAB,NoBlockSchedule;
        List<Model.Avail>adjustedScheduler;
        List<Model.Back> adjustedBackScheduler;
        List<InterpreterCSV.Back> backschedule;
        List<Availability> mytime;
        //List<string> subjects;
        //List<string> grades;
        List<InterpreterCSV.gradesubject> grade_subject;
        private string _horizSlider;
        public string HorizSlider
        {
            get { return _horizSlider; }
            set { _horizSlider = value; RaisePropertyChanged("HorizSlider"); }
        }
         private string _progress;
        public string progress
        {
            get { return _progress; }
            set { _progress = value; RaisePropertyChanged("progress"); }
        }

        public RelayCommand Execute { get; set; }
        public ConvertCSV(IDataService dataService, IDialogService dialogService,INavigationDataService navigationService ,string path)
        {
            _dialogService = dialogService;
            _dataService = dataService;
            _navigationService = navigationService;
            _path = path;
            Messenger.Default.Register<NotificationMessage<DialogService>>(this, HandleMenuOption);
           // ExecuteSave = new RelayCommand(HandleMenuOption);
        }
        private void HandleMenuOption(NotificationMessage<DialogService> message)
        {
            //throw new NotImplementedException();

            DialogService _DialogService = message.Content;
            _dialogService.Setvalues(_DialogService.Text, _DialogService.Timestamp);
            string MessageType = message.Notification;
            if (MessageType == "ConvertOption")
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);
                }
                if (!File.Exists(default_path + target_path + @"\dataToLoad.csv"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\dataToLoad.csv");
                    fs.Close();
                }
                else
                {                   
                    //January 2017 change create new empty file 
                    File.Delete(default_path + target_path + @"\dataToLoad.csv");
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\dataToLoad.csv");
                    fs.Close();
                }
                lines = new List<string>();
                counter = 0;
                System.IO.StreamReader file =
                new System.IO.StreamReader(_path);
                while ((line = file.ReadLine()) != null)
                {
                  
                    number = line.Length-1;
                    if (counter>1)
                    {
                        line = line.Remove(number);
                        lines.Add(line);
                    }
                    counter++;
                   // 
                }
                             
                File.AppendAllLines(default_path + target_path + @"\dataToLoad.csv", lines);
                if (_DialogService.Text == "ConvertTeachStep2")
                {
                    AddListTeachStep2();
                }
                if (_DialogService.Text == "ConvertStudentStep2")
                {
                    AddListStudentStep2();
                }
                if (_DialogService.Text == "ConvertTeachStep1")
                {
                    AddListTeachStep1();
                }
                if (_DialogService.Text == "ConvertStudentStep1")
                {
                    AddListStudentStep1();
                }
                if (_DialogService.Text == "ConvertTeachCI")
                {
                    AddListTeachCI();
                }
                if (_DialogService.Text == "ConvertStudentCI")
                {
                    AddListStudentCI();
                }
                if (_DialogService.Text == "ConvertTeachCombo")
                {
                    AddListTeachCombo();
                }
                if (_DialogService.Text == "ConvertStudentCombo")
                {
                    AddListStudentCombo();
                }

                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        }
        private void AddListStudentCI()
        {
            try
            {
                var engine = new FileHelperAsyncEngine<InterpreterCSV.StudentCI>();
                //             _navigationService.OpenUI(menu);
                using (engine.BeginReadFile(default_path + target_path + @"\dataToLoad.csv"))
                {

                    foreach (var record in engine)
                    {

                     //   names = record.Name.Split(separatorName, StringSplitOptions.None);
                      //  if (names.Count() == 1)
                      //      names = record.Name.Split(otherSeparatorName, StringSplitOptions.None);
                        if (record.section == "1")
                            _section = "EDSE 4000.001, Monday/Wednesday @ 3:30-4:50";
                        if (record.section == "2")
                            _section = "EDSE 4000.002, Tuesday/Thursday @ 12:30-1:50";
                       
                       
                        if (record.Transportation == "1")
                            preferred = "Yes";
                        else preferred = "No";
                        if (record.DrivingSomeone == "1")
                            pair = "Yes";
                        else pair = "No";
                        if (record.BilingualClass == "1")
                            _classBack = "Yes";
                        else _classBack = "No";
                        if (record.TeachingAlone == "1")
                            Nodays = "Yes";
                        else Nodays = "No";
                        mytime = new List<Availability>();
                        //mytime.Clear();
                        if (record.Monday700_730 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday700_730 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday700_730 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday700_730 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday700_730 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:00 AM-7:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday730_800 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday730_800 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday730_800 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday730_800 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday730_800 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:30 AM-8:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday800_830 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday800_830 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday800_830 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday800_830 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday800_830 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:00 AM-8:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday830_900 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday830_900 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday830_900 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday830_900 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday830_900 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:30 AM-9:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday900_930 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday900_930 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday900_930 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday900_930 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday900_930 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:00 AM-9:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday930_1000 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday930_1000 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday930_1000 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday930_1000 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday930_1000 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:30 AM-10:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1000_1030 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1000_1030 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1000_1030 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1000_1030 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1000_1030 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:00 AM-10:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1030_1100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1030_1100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1030_1100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1030_1100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1030_1100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:30 AM-11:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1100_1130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1100_1130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1100_1130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1100_1130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1100_1130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:00 AM-11:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1130_1200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1130_1200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1130_1200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1130_1200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1130_1200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:30 AM-12:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1200_1230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1200_1230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1200_1230 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1200_1230 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1200_1230 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:00 PM-12:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1230_100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1230_100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1230_100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1230_100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1230_100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:30 PM-1:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday100_130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday100_130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday100_130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday100_130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday100_130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:00 PM-1:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday130_200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday130_200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday130_200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday130_200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday130_200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:30 PM-2:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday200_230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday200_230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday200_230 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday200_230 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday200_230 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:00 PM-2:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday230_300 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday230_300 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday230_300 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday230_300 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday230_300 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:30 PM-3:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday300_330 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday300_330 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday300_330 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday300_330 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday300_330 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:00 PM-3:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday330_400 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday330_400 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday330_400 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday330_400 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday330_400 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:30 PM-4:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday400_430 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday400_430 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday400_430 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday400_430 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday400_430 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "4:00 PM-4:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.PreferenceDenton == string.Empty && record.PreferencePropser == string.Empty && record.PreferenceLewisville == string.Empty && record.PreferenceMckinney == string.Empty)
                        {
                            record.PreferenceDenton = "1";
                            //record.PreferenceForthWorth = "2";
                            record.PreferenceLewisville = "2";
                            record.PreferenceMckinney = "3";
                            record.PreferencePropser = "4";
                            record.PreferenceSanger = "5";
                        }
                      /*
                        if (record.PreferenceAlgebra1 == string.Empty && record.PreferenceAlgebra2 == string.Empty && record.PreferenceGeometry == string.Empty && record.PreferenceMathModels == string.Empty && record.PreferencePrecalculus == string.Empty)
                        {
                            record.PreferenceAlgebra1 = "1";
                            record.PreferenceGeometry = "2";
                            record.PreferenceAlgebra2 = "3";
                            record.PreferenceMathModels = "4";
                            record.PreferencePrecalculus = "5";
                        }
                        if (record.PreferenceBiology == string.Empty && record.PreferenceEnvironmentalScience == string.Empty && record.PreferenceAnatomyPhysiology == string.Empty && record.PreferenceAquaticScience == string.Empty)
                        {
                            record.PreferenceBiology = "1";
                            record.PreferenceAnatomyPhysiology = "2";
                            record.PreferenceAquaticScience = "3";
                            record.PreferenceEnvironmentalScience = "4";                          
                        }
                        */
                        if (record.Major == "1")
                            course = "Biology";
                        if (record.Major == "2")
                            course = "Chemistry";                       
                        if (record.Major == "3")
                            course = "Computer Science";
                        if (record.Major == "4")
                            course = "Environmental Science";
                        if (record.Major == "5")
                            course = "Math 7-12";                       
                        if (record.Major == "6")
                            course = "Physics";
                        
                      
                            StudentCI mystudent = new StudentCI()
                            {
                                FirstName = record.FirstName,
                                LastName = record.LastName,
                                Email = record.Email,
                                Major = course,
                                IsTeacher = false
                                ,
                                Phone = record.Phone,
                                Address = "N/A",
                                AlternativePhone = "N/A",
                                Schedule = mytime,
                                Transportation = preferred
                                ,
                                BilingualClass = _classBack,
                                Section = _section,

                                WillingToDrive = pair,
                                WillingToTeach = Nodays,
                                //PreferredDays =
                                //    record.PreferenceAlgebra1 + "," + record.PreferenceAlgebra2 + "," +
                                //    record.PreferenceGeometry +
                                //    "," + record.PreferenceMathModels + "," + record.PreferencePrecalculus,
                                //Year =
                                //    record.PreferenceBiology + "," + record.PreferenceAnatomyPhysiology + "," +
                                //    record.PreferenceAquaticScience +
                                //    "," + record.PreferenceEnvironmentalScience,
                                Campus = "UNT",
                                Town = idmarker.ToString(),
                                DistrictDenton = int.Parse(record.PreferenceDenton),
                                DistrictProsper = int.Parse(record.PreferencePropser),
                                DistrictLewisville = int.Parse(record.PreferenceLewisville),
                                DistrictMckinney = int.Parse(record.PreferenceMckinney),
                                DistrictSanger = int.Parse(record.PreferenceSanger),
                               
                                AnythingElseScheduling = record.AnythingElse

                            };
                            idmarker++;
                            Response = "false";
                            Task<string> addresponse = _dataService.AddStudentCI(mystudent);
                            Response = addresponse.Result;
                        }
                    }
                    names.Initialize();
                    mytime.Clear();
                    lines.Clear();
                    idmarker = 1;
              
             //   File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check your excel file data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(default_path + target_path + @"\tudentCI.txt");
             //   File.Delete(default_path + target_path + @"\tudentstep2.txt");
                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        
        }
        private void AddListStudentStep1()
        {
            try
            {
                var engine = new FileHelperAsyncEngine<InterpreterCSV.StudentStep1>();
                //             _navigationService.OpenUI(menu);
                using (engine.BeginReadFile(default_path + target_path + @"\dataToLoad.csv"))
                {

                    foreach (var record in engine)
                    {

                       // names = record.Name.Split(separatorName, StringSplitOptions.None);
                       // if (names.Count() == 1)
                       //     names = record.Name.Split(otherSeparatorName, StringSplitOptions.None);
                        names[0] = record.FirstName;
                        names[1] = record.LastName;
                        if (record.section == "1")
                            _section = "TXTX 1100.001, Monday @ 9:30-10:50";
                        if (record.section == "2")
                            _section = "TXTX 1100.002, Tuesday @ 9:30-10:50";
                        //if (record.section == "3")
                        //    _section = "TXTX 1100.003, Friday @ 9:30-10:50";
                        //if (record.section == "4")
                        //    _section = "TXTX 1100.004, Thursday @ 4:30-5:20";
                       
                        if (record.Transportation == "1")
                            preferred = "Yes";
                        else preferred = "No";
                        if (record.DrivingSomeone == "1")
                            pair = "Yes";
                        else pair = "No";
                        if (record.BilingualClass == "1")
                            _classBack = "Yes";
                        else _classBack = "No";
                        if (record.TeachingAlone == "1")
                            Nodays = "Yes";
                        else Nodays = "No";
                        mytime = new List<Availability>();
                        #region start new List of Time

                    /*    string starttime = string.Empty;
                        if (record.Monday730_800 == "1"){
                            starttime = "07:30 AM";
                        else
                        {
                            if (starttime != string.Empty)
                            {
                                
                            }

                        }*/
                        #endregion;
                        //mytime.Clear();
                        if (record.Monday700_730 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday700_730 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday700_730 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday700_730 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday700_730 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:00 AM-7:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday730_800 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday730_800 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday730_800 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday730_800 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday730_800 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:30 AM-8:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday800_830 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday800_830 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday800_830 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday800_830 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday800_830 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:00 AM-8:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday830_900 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday830_900 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday830_900 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday830_900 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday830_900 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:30 AM-9:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday900_930 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday900_930 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday900_930 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday900_930 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday900_930 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:00 AM-9:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday930_1000 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday930_1000 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday930_1000 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday930_1000 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday930_1000 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:30 AM-10:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1000_1030 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1000_1030 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1000_1030 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1000_1030 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1000_1030 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:00 AM-10:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1030_1100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1030_1100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1030_1100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1030_1100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1030_1100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:30 AM-11:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1100_1130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1100_1130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1100_1130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1100_1130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1100_1130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:00 AM-11:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1130_1200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1130_1200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1130_1200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1130_1200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1130_1200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:30 AM-12:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1200_1230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1200_1230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1200_1230 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1200_1230 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1200_1230 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:00 PM-12:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1230_100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1230_100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1230_100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1230_100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1230_100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:30 PM-1:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday100_130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday100_130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday100_130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday100_130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday100_130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:00 PM-1:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday130_200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday130_200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday130_200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday130_200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday130_200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:30 PM-2:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday200_230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday200_230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday200_230 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday200_230 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday200_230 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:00 PM-2:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday230_300 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday230_300 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday230_300 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday230_300 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday230_300 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:30 PM-3:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday300_330 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday300_330 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday300_330 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday300_330 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday300_330 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:00 PM-3:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday330_400 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday330_400 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday330_400 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday330_400 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday330_400 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:30 PM-4:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday400_430 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday400_430 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday400_430 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday400_430 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday400_430 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "4:00 PM-4:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        
                        if (record.PreferenceDenton == string.Empty && record.PreferencePropser == string.Empty && record.PreferenceLewisville == string.Empty && record.PreferenceMckinney == string.Empty
                            && record.PreferenceSanger == string.Empty)
                        {
                            record.PreferenceDenton = "1";                          
                            record.PreferenceLewisville = "2";
                            record.PreferenceMckinney = "3";
                            record.PreferencePropser = "4";
                            record.PreferenceSanger = "5";
                        }
                       
                        StudentStep1 mystudent = new StudentStep1()
                        {
                            FirstName = names[0],
                            LastName = names[1],
                            Email = record.Email,
                           
                            IsTeacher = false
                            ,
                            Phone = record.Phone,
                            Address = "N/A",
                            AlternativePhone = "N/A",
                            Schedule = mytime,
                            Transportation = preferred
                            ,
                            BilingualClass = "",
                            Section = _section,

                            WillingToDrive = pair,
                            WillingToTeach = Nodays,
                            PreferredDays = "N/A",
                            Year = "N/A",
                            Campus = "UNT",
                            Town = idmarker.ToString(),
                            DistrictDenton = int.Parse(record.PreferenceDenton),
                            DistrictProsper = int.Parse(record.PreferencePropser),
                            DistrictLewisville = int.Parse(record.PreferenceLewisville),
                            DistrictMckinney = int.Parse(record.PreferenceMckinney),
                            DistrictSanger = int.Parse(record.PreferenceSanger),
                            AnythingElseScheduling = record.AnythingElse

                        };
                        idmarker++;
                        Response = "false";
                        Task<string> addresponse = _dataService.AddStudentStep1(mystudent);
                        Response = addresponse.Result;
                    }
                    names.Initialize();
                    mytime.Clear();
                    lines.Clear();
                    idmarker = 1;
                }
       //         File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check your excel file data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(default_path + target_path + @"\tudentstep1.txt");
                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        
        }
        private void AddListStudentStep2()
        {
            try
            {
                var engine = new FileHelperAsyncEngine<InterpreterCSV.StudentStep2>();
                //             _navigationService.OpenUI(menu);
                using (engine.BeginReadFile(default_path + target_path + @"\dataToLoad.csv"))
                {
                    foreach (var record in engine)
                    {

                       // names = record.Name.Split(separatorName, StringSplitOptions.None);
                       // if (names.Count() == 1)
                      //      names = record.Name.Split(otherSeparatorName, StringSplitOptions.None);
                        if (record.section == "1")
                            _section = "TNTX 1200.001, Wednesday/Friday @ 9:00-10:50";
                        if (record.section == "2")
                            _section = "TNTX 1200.002, Thursday/Thursday @ 12:30-1:50";
                        if (record.section == "3")
                            _section = "TNTX 1200.003, Tuesday/Thursday @ 3:30-4:50"; 
                        if (record.Transportation == "1")
                            preferred = "Yes";
                        else preferred = "No";
                        if (record.DrivingSomeone == "1")
                            pair = "Yes";
                        else pair = "No";
                        if (record.BilingualClass == "1")
                            _classBack = "Yes";
                        else _classBack = "No";
                        if (record.TeachingAlone == "1")
                            Nodays = "Yes";
                        else Nodays = "No";
                        mytime = new List<Availability>();
                        //mytime.Clear();
                        if (record.Monday700_730 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday700_730 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday700_730 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday700_730 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday700_730 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:00 AM-7:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday730_800 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday730_800 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday730_800 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday730_800 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday730_800 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:30 AM-8:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday800_830 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday800_830 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday800_830 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday800_830 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday800_830 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:00 AM-8:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday830_900 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday830_900 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday830_900 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday830_900 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday830_900 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:30 AM-9:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday900_930 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday900_930 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday900_930 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday900_930 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday900_930 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:00 AM-9:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday930_1000 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday930_1000 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday930_1000 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday930_1000 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday930_1000 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:30 AM-10:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1000_1030 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1000_1030 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1000_1030 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1000_1030 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1000_1030 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:00 AM-10:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1030_1100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1030_1100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1030_1100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1030_1100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1030_1100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:30 AM-11:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1100_1130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1100_1130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1100_1130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1100_1130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1100_1130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:00 AM-11:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1130_1200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1130_1200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1130_1200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1130_1200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1130_1200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:30 AM-12:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1200_1230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1200_1230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday730_800 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday730_800 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday730_800 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:00 PM-12:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1230_100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1230_100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1230_100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1230_100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1230_100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:30 PM-1:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday100_130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday100_130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday100_130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday100_130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday100_130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:00 PM-1:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday130_200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday130_200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday130_200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday130_200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday130_200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:30 PM-2:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday200_230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday200_230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday200_230 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday200_230 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday200_230 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:00 PM-2:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday230_300 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday230_300 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday230_300 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday230_300 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday230_300 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:30 PM-3:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday300_330 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday300_330 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday300_330 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday300_330 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday300_330 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:00 PM-3:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday330_400 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday330_400 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday330_400 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday330_400 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday330_400 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:30 PM-4:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday400_430 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday400_430 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday400_430 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday400_430 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday400_430 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "4:00 PM-4:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.PreferenceDenton == string.Empty && record.PreferencePropser == string.Empty && record.PreferenceLewisville == string.Empty && record.PreferenceMckinney == string.Empty
                             && record.PreferenceSanger == string.Empty)
                        {
                            record.PreferenceDenton = "1";
                            record.PreferenceLewisville = "2";
                            record.PreferenceMckinney = "3";
                            record.PreferencePropser = "4";
                            record.PreferenceSanger = "5";
                        }
                        if (record.Major == "1")
                            course = "Mathematics";
                        if (record.Major == "2")
                            course = "Science";
                      
                        StudentStep2 mystudent = new StudentStep2()
                        {
                            FirstName = record.FirstName,
                            LastName = record.LastName,
                            Email = record.Email,
                            Major = course,
                            IsTeacher = false
                            ,
                            Phone = record.Phone,
                            Address = "N/A",
                            AlternativePhone = "N/A",
                            Schedule = mytime,
                            Transportation = preferred
                            ,
                            BilingualClass = _classBack,
                            Section = _section,

                            WillingToDrive = pair,
                            WillingToTeach = Nodays,
                            PreferredDays = "N/A",
                            Year = "N/A",
                            Campus = "UNT",
                            Town = idmarker.ToString(),
                            DistrictDenton = int.Parse(record.PreferenceDenton),
                            DistrictProsper = int.Parse(record.PreferencePropser),
                            DistrictLewisville = int.Parse(record.PreferenceLewisville),
                            DistrictMckinney = int.Parse(record.PreferenceMckinney),
                            DistrictSanger = int.Parse(record.PreferenceSanger),
                            AnythingElseScheduling = record.AnythingElse

                        };
                        idmarker++;
                        Response = "false";
                        Task<string> addresponse = _dataService.AddStudentStep2(mystudent);
                        Response = addresponse.Result;
                    }
                    names.Initialize();
                    mytime.Clear();
                    lines.Clear();
                    idmarker = 1;
                }
            //    File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check your excel file data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(default_path + target_path + @"\tudentstep2.txt");
                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        
        }
        private void AddListStudentCombo() {
            try
            {
                var engine = new FileHelperAsyncEngine<InterpreterCSV.Combo>();
                //             _navigationService.OpenUI(menu);
                using (engine.BeginReadFile(default_path + target_path + @"\dataToLoad.csv"))
                {
                    foreach (var record in engine)
                    {

                        // names = record.Name.Split(separatorName, StringSplitOptions.None);
                        // if (names.Count() == 1)
                        //      names = record.Name.Split(otherSeparatorName, StringSplitOptions.None);
                        if (record.section == "1")
                            _section = "TXTX 1300.001, Tuesday/Thursday @ 2:00-3:20";
                        if (record.section == "2")
                            _section = "ESDE 4000.001, Monday/Wednesday @ 3:30-4:50";
                        if (record.section == "3")
                            _section = "ESDE 4000.002, Tuesday/Thursday @ 12:30-1:50";
                        if (record.Transportation == "1")
                            preferred = "Yes";
                        else preferred = "No";
                        if (record.DrivingSomeone == "1")
                            pair = "Yes";
                        else pair = "No";
                        if (record.BilingualClass == "1")
                            _classBack = "Yes";
                        else _classBack = "No";
                        if (record.TeachingAlone == "1")
                            Nodays = "Yes";
                        else Nodays = "No";
                        mytime = new List<Availability>();
                        //mytime.Clear();
                        if (record.Monday700_730 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday700_730 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday700_730 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday700_730 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday700_730 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:00 AM-7:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday730_800 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday730_800 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday730_800 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday730_800 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday730_800 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "7:30 AM-8:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday800_830 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday800_830 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday800_830 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday800_830 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday800_830 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:00 AM-8:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday830_900 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday830_900 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday830_900 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday830_900 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday830_900 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "8:30 AM-9:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday900_930 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday900_930 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday900_930 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday900_930 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday900_930 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:00 AM-9:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday930_1000 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday930_1000 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday930_1000 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday930_1000 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday930_1000 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "9:30 AM-10:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1000_1030 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1000_1030 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1000_1030 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1000_1030 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1000_1030 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:00 AM-10:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1030_1100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1030_1100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1030_1100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1030_1100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1030_1100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "10:30 AM-11:00 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1100_1130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1100_1130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1100_1130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1100_1130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1100_1130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:00 AM-11:30 AM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1130_1200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1130_1200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1130_1200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1130_1200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1130_1200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "11:30 AM-12:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1200_1230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1200_1230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1200_1230 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1200_1230 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1200_1230 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:00 PM-12:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday1230_100 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday1230_100 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday1230_100 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday1230_100 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday1230_100 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "12:30 PM-1:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday100_130 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday100_130 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday100_130 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday100_130 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday100_130 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:00 PM-1:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday130_200 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday130_200 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday130_200 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday130_200 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday130_200 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "1:30 PM-2:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday200_230 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday200_230 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday200_230 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday200_230 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday200_230 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:00 PM-2:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday230_300 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday230_300 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday230_300 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday230_300 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday230_300 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "2:30 PM-3:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday300_330 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday300_330 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday300_330 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday300_330 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday300_330 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:00 PM-3:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday330_400 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday330_400 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday330_400 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday330_400 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday330_400 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "3:30 PM-4:00 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.Monday400_430 == "1")
                            Mon = true;
                        else Mon = false;
                        if (record.Tuesday400_430 == "1")
                            Tue = true;
                        else Tue = false;
                        if (record.Wednesday400_430 == "1")
                            Wed = true;
                        else Wed = false;
                        if (record.Thursday400_430 == "1")
                            Thu = true;
                        else Thu = false;
                        if (record.Friday400_430 == "1")
                            Fri = true;
                        else Fri = false;
                        mytime.Add(new Availability() { Time = "4:00 PM-4:30 PM", Monday = Mon, Tuesday = Tue, Wednesday = Wed, Thursday = Thu, Friday = Fri });
                        if (record.PreferenceDenton == string.Empty && record.PreferencePropser == string.Empty && record.PreferenceLewisville == string.Empty && record.PreferenceMckinney == string.Empty
                             && record.PreferenceSanger == string.Empty)
                        {
                            record.PreferenceDenton = "1";
                            record.PreferenceLewisville = "2";
                            record.PreferenceMckinney = "3";
                            record.PreferencePropser = "4";
                            record.PreferenceSanger = "5";
                        }
                        if (record.Major == "1")
                            course = "Mathematics";
                        else if (record.Major == "2")
                            course = "Science";
                        else if (record.Major == "3")
                            course = "4-8 Math CI Students Only";
                        else if (record.Major == "4")
                            course = "4-8 Science CI Students Only";


                        StudentStep2 mystudent = new StudentStep2()
                        {
                            FirstName = record.FirstName,
                            LastName = record.LastName,
                            Email = record.Email,
                            Major = course,
                            IsTeacher = false
                            ,
                            Phone = record.Phone,
                            Address = "N/A",
                            AlternativePhone = "N/A",
                            Schedule = mytime,
                            Transportation = preferred
                            ,
                            BilingualClass = _classBack,
                            Section = _section,

                            WillingToDrive = pair,
                            WillingToTeach = Nodays,
                            PreferredDays = "N/A",
                            Year = "N/A",
                            Campus = "UNT",
                            Town = idmarker.ToString(),
                            DistrictDenton = int.Parse(record.PreferenceDenton),
                            DistrictProsper = int.Parse(record.PreferencePropser),
                            DistrictLewisville = int.Parse(record.PreferenceLewisville),
                            DistrictMckinney = int.Parse(record.PreferenceMckinney),
                            DistrictSanger = int.Parse(record.PreferenceSanger),
                            AnythingElseScheduling = record.AnythingElse

                        };
                        idmarker++;
                        Response = "false";
                        Task<string> addresponse = _dataService.AddStudentStep2(mystudent);
                        Response = addresponse.Result;
                    }
                    names.Initialize();
                    mytime.Clear();
                    lines.Clear();
                    idmarker = 1;
                }
                //    File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check your excel file data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(default_path + target_path + @"\tudentstep2.txt");
                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        }
        private void AddListTeachStep2()
        {
            try
            {
              //  TeacherView menu = new TeacherView();
                var engine = new FileHelperAsyncEngine<InterpreterCSV.TeacherStep2>();
   //             _navigationService.OpenUI(menu);
                using(engine.BeginReadFile(default_path + target_path + @"\dataToLoad.csv")){
                //TODO progress Bar
              //  DialogService dia = new DialogService();               
                //  progress = "Step2 Loading...";
               //   HorizSlider = string.Format("{0:0}", 0);            
                //    int val = 0;
               // DockManager menu=new DockManager();
               // RootView menu = Application.Current.Windows.OfType<RootView>().SingleOrDefault(x => x.IsActive);
             //   dia.ProgressDialog(menu, "Loading...");
                foreach (var record in engine)
                {
                 //   HorizSlider = string.Format("{0:0}", val+10);
                   // progress = "In progress...";
                  //  names = record.Name.Split(separatorName, StringSplitOptions.None);
                  //  if (names.Count() == 1)
                  //      names = record.Name.Split(otherSeparatorName, StringSplitOptions.None);
                    if (record.SchoolDistrict == "1")
                        _district = "Denton";
                    if (record.SchoolDistrict == "2")
                        _district = "Lewisville";
                    if (record.SchoolDistrict == "3")
                        _district = "McKinney";
                    if (record.SchoolDistrict == "4")
                        _district = "Prosper";
                    if (record.SchoolDistrict == "5")
                        _district = "Sanger";
                    grade_subject = new List<InterpreterCSV.gradesubject>();
                    grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade1, subject = record.Subject1 });
                    grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade2, subject = record.Subject2 });
                    grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade3, subject = record.Subject3 });
                    grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade4, subject = record.Subject4 });
                    grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade5, subject = record.Subject5 });
                    grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade6, subject = record.Subject6 });
                    List<string> subject = grade_subject.Select(s => s.subject).Distinct().ToList();
                    int i = 0;
                    course = string.Empty;
                    grades = new string[6];
                    subjects = new string[6];
                    foreach (string item in subject)
                    {
                        var grade = grade_subject.Where(p => p.subject == item);
                        List<string> gs = grade.Select(s => s.grade).ToList();
                        subjects[i] = item;
                        grades[i] = string.Empty;

                        foreach (string it in gs)
                        {
                            grades[i] = it + "," + grades[i];
                        }
                        course = grades[i] + " " + subjects[i] + " | " + course;
                        i++;
                    }
                    if (record.preferredContact == "1")
                        preferred = "Email";
                    if (record.preferredContact == "2")
                        preferred = "School phone";
                    if (record.preferredContact == "3")
                        preferred = "Cell or Home phone";
                    if (record.InterestedPairStudent == "1")
                        pair = "Yes";
                    else pair = "No";
/*
                    scheduler = new List<InterpreterCSV.Avail>();
                    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period1From, EndTime = record.Period1To, Days = "Period1", Subject = record.Period1Subject, Grade = 0 });
                    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period2From, EndTime = record.Period2To, Days = "Period2", Subject = record.Period2Subject, Grade = 0 });
                    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period3From, EndTime = record.Period3To, Days = "Period3", Subject = record.Period3Subject, Grade = 0 });
                    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period4From, EndTime = record.Period4To, Days = "Period4", Subject = record.Period4Subject, Grade = 0 });
                    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period5From, EndTime = record.Period5To, Days = "Period5", Subject = record.Period5Subject, Grade = 0 });
                    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period6From, EndTime = record.Period6To, Days = "Period6", Subject = record.Period6Subject, Grade = 0 });
                    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period7From, EndTime = record.Period7To, Days = "Period7", Subject = record.Period7Subject, Grade = 0 });
                    adjustedScheduler = new List<Model.Avail>();

                    foreach (var dossier in scheduler)
                    {
                        if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Subject != "0" && (dossier.StartTime!="off" || dossier.EndTime!="off"))
                        {
                            if (dossier.EndTime == "905")
                                dossier.EndTime ="9:05 AM";
                            if (dossier.StartTime == "958")
                                dossier.StartTime = "9:58 AM";
                            if (dossier.EndTime == "1046")
                                dossier.EndTime = "10:46 AM";
                            if (dossier.StartTime == "1138")
                                dossier.StartTime = "11:38 AM";
                            if (dossier.EndTime == "1223")
                                dossier.EndTime = "12:23 PM";
                            if (dossier.StartTime == "1257")
                                dossier.StartTime = "12:57 PM";
                            if (dossier.EndTime == "142")
                                dossier.EndTime = "01:42 PM";
                            if (dossier.StartTime == "146")
                                dossier.StartTime = "01:46 PM";
                            if (dossier.EndTime == "231")
                                dossier.EndTime = "02:31 PM";
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Monday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Tuesday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Wednesday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Thursday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Friday", Subject = dossier.Subject, Grade = 0 });
                        }
                    }
                    schedulerAB = new List<InterpreterCSV.Avail>();
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod1From, EndTime = record.APeriod1To, Days = "APeriod1", Subject = record.APeriod1Subject, Grade = 20 });
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod2From, EndTime = record.APeriod2To, Days = "APeriod2", Subject = record.APeriod2Subject, Grade = 20 });
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod3From, EndTime = record.APeriod3To, Days = "APeriod3", Subject = record.APeriod3Subject, Grade = 20 });
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod4From, EndTime = record.APeriod4To, Days = "APeriod4", Subject = record.APeriod4Subject, Grade = 20 });
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod5From, EndTime = record.BPeriod5To, Days = "BPeriod5", Subject = record.BPeriod5Subject, Grade = 21 });
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod6From, EndTime = record.BPeriod6To, Days = "BPeriod6", Subject = record.BPeriod6Subject, Grade = 21 });
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod7From, EndTime = record.BPeriod7To, Days = "BPeriod7", Subject = record.BPeriod7Subject, Grade = 21 });
                    schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod8From, EndTime = record.BPeriod8To, Days = "BPeriod8", Subject = record.BPeriod8Subject, Grade = 21 });
                    foreach (var dossier in schedulerAB)
                    {
                        if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Subject != "0" && (dossier.StartTime != "off" || dossier.EndTime != "off"))
                        {
                            if (dossier.Grade == 20)
                            {
                                if (dossier.EndTime == "905")
                                    dossier.EndTime = "9:05 AM";
                                if (dossier.StartTime == "958")
                                    dossier.StartTime = "9:58 AM";
                                if (dossier.EndTime == "1046")
                                    dossier.EndTime = "10:46 AM";
                                if (dossier.StartTime == "1138")
                                    dossier.StartTime = "11:38 AM";
                                if (dossier.EndTime == "1223")
                                    dossier.EndTime = "12:23 PM";
                                if (dossier.StartTime == "1257")
                                    dossier.StartTime = "12:57 PM";
                                if (dossier.EndTime == "142")
                                    dossier.EndTime = "01:42 PM";
                                if (dossier.StartTime == "146")
                                    dossier.StartTime = "01:46 PM";
                                if (dossier.EndTime == "231")
                                    dossier.EndTime = "02:31 PM";
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Monday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Tuesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Wednesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Thursday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday", Subject = dossier.Subject, Grade = 0 });
                            //    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday | A Thursday", Subject = dossier.Subject, Grade = 0 });
                            }
                            else if (dossier.Grade == 21)
                            {
                                if (dossier.EndTime == "905")
                                    dossier.EndTime = "9:05 AM";
                                if (dossier.StartTime == "958")
                                    dossier.StartTime = "9:58 AM";
                                if (dossier.EndTime == "1046")
                                    dossier.EndTime = "10:46 AM";
                                if (dossier.StartTime == "1138")
                                    dossier.StartTime = "11:38 AM";
                                if (dossier.EndTime == "1223")
                                    dossier.EndTime = "12:23 PM";
                                if (dossier.StartTime == "1257")
                                    dossier.StartTime = "12:57 PM";
                                if (dossier.EndTime == "142")
                                    dossier.EndTime = "01:42 PM";
                                if (dossier.StartTime == "146")
                                    dossier.StartTime = "01:46 PM";
                                if (dossier.EndTime == "231")
                                    dossier.EndTime = "02:31 PM";
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Monday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Tuesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Wednesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Thursday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday", Subject = dossier.Subject, Grade = 0 });
                             //   adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday | B Thursday", Subject = dossier.Subject, Grade = 0 });
                            }
                        }
                    }
 * */
                    scheduler = new List<InterpreterCSV.Avail>();
                    if (record.TypeOfSchedule == "2")
                    {
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period1From, EndTime = record.Period1To, Days = "Period1", Subject = record.Period1Subject, Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period2From, EndTime = record.Period2To, Days = "Period2", Subject = record.Period2Subject, Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period3From, EndTime = record.Period3To, Days = "Period3", Subject = record.Period3Subject, Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period4From, EndTime = record.Period4To, Days = "Period4", Subject = record.Period4Subject, Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period5From, EndTime = record.Period5To, Days = "Period5", Subject = record.Period5Subject, Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period6From, EndTime = record.Period6To, Days = "Period6", Subject = record.Period6Subject, Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period7From, EndTime = record.Period7To, Days = "Period7", Subject = record.Period7Subject, Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period8From, EndTime = record.Period8To, Days = "Period8", Subject = record.Period8Subject, Grade = 0 });

                    }

                    adjustedScheduler = new List<Model.Avail>();

                    foreach (var dossier in scheduler)
                    {
                        if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Subject != "0")
                        {
                            if (dossier.StartTime == "0951")
                                dossier.StartTime = "09:51 AM";
                            if (dossier.StartTime == "1342")
                                dossier.StartTime = "01:42 PM";
                            if (dossier.EndTime == "1509")
                                dossier.EndTime = "03:09 PM";
                            if (dossier.StartTime == "1126")
                                dossier.StartTime = "11:26 AM";
                            if (dossier.EndTime == "1336")
                                dossier.EndTime = "01:36 PM";
                            if (dossier.EndTime == "945")
                                dossier.EndTime = "9:45 AM";
                            if (dossier.EndTime == "0945")
                                dossier.EndTime = "09:45 AM";
                            if (dossier.StartTime == "0850")
                                dossier.StartTime = "08:50 AM";
                            if (dossier.EndTime == "1120")
                                dossier.EndTime = "11:20 AM";
                            if (dossier.StartTime == "1138")
                                dossier.StartTime = "11:38 AM";
                            if (dossier.EndTime == "136")
                                dossier.EndTime = "01:36 PM";
                            if (dossier.StartTime == "1257")
                                dossier.StartTime = "12:57 PM";
                            if (dossier.EndTime == "309")
                                dossier.EndTime = "03:09 PM";
                            if (dossier.StartTime == "146")
                                dossier.StartTime = "01:46 PM";
                            if (dossier.EndTime == "231")
                                dossier.EndTime = "02:31 PM";
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Monday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Tuesday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Wednesday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Thursday", Subject = dossier.Subject, Grade = 0 });
                            adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Friday", Subject = dossier.Subject, Grade = 0 });
                        }
                    }
                    schedulerAB = new List<InterpreterCSV.Avail>();
                    if (record.TypeOfSchedule == "1")
                    {
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod1From, EndTime = record.APeriod1To, Days = "APeriod1", Subject = record.APeriod1Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod2From, EndTime = record.APeriod2To, Days = "APeriod2", Subject = record.APeriod2Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod3From, EndTime = record.APeriod3To, Days = "APeriod3", Subject = record.APeriod3Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod4From, EndTime = record.APeriod4To, Days = "APeriod4", Subject = record.APeriod4Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod5From, EndTime = record.BPeriod5To, Days = "BPeriod5", Subject = record.BPeriod5Subject, Grade = 21 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod6From, EndTime = record.BPeriod6To, Days = "BPeriod6", Subject = record.BPeriod6Subject, Grade = 21 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod7From, EndTime = record.BPeriod7To, Days = "BPeriod7", Subject = record.BPeriod7Subject, Grade = 21 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod8From, EndTime = record.BPeriod8To, Days = "BPeriod8", Subject = record.BPeriod8Subject, Grade = 21 });
                        #region Modified AB schedule logic
                        List<string> tempadjustA = schedulerAB.Where(p => p.Grade == 20).Select(k => k.Subject).Distinct().ToList();
                    List<string> tempadjustB = schedulerAB.Where(p => p.Grade == 21).Select(k => k.Subject).Distinct().ToList();
                    List<string> temp = tempadjustA.Intersect<string>(tempadjustB).ToList();
                    
                        foreach (string VARIABLE2 in (temp))
                        {
                            foreach (var VARIABLE in (schedulerAB))
                            {
                            if (VARIABLE.Subject == VARIABLE2)
                            {
                                VARIABLE.Grade = 22;                             
                            }
                            }
                        }
#endregion;
                    }
                   
                   

                    foreach (var dossier in schedulerAB)
                    {
                        if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Subject != "0")
                        {
                            if (dossier.Grade == 20)
                            {
                                if (dossier.StartTime == "0951")
                                    dossier.StartTime = "09:51 AM";
                                if (dossier.StartTime == "1342")
                                    dossier.StartTime = "01:42 PM";
                                if (dossier.EndTime == "1509")
                                    dossier.EndTime = "03:09 PM";
                                if (dossier.StartTime == "1126")
                                    dossier.StartTime = "11:26 AM";
                                if (dossier.EndTime == "1336")
                                    dossier.EndTime = "01:36 PM";
                                if (dossier.EndTime == "945")
                                    dossier.EndTime = "9:45 AM";
                                if (dossier.EndTime == "0945")
                                    dossier.EndTime = "09:45 AM";
                                if (dossier.StartTime == "0850")
                                    dossier.StartTime = "08:50 AM";
                                if (dossier.EndTime == "1120")
                                    dossier.EndTime = "11:20 AM";
                                if (dossier.StartTime == "1138")
                                    dossier.StartTime = "11:38 AM";
                                if (dossier.EndTime == "136")
                                    dossier.EndTime = "01:36 PM";
                                if (dossier.StartTime == "1257")
                                    dossier.StartTime = "12:57 PM";
                                if (dossier.EndTime == "309")
                                    dossier.EndTime = "03:09 PM";
                                if (dossier.StartTime == "146")
                                    dossier.StartTime = "01:46 PM";
                                if (dossier.EndTime == "231")
                                    dossier.EndTime = "02:31 PM";
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Monday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Tuesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Wednesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Thursday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday", Subject = dossier.Subject, Grade = 0 });
                                // adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday | A Thursday", Subject = dossier.Subject, Grade = 0 });
                            }
                            else if (dossier.Grade == 21)
                            {
                                if (dossier.StartTime == "0951")
                                    dossier.StartTime = "09:51 AM";
                                if (dossier.StartTime == "1342")
                                    dossier.StartTime = "01:42 PM";
                                if (dossier.EndTime == "1509")
                                    dossier.EndTime = "03:09 PM";
                                if (dossier.StartTime == "1126")
                                    dossier.StartTime = "11:26 AM";
                                if (dossier.EndTime == "1336")
                                    dossier.EndTime = "01:36 PM";
                                if (dossier.EndTime == "945")
                                    dossier.EndTime = "9:45 AM";
                                if (dossier.EndTime == "0945")
                                    dossier.EndTime = "09:45 AM";
                                if (dossier.StartTime == "0850")
                                    dossier.StartTime = "08:50 AM";
                                if (dossier.EndTime == "1120")
                                    dossier.EndTime = "11:20 AM";
                                if (dossier.StartTime == "1138")
                                    dossier.StartTime = "11:38 AM";
                                if (dossier.EndTime == "136")
                                    dossier.EndTime = "01:36 PM";
                                if (dossier.StartTime == "1257")
                                    dossier.StartTime = "12:57 PM";
                                if (dossier.EndTime == "309")
                                    dossier.EndTime = "03:09 PM";
                                if (dossier.StartTime == "146")
                                    dossier.StartTime = "01:46 PM";
                                if (dossier.EndTime == "231")
                                    dossier.EndTime = "02:31 PM";
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Monday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Tuesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Wednesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Thursday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday", Subject = dossier.Subject, Grade = 0 });
                                //  adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday | B Thursday", Subject = dossier.Subject, Grade = 0 });
                            }
                            else if (dossier.Grade == 22)
                            {
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Monday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Tuesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Wednesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Thursday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Friday", Subject = dossier.Subject, Grade = 0 });

                            }
                        }
                    }
                  
                    NoBlockSchedule = new List<InterpreterCSV.Avail>();
                  
                       if (record.TypeOfSchedule == "3")
                    {
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular1From, EndTime = record.Regular1To, Days = record.Regular1Days, Subject = record.Regular1Subject, Grade = 0 });
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular2From, EndTime = record.Regular2To, Days = record.Regular2Days, Subject = record.Regular2Subject, Grade = 0 });
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular3From, EndTime = record.Regular3To, Days = record.Regular3Days, Subject = record.Regular3Subject, Grade = 0 });
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular4From, EndTime = record.Regular4To, Days = record.Regular4Days, Subject = record.Regular4Subject, Grade = 0 });
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular5From, EndTime = record.Regular5To, Days = record.Regular5Days, Subject = record.Regular5Subject, Grade = 0 });
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular6From, EndTime = record.Regular6To, Days = record.Regular6Days, Subject = record.Regular6Subject, Grade = 0 });
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular7From, EndTime = record.Regular7To, Days = record.Regular7Days, Subject = record.Regular7Subject, Grade = 0 });
                        NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular8From, EndTime = record.Regular8To, Days = record.Regular8Days, Subject = record.Regular8Subject, Grade = 0 });
                }
                    // daysofschool = record.Regular1Days.Split(separatorDay, StringSplitOptions.None);
                    foreach (InterpreterCSV.Avail inventory in NoBlockSchedule)
                    {
                        if (inventory.StartTime != string.Empty && inventory.EndTime != string.Empty && inventory.Days != string.Empty)
                        {
                            daysofschool = inventory.Days.Split(scatterDay, StringSplitOptions.None);
                            foreach (string item in daysofschool)
                            {
                                if (item.ToLower() == "monday")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Monday", Subject = inventory.Subject, Grade = 0 });
                                if (item.ToLower() == "tuesday")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Tuesday", Subject = inventory.Subject, Grade = 0 });
                                if (item.ToLower() == "wednesday")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Wednesday", Subject = inventory.Subject, Grade = 0 });
                                if (item.ToLower() == "thursday")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Thursday", Subject = inventory.Subject, Grade = 0 });
                                if (item.ToLower() == "friday")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Friday", Subject = inventory.Subject, Grade = 0 });
                                if (item.ToLower() == "anyday" || item.ToLower() == "any")
                                {
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Monday", Subject = inventory.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Tuesday", Subject = inventory.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Wednesday", Subject = inventory.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Thursday", Subject = inventory.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Friday", Subject = inventory.Subject, Grade = 0 });
                                }
                            }
                            daysofschool.Initialize();
                        }
                    }
                    backschedule = new List<InterpreterCSV.Back>();

                    if (record.BackToBackType == "1")
                    {
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back1Subject, Day = record.Back1Days });
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back2Subject, Day = record.Back2Days });
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back3Subject, Day = record.Back3Days });
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back4Subject, Day = record.Back4Days });
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back5Subject, Day = record.Back5Days });
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back6Subject, Day = record.Back6Days });
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back7Subject, Day = record.Back7Days });
                        backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back8Subject, Day = record.Back8Days });
                    }
                    adjustedBackScheduler = new List<Model.Back>();
                    foreach (InterpreterCSV.Back backitem in backschedule)
                    {
                        backs = backitem.Day.Split(scatterDay, StringSplitOptions.None);
                        foreach (string dayitem in backs)
                        {
                            if (dayitem != string.Empty && (dayitem.ToLower() == "monday" || dayitem.ToLower() == "tuesday" ||
                                dayitem.ToLower() == "wednesday" || dayitem.ToLower() == "thursday" || dayitem.ToLower() == "friday"))
                                adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = dayitem });
                            if (dayitem != string.Empty && dayitem.ToLower() == "any")
                            {
                                adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Monday" });
                                adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Tuesday" });
                                adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Wednesday" });
                                adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Thursday" });
                                adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Friday" });
                            }
                        }
                        backs.Initialize();
                    }
                    if (record.TwoClassPairStudent == "1")
                        _classBack = "Yes";
                    else _classBack = "No";
                    Nodays = string.Empty;
                    if (record.NoSchedulingMonday == "1")
                        Nodays = Nodays + "Monday,";
                    if (record.NoSchedulingTuesday == "1")
                        Nodays = Nodays + "Tuesday,";
                    if (record.NoSchedulingWednesday == "1")
                        Nodays = Nodays + "Wednesday,";
                    if (record.NoSchedulingThursday == "1")
                        Nodays = Nodays + "Thursday,";
                    if (record.NoSchedulingFriday == "1")
                        Nodays = Nodays + "Friday";
                    if (record.AttendMatchingDay == "1")
                        attend = "Yes";
                    else attend = "No";
                    // var gs = grade_subject.Select(s =>new {s.grade,s.subject}).Distinct();
                    TeacherStep2 myteacher = new TeacherStep2()
                    {
                        FirstName = record.FirstName,
                        LastName = record.LastName,
                        Email = record.Email,
                        Course = course,
                        IsTeacher = true
                        ,
                        District = _district,
                        Pair = pair,
                        Phone = record.CellPhone,
                        School = record.School,
                        SchoolPhone = record.SchoolPhone,
                        Schedule = adjustedScheduler,
                        Room = record.Room,
                        PreferredContact = preferred,
                        ClassBackToBack = _classBack,
                        NoSchedulingDay = Nodays,
                        AttendMentorMatching=attend,
                        TeachCount=1,
                        BackDays=adjustedBackScheduler,
                        TypeOfSchedule=record.TypeOfSchedule,
                        IsBackToBack=record.BackToBackType
                    };
                    Response = "false";
                    Task<string> addresponse = _dataService.AddTeacherStep2(myteacher);
                    Response = addresponse.Result;
                  /*  if (Response == "success")
                    {
                        progress = "Done...";
                        HorizSlider = string.Format("{0:0}", 100);
                    }*/
                       // dia.progressTerminated(menu, "Done")              
                }
                //menu.Close();
                names.Initialize();
                subjects.Initialize();
                grades.Initialize();
                grade_subject.Clear();
              //  scheduler.Clear();
             //   schedulerAB.Clear();
                adjustedScheduler.Clear();
                adjustedBackScheduler.Clear();
                lines.Clear();
                }
      //          File.Delete(default_path + target_path + @"\dataToLoad.csv");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check your excel file data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(default_path + target_path + @"\teacherstep2.txt");
                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        }
        private void AddListTeachCI()
        {
            try
            {
               // TeacherView menu = new TeacherView();
                var engine = new FileHelperAsyncEngine<InterpreterCSV.TeacherCI>();
                //             _navigationService.OpenUI(menu);
                using (engine.BeginReadFile(default_path + target_path + @"\dataToLoad.csv"))
                {
                    //TODO progress Bar
                    //  DialogService dia = new DialogService();               
                 //   progress = "Step2 Loading...";
                //    HorizSlider = string.Format("{0:0}", 0);
                //    int val = 0;
                    // DockManager menu=new DockManager();
                    // RootView menu = Application.Current.Windows.OfType<RootView>().SingleOrDefault(x => x.IsActive);
                    //   dia.ProgressDialog(menu, "Loading...");
                    foreach (var record in engine)
                    {
                        //   HorizSlider = string.Format("{0:0}", val+10);
                        // progress = "In progress...";
                     //   names = record.Name.Split(separatorName, StringSplitOptions.None);
                     //   if (names.Count() == 1)
                     //       names = record.Name.Split(otherSeparatorName, StringSplitOptions.None);
                        if (record.SchoolDistrict == "1")
                            _district = "Denton";
                        if (record.SchoolDistrict == "2")
                            _district = "Lewisville";
                        if (record.SchoolDistrict == "3")
                            _district = "McKinney";
                        if (record.SchoolDistrict == "4")
                            _district = "Prosper";
                        if (record.SchoolDistrict == "5")
                            _district = "Sanger";
                        grade_subject = new List<InterpreterCSV.gradesubject>();
                        grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade1, subject = record.Subject1 });
                        grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade2, subject = record.Subject2 });
                        grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade3, subject = record.Subject3 });
                        grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade4, subject = record.Subject4 });
                        grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade5, subject = record.Subject5 });
                        grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade6, subject = record.Subject6 });
                        List<string> subject = grade_subject.Select(s => s.subject).Distinct().ToList();
                        int i = 0;
                        course = string.Empty;
                        grades = new string[6];
                        subjects = new string[6];
                        foreach (string item in subject)
                        {
                            var grade = grade_subject.Where(p => p.subject == item);
                            List<string> gs = grade.Select(s => s.grade).ToList();
                            subjects[i] = item;
                            grades[i] = string.Empty;

                            foreach (string it in gs)
                            {
                                grades[i] = it + "," + grades[i];
                            }
                            course = grades[i] + " " + subjects[i] + " | " + course;
                            i++;
                        }
                        if (record.preferredContactEmail == "1")
                            preferred = "Email";
                        if (record.preferredContactSchool == "1")
                            preferred = "School phone";
                        if (record.preferredContactCell == "1")
                            preferred = "Cell or Home phone";
                        if (record.InterestedPairStudent == "1")
                            pair = "Yes";
                        else pair = "No";                       
                        scheduler = new List<InterpreterCSV.Avail>();
                        if (record.TypeOfSchedule == "2")
                        {
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period1From, EndTime = record.Period1To, Days = "Period1", Subject = record.Period1Subject, Grade = 0 });
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period2From, EndTime = record.Period2To, Days = "Period2", Subject = record.Period2Subject, Grade = 0 });
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period3From, EndTime = record.Period3To, Days = "Period3", Subject = record.Period3Subject, Grade = 0 });
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period4From, EndTime = record.Period4To, Days = "Period4", Subject = record.Period4Subject, Grade = 0 });
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period5From, EndTime = record.Period5To, Days = "Period5", Subject = record.Period5Subject, Grade = 0 });
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period6From, EndTime = record.Period6To, Days = "Period6", Subject = record.Period6Subject, Grade = 0 });
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period7From, EndTime = record.Period7To, Days = "Period7", Subject = record.Period7Subject, Grade = 0 });
                            scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period8From, EndTime = record.Period8To, Days = "Period8", Subject = record.Period8Subject, Grade = 0 });

                        }
                     
                        adjustedScheduler = new List<Model.Avail>();

                        foreach (var dossier in scheduler)
                        {
                            if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Subject != "0")
                            {
                                if (dossier.StartTime == "0951")
                                    dossier.StartTime = "09:51 AM";
                                if (dossier.StartTime == "1342")
                                    dossier.StartTime = "01:42 PM";
                                if (dossier.EndTime == "1509")
                                    dossier.EndTime = "03:09 PM";
                                if (dossier.StartTime == "1126")
                                    dossier.StartTime = "11:26 AM";
                                if (dossier.EndTime == "1336")
                                    dossier.EndTime = "01:36 PM";
                                if (dossier.EndTime == "945")
                                    dossier.EndTime = "9:45 AM";
                                if (dossier.EndTime == "0945")
                                    dossier.EndTime = "09:45 AM";
                                if (dossier.StartTime == "0850")
                                    dossier.StartTime = "08:50 AM";
                                if (dossier.EndTime == "1120")
                                    dossier.EndTime = "11:20 AM";
                                if (dossier.StartTime == "1138")
                                    dossier.StartTime = "11:38 AM";
                                if (dossier.EndTime == "136")
                                    dossier.EndTime = "01:36 PM";
                                if (dossier.StartTime == "1257")
                                    dossier.StartTime = "12:57 PM";
                                if (dossier.EndTime == "309")
                                    dossier.EndTime = "03:09 PM";
                                if (dossier.StartTime == "146")
                                    dossier.StartTime = "01:46 PM";
                                if (dossier.EndTime == "231")
                                    dossier.EndTime = "02:31 PM";
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Monday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Tuesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Wednesday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Thursday", Subject = dossier.Subject, Grade = 0 });
                                adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Friday", Subject = dossier.Subject, Grade = 0 });
                            }
                        }
                        schedulerAB = new List<InterpreterCSV.Avail>();
                        if (record.TypeOfSchedule == "1")
                        {
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod1From, EndTime = record.APeriod1To, Days = "APeriod1", Subject = record.APeriod1Subject, Grade = 20 });
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod2From, EndTime = record.APeriod2To, Days = "APeriod2", Subject = record.APeriod2Subject, Grade = 20 });
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod3From, EndTime = record.APeriod3To, Days = "APeriod3", Subject = record.APeriod3Subject, Grade = 20 });
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod4From, EndTime = record.APeriod4To, Days = "APeriod4", Subject = record.APeriod4Subject, Grade = 20 });
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod5From, EndTime = record.BPeriod5To, Days = "BPeriod5", Subject = record.BPeriod5Subject, Grade = 21 });
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod6From, EndTime = record.BPeriod6To, Days = "BPeriod6", Subject = record.BPeriod6Subject, Grade = 21 });
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod7From, EndTime = record.BPeriod7To, Days = "BPeriod7", Subject = record.BPeriod7Subject, Grade = 21 });
                            schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod8From, EndTime = record.BPeriod8To, Days = "BPeriod8", Subject = record.BPeriod8Subject, Grade = 21 });
                            #region Modified AB schedule logic
                            List<string> tempadjustA = schedulerAB.Where(p => p.Grade == 20).Select(k => k.Subject).Distinct().ToList();
                            List<string> tempadjustB = schedulerAB.Where(p => p.Grade == 21).Select(k => k.Subject).Distinct().ToList();
                            List<string> temp = tempadjustA.Intersect<string>(tempadjustB).ToList();

                            foreach (string VARIABLE2 in (temp))
                            {
                                foreach (var VARIABLE in (schedulerAB))
                                {
                                    if (VARIABLE.Subject == VARIABLE2)
                                    {
                                        VARIABLE.Grade = 22;
                                    }
                                }
                            }
                            #endregion;
                        }
                            foreach (var dossier in schedulerAB)
                        {
                            if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Subject != "0")
                            {
                                if (dossier.Grade == 20)
                                {
                                    if (dossier.StartTime == "0951")
                                        dossier.StartTime = "09:51 AM";
                                    if (dossier.StartTime == "1342")
                                        dossier.StartTime = "01:42 PM";
                                    if (dossier.EndTime == "1509")
                                        dossier.EndTime = "03:09 PM";
                                    if (dossier.StartTime == "1126")
                                        dossier.StartTime = "11:26 AM";
                                    if (dossier.EndTime == "1336")
                                        dossier.EndTime = "01:36 PM";
                                    if (dossier.EndTime == "945")
                                        dossier.EndTime = "9:45 AM";
                                    if (dossier.EndTime == "0945")
                                        dossier.EndTime = "09:45 AM";
                                    if (dossier.StartTime == "0850")
                                        dossier.StartTime = "08:50 AM";
                                    if (dossier.EndTime == "1120")
                                        dossier.EndTime = "11:20 AM";
                                    if (dossier.StartTime == "1138")
                                        dossier.StartTime = "11:38 AM";
                                    if (dossier.EndTime == "136")
                                        dossier.EndTime = "01:36 PM";
                                    if (dossier.StartTime == "1257")
                                        dossier.StartTime = "12:57 PM";
                                    if (dossier.EndTime == "309")
                                        dossier.EndTime = "03:09 PM";
                                    if (dossier.StartTime == "146")
                                        dossier.StartTime = "01:46 PM";
                                    if (dossier.EndTime == "231")
                                        dossier.EndTime = "02:31 PM";
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Monday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Wednesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday", Subject = dossier.Subject, Grade = 0 });
                                   // adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday | A Thursday", Subject = dossier.Subject, Grade = 0 });
                                }
                                else if (dossier.Grade == 21)
                                {
                                    if (dossier.StartTime == "0951")
                                        dossier.StartTime = "09:51 AM";
                                    if (dossier.StartTime == "1342")
                                        dossier.StartTime = "01:42 PM";
                                    if (dossier.EndTime == "1509")
                                        dossier.EndTime = "03:09 PM";
                                    if (dossier.StartTime == "1126")
                                        dossier.StartTime = "11:26 AM";
                                    if (dossier.EndTime == "1336")
                                        dossier.EndTime = "01:36 PM";
                                    if (dossier.EndTime == "945")
                                        dossier.EndTime = "9:45 AM";
                                    if (dossier.EndTime == "0945")
                                        dossier.EndTime = "09:45 AM";
                                    if (dossier.StartTime == "0850")
                                        dossier.StartTime = "08:50 AM";
                                    if (dossier.EndTime == "1120")
                                        dossier.EndTime = "11:20 AM";
                                    if (dossier.StartTime == "1138")
                                        dossier.StartTime = "11:38 AM";
                                    if (dossier.EndTime == "136")
                                        dossier.EndTime = "01:36 PM";
                                    if (dossier.StartTime == "1257")
                                        dossier.StartTime = "12:57 PM";
                                    if (dossier.EndTime == "309")
                                        dossier.EndTime = "03:09 PM";
                                    if (dossier.StartTime == "146")
                                        dossier.StartTime = "01:46 PM";
                                    if (dossier.EndTime == "231")
                                        dossier.EndTime = "02:31 PM";
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Monday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Wednesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday", Subject = dossier.Subject, Grade = 0 });
                                  //  adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday | B Thursday", Subject = dossier.Subject, Grade = 0 });
                                }
                                else if (dossier.Grade == 22)
                                {
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Monday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Wednesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Friday", Subject = dossier.Subject, Grade = 0 });
                                  
                                }
                            }
                        }
                            NoBlockSchedule = new List<InterpreterCSV.Avail>();
                            if (record.TypeOfSchedule == "3")
                            {

                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular1From, EndTime = record.Regular1To, Days =record.Regular1Days, Subject = record.Regular1Subject, Grade = 0 });
                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular2From, EndTime = record.Regular2To, Days = record.Regular2Days, Subject = record.Regular2Subject, Grade = 0 });
                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular3From, EndTime = record.Regular3To, Days = record.Regular3Days, Subject = record.Regular3Subject, Grade = 0 });
                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular4From, EndTime = record.Regular4To, Days = record.Regular4Days, Subject = record.Regular4Subject, Grade = 0 });
                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular5From, EndTime = record.Regular5To, Days = record.Regular5Days, Subject = record.Regular5Subject, Grade = 0 });
                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular6From, EndTime = record.Regular6To, Days = record.Regular6Days, Subject = record.Regular6Subject, Grade = 0 });
                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular7From, EndTime = record.Regular7To, Days = record.Regular7Days, Subject = record.Regular7Subject, Grade = 0 });
                                NoBlockSchedule.Add(new InterpreterCSV.Avail() { StartTime = record.Regular8From, EndTime = record.Regular8To, Days = record.Regular8Days, Subject = record.Regular8Subject, Grade = 0 });
                            }
                           // daysofschool = record.Regular1Days.Split(separatorDay, StringSplitOptions.None);
                            foreach (InterpreterCSV.Avail inventory in NoBlockSchedule)
                            {
                                if (inventory.StartTime != string.Empty && inventory.EndTime != string.Empty && inventory.Days != string.Empty)
                                {
                                    daysofschool = inventory.Days.Split(scatterDay, StringSplitOptions.None);
                                    foreach (string item in daysofschool)
                                    {
                                        if (item.ToLower() == "monday")
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Monday", Subject = inventory.Subject, Grade = 0 });
                                        if (item.ToLower() == "tuesday")
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Tuesday", Subject = inventory.Subject, Grade = 0 });
                                        if (item.ToLower() == "wednesday")
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Wednesday", Subject = inventory.Subject, Grade = 0 });
                                        if (item.ToLower() == "thursday")
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Thursday", Subject = inventory.Subject, Grade = 0 });
                                        if (item.ToLower() == "friday")
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Friday", Subject = inventory.Subject, Grade = 0 });
                                        if (item.ToLower() == "anyday" || item.ToLower() == "any")
                                        {
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Monday", Subject = inventory.Subject, Grade = 0 });
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Tuesday", Subject = inventory.Subject, Grade = 0 });
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Wednesday", Subject = inventory.Subject, Grade = 0 });
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Thursday", Subject = inventory.Subject, Grade = 0 });
                                            adjustedScheduler.Add(new Model.Avail() { StartTime = inventory.StartTime, EndTime = inventory.EndTime, Days = "Friday", Subject = inventory.Subject, Grade = 0 });
                                        }
                                    }
                                    daysofschool.Initialize();
                                }
                            }
                            backschedule = new List<InterpreterCSV.Back>();
                            
                            if (record.TypeOfSchedule == "3" && record.BackToBackDays == "1")
                            {
                                backschedule.Add(new InterpreterCSV.Back() {Subject=record.Back1Subject,Day=record.Back1Days});
                                backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back2Subject, Day = record.Back2Days });
                                backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back3Subject, Day = record.Back3Days });
                                backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back4Subject, Day = record.Back4Days });
                                backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back5Subject, Day = record.Back5Days });
                                backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back6Subject, Day = record.Back6Days });
                                backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back7Subject, Day = record.Back7Days });
                                backschedule.Add(new InterpreterCSV.Back() { Subject = record.Back8Subject, Day = record.Back8Days });
                            }
                            adjustedBackScheduler = new List<Model.Back>();
                            foreach (InterpreterCSV.Back backitem in backschedule)
                            {
                                backs = backitem.Day.Split(scatterDay, StringSplitOptions.None);
                                foreach (string dayitem in backs)
                                {
                                    if (dayitem != string.Empty &&( dayitem.ToLower()=="monday" || dayitem.ToLower()=="tuesday" ||
                                        dayitem.ToLower()=="wednesday" || dayitem.ToLower()=="thursday" || dayitem.ToLower()=="friday"))
                                        adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = dayitem });
                                    if (dayitem != string.Empty && dayitem.ToLower() == "any")
                                    {
                                        adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Monday" });
                                        adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Tuesday" });
                                        adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Wednesday" });
                                        adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Thursday" });
                                        adjustedBackScheduler.Add(new Model.Back() { Subject = backitem.Subject, Day = "Friday" });
                                    }
                                }
                                backs.Initialize();
                            }
                        //if (record.TwoClassPairStudent == "1")
                        //    _classBack = "Yes";
                        //else _classBack = "No";
                        Nodays = string.Empty;
                        if (record.NoSchedulingMonday == "1")
                            Nodays = Nodays + "Monday,";
                        if (record.NoSchedulingTuesday == "1")
                            Nodays = Nodays + "Tuesday,";
                        if (record.NoSchedulingWednesday == "1")
                            Nodays = Nodays + "Wednesday,";
                        if (record.NoSchedulingThursday == "1")
                            Nodays = Nodays + "Thursday,";
                        if (record.NoSchedulingFriday == "1")
                            Nodays = Nodays + "Friday";
                        if (record.AttendMatchingDay == "1")
                            attend = "Yes";
                        else attend = "No";
                        // var gs = grade_subject.Select(s =>new {s.grade,s.subject}).Distinct();
                        TeacherCI myteacher = new TeacherCI()
                        {
                            FirstName = record.FirstName,
                            LastName = record.LastName,
                            Email = record.Email,
                            Course = course,
                            IsTeacher = true
                            ,
                            District = _district,
                            Pair = pair,
                            Phone = record.CellPhone,
                            School = record.School,
                            SchoolPhone = record.SchoolPhone,
                            Schedule = adjustedScheduler,
                            Room = record.Room,
                            PreferredContact = preferred,
                            AnythingElse=record.AnythingtoSchedule,
                            NoSchedulingDay = Nodays,
                            AttendMentorMatching = attend,
                            TeachCount = 1,
                            BackDays=adjustedBackScheduler,
                            TypeOfSchedule = record.TypeOfSchedule,
                            IsBackToBack = record.BackToBackDays

                        };
                        Response = "false";
                        Task<string> addresponse = _dataService.AddTeacherCI(myteacher);
                        Response = addresponse.Result;
                        /*  if (Response == "success")
                          {
                              progress = "Done...";
                              HorizSlider = string.Format("{0:0}", 100);
                          }*/
                        // dia.progressTerminated(menu, "Done")              
                    }
                    //menu.Close();
                    names.Initialize();
                    subjects.Initialize();
                    grades.Initialize();
                    grade_subject.Clear();
                    scheduler.Clear();
                    schedulerAB.Clear();
                    adjustedScheduler.Clear();
                    adjustedBackScheduler.Clear();
                    lines.Clear();
                }
         //       File.Delete(default_path + target_path + @"\dataToLoad.csv");

            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check your excel file data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(default_path + target_path + @"\teacherCI.txt");
                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        }
        private void AddListTeachStep1()
        {
            try
            {
               // TeacherView menu = new TeacherView();
                var engine = new FileHelperAsyncEngine<InterpreterCSV.TeacherStep1>();
                //             _navigationService.OpenUI(menu);
                using (engine.BeginReadFile(default_path + target_path + @"\dataToLoad.csv"))
                {
                    //TODO progress Bar
                    //  DialogService dia = new DialogService();               
                  //  progress = "Step2 Loading...";
                //    HorizSlider = string.Format("{0:0}", 0);
                  //  int val = 0;
                    // DockManager menu=new DockManager();
                    // RootView menu = Application.Current.Windows.OfType<RootView>().SingleOrDefault(x => x.IsActive);
                    //   dia.ProgressDialog(menu, "Loading...");
                    foreach (var record in engine)
                    {
                        //   HorizSlider = string.Format("{0:0}", val+10);
                        // progress = "In progress...";
                       // names = record.Name.Split(separatorName, StringSplitOptions.None);
                      //  if (names.Count() == 1)
                       //     names = record.Name.Split(otherSeparatorName, StringSplitOptions.None);
                        if (record.SchoolDistrict == "1")
                            _district = "Denton";
                        if (record.SchoolDistrict == "2")
                            _district = "Lewisville";
                        if (record.SchoolDistrict == "3")
                            _district = "McKinney";
                        if (record.SchoolDistrict == "4")
                            _district = "Prosper";
                        if (record.SchoolDistrict == "5")
                            _district = "Sanger";
                       // grade_subject = new List<InterpreterCSV.gradesubject>();
                        //grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade3, subject = record.Subject1 });
                        //grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade2, subject = record.Subject2 });
                        //grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade3, subject = record.Subject3 });
                        //grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade4, subject = record.Subject4 });
                        //grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade5, subject = record.Subject5 });
                        //grade_subject.Add(new InterpreterCSV.gradesubject() { grade = record.Grade6, subject = record.Subject6 });
                        //List<string> subject = grade_subject.Select(s => s.subject).Distinct().ToList();
                     //   int i = 0;
                        course = string.Empty;
                        if (record.Grade3 == "1")
                            course = course+"3,";
                        if (record.Grade4 == "1")
                            course = course+"4,";
                        if (record.Grade5 == "1")
                            course = course + "5";
                      //  grades = new string[6];
                        subjects = new string[6];
                        //foreach (string item in subject)
                        //{
                        //    var grade = grade_subject.Where(p => p.subject == item);
                        //    List<string> gs = grade.Select(s => s.grade).ToList();
                        //    subjects[i] = item;
                        //    grades[i] = string.Empty;

                        //    foreach (string it in gs)
                        //    {
                        //        grades[i] = it + "," + grades[i];
                        //    }
                        //    course = grades[i] + " " + subjects[i] + " | " + course;
                        //    i++;
                        //}
                        if (record.preferredContact == "1")
                            preferred = "Email";
                        if (record.preferredContact == "2")
                            preferred = "School phone";
                        if (record.preferredContact == "3")
                            preferred = "Cell or Home phone";
                        if (record.Pair == "1")
                            pair = "Yes";
                        else pair = "No";
                        scheduler = new List<InterpreterCSV.Avail>();
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From1, EndTime = record.To1, Days = record.Day1, Subject = "", Grade =0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From2, EndTime = record.To2, Days = record.Day2, Subject = "", Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From3, EndTime = record.To3, Days = record.Day3, Subject = "", Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From4, EndTime = record.To4, Days = record.Day4, Subject = "", Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From5, EndTime = record.To5, Days = record.Day5, Subject = "", Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From6, EndTime = record.To6, Days = record.Day6, Subject = "", Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From7, EndTime = record.To7, Days = record.Day7, Subject = "", Grade = 0 });
                        scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.From8, EndTime = record.To8, Days = record.Day8, Subject = "", Grade = 0 });
                    //    scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period6From, EndTime = record.Period6To, Days = record.Day6, Subject = "", Grade = 0 });
                      //  scheduler.Add(new InterpreterCSV.Avail() { StartTime = record.Period7From, EndTime = record.Period7To, Days = "Period7", Subject = record.Period7Subject, Grade = 0 });
                        adjustedScheduler = new List<Model.Avail>();
                        
                        sPattern=@"^(?<monday>monday+)\W+(?<or>or)*\s?(?<tuesday>tuesday+)\W+(?<or>or)*\s?(?<wednesday>wednesday+)\W+(?<or>or)*\s?(?<thursday>thursday+)\W+(?<or>or)*\s?(?<friday>friday+)\W*$|^(?<m>m+)\W+(?<or>or)*\s?(?<tue>t+)\W+(?<or>or)*\s?(?<w>w+)\W+(?<or>or)*\s?(?<th>th+)\W+(?<or>or)*\s?(?<f>f+)\W*$";
                       
                        foreach (var dossier in scheduler)
                        {
                            if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Days != string.Empty)
                            {
                                if (dossier.StartTime == "850")
                                    dossier.StartTime = "08:50 AM";
                                if (dossier.EndTime == "950")
                                    dossier.EndTime = "09:50 AM";
                                if (dossier.StartTime == "955")
                                    dossier.StartTime = "09:55 AM";
                                if (dossier.EndTime == "1055")
                                    dossier.EndTime = "10:55 AM";
                             /*   if (record.Name=="Serna, Victoria")
                                {
                                //    dossier.EndTime = "09:20 PM";
                                    dossier.Days = "Thursday";
                                }
                                if (record.Name=="Lengerich, Kimberly" && (dossier.EndTime=="02:05 AM"))
                                {
                                   // dossier.StartTime = "01:20 AM";
                                    dossier.EndTime = "02:30 PM";
                                   // dossier.Days = "Thursday";
                                }
*/
                                subjects = dossier.Days.Split(scatterDay, StringSplitOptions.None);
                                foreach (string item in subjects)
                                {
                                    if (item.ToLower()=="monday" || item.ToLower()=="m" || item.ToLower()=="mon"||item.ToLower()=="days except tuesdays")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Monday", Subject = dossier.Subject, Grade = 0 });
                                    else if (item.ToLower()=="tuesday" || item.ToLower()=="t" || item.ToLower()=="tue")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    else if (item.ToLower()=="wednesday" || item.ToLower()=="w" || item.ToLower()=="wed" || item.ToLower()=="days except tuesdays")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Wednesday", Subject = dossier.Subject, Grade = 0 });
                                    else if (item.ToLower()=="thursday"|| item.ToLower()=="th" || item.ToLower()=="thurs" || item.ToLower()=="days except tuesdays")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Thursday", Subject = dossier.Subject, Grade = 0 });
                                    else if (item.ToLower()=="friday" || item.ToLower()=="f"|| item.ToLower()=="fri" || item.ToLower()=="days except tuesdays")
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Friday", Subject = dossier.Subject, Grade = 0 });
                                    else if(item.ToLower()=="every day"||item.ToLower()=="any day of the week"||item.ToLower()=="any"||item.ToLower()=="mtwthf"||item.ToLower()=="anydays"){
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Monday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Wednesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "Friday", Subject = dossier.Subject, Grade = 0 });
                                    }
                                }
                                subjects.Initialize();
                            }
                        }

                      /*  schedulerAB = new List<InterpreterCSV.Avail>();
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod1From, EndTime = record.APeriod1To, Days = "APeriod1", Subject = record.APeriod1Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod2From, EndTime = record.APeriod2To, Days = "APeriod2", Subject = record.APeriod2Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod3From, EndTime = record.APeriod3To, Days = "APeriod3", Subject = record.APeriod3Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.APeriod4From, EndTime = record.APeriod4To, Days = "APeriod4", Subject = record.APeriod4Subject, Grade = 20 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod5From, EndTime = record.BPeriod5To, Days = "BPeriod5", Subject = record.BPeriod5Subject, Grade = 21 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod6From, EndTime = record.BPeriod6To, Days = "BPeriod6", Subject = record.BPeriod6Subject, Grade = 21 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod7From, EndTime = record.BPeriod7To, Days = "BPeriod7", Subject = record.BPeriod7Subject, Grade = 21 });
                        schedulerAB.Add(new InterpreterCSV.Avail() { StartTime = record.BPeriod8From, EndTime = record.BPeriod8To, Days = "BPeriod8", Subject = record.BPeriod8Subject, Grade = 21 });
                        foreach (var dossier in schedulerAB)
                        {
                            if (dossier.StartTime != string.Empty && dossier.EndTime != string.Empty && dossier.Subject != "0")
                            {
                                if (dossier.Grade == 21)
                                {
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Monday | A Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Monday | A Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Wednesday | A Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Wednesday | A Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday | A Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "A Friday | A Thursday", Subject = dossier.Subject, Grade = 0 });
                                }
                                else if (dossier.Grade == 22)
                                {
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Monday | B Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Monday | B Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Wednesday | B Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Wednesday | B Thursday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday | B Tuesday", Subject = dossier.Subject, Grade = 0 });
                                    adjustedScheduler.Add(new Model.Avail() { StartTime = dossier.StartTime, EndTime = dossier.EndTime, Days = "B Friday | B Thursday", Subject = dossier.Subject, Grade = 0 });
                                }
                            }
                        }*/
                        //if (record.TwoClassPairStudent == "1")
                        //    _classBack = "Yes";
                        //else _classBack = "No";
                        if (record.AssistSchedulingChoice == "1")
                            _classBack = "I have same students all days.";
                        if (record.AssistSchedulingChoice == "2")
                            _classBack = "I team teach.My colleague is " + record.AssistSchedulingText;
                        if (record.AssistSchedulingChoice == "3")
                            _classBack = "I have different students every period.";
                        Nodays = string.Empty;
                        if (record.NoSchedulingMonday == "1")
                            Nodays = Nodays + "Monday,";
                        if (record.NoSchedulingTuesday == "1")
                            Nodays = Nodays + "Tuesday,";
                        if (record.NoSchedulingWednesday == "1")
                            Nodays = Nodays + "Wednesday,";
                        if (record.NoSchedulingThursday == "1")
                            Nodays = Nodays + "Thursday,";
                        if (record.NoSchedulingFriday == "1")
                            Nodays = Nodays + "Friday";
                        if (record.AttendMatchingDay == "1")
                            attend = "Yes";
                        else attend = "No";



                        // var gs = grade_subject.Select(s =>new {s.grade,s.subject}).Distinct();
                        TeacherStep1 myteacher = new TeacherStep1()
                        {
                            FirstName = record.FirstName,
                            LastName = record.LastName,
                            Email = record.Email,
                            Course = course,
                            IsTeacher = true
                            ,
                            District = _district,
                            Pair = pair,
                            Phone = record.CellPhone,
                            School = record.School,
                            SchoolPhone = record.SchoolPhone,
                            Schedule = adjustedScheduler,
                            Room = record.Room,
                            PreferredContact = preferred,
                            AnythingElse = record.AnythingtoSchedule,
                            AssistScheduling=_classBack,
                            NoSchedulingDay = Nodays,
                            AttendMentorMatching=attend,
                            TeachCount = 1

                        };
                        Response = "false";
                        Task<string> addresponse = _dataService.AddTeacherStep1(myteacher);
                        Response = addresponse.Result;
                        /*  if (Response == "success")
                          {
                              progress = "Done...";
                              HorizSlider = string.Format("{0:0}", 100);
                          }*/
                        // dia.progressTerminated(menu, "Done")              
                    }
                    //menu.Close();
                    names.Initialize();
                    subjects.Initialize();
                 //   grades.Initialize();
        //            grade_subject.Clear();
                    scheduler.Clear();
                 //   schedulerAB.Clear();
                    adjustedScheduler.Clear();
                    lines.Clear();
                }
   //             File.Delete(default_path + target_path + @"\dataToLoad.csv");

            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check your excel file data", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                File.Delete(default_path + target_path + @"\teacherstep1.txt");
                File.Delete(default_path + target_path + @"\dataToLoad.csv");
            }
        }

        private void AddListTeachCombo() {
          //  AddListTeachStep2();
        }
        }

    }

