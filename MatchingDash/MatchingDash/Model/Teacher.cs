using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace MatchingDash.Model
{
    
    public class Teacher
    {
        private string _firstName;
        [JsonProperty("first_name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _lastName;
        [JsonProperty("last_name")]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
            }

        }
        private string _major;
        [JsonProperty("major")]
        public string Major
        {
            get { return _major; }
            set
            {
                _major = value;
            }
        }
      
        private string _email;
        [JsonProperty("email")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }

        private bool _isTeacher;
        [JsonProperty("isTeacher")]
        public bool IsTeacher
        {
            get { return _isTeacher; }
            set
            {
                _isTeacher = value;
            }
        }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("alternativePhone")]
        public string AlternativePhone { get; set; }
        [JsonProperty("schedule")]
        public List<Availability> Schedule { get; set; }
        [JsonProperty("transportation")]
        public string Transportation { get; set; }
        [JsonProperty("willingToDrive")]
        public string WillingToDrive { get; set; }
        [JsonProperty("willingToTeach")]
        public string WillingToTeach { get; set; }
        [JsonProperty("partner")]
        public string Partner { get; set; }
        [JsonProperty("school")]
        public string School { get; set; }
        // [JsonProperty("isPreferedPartner")]
        //public bool IsPreferedPartner { get; set; }
        [JsonProperty("preferedPartner")]
        public string PreferedPartner { get; set; }
        [JsonProperty("districtDenton")]
        public int DistrictDenton { get; set; }
        [JsonProperty("districtForthWorth")]
        public int DistrictForthWorth { get; set; }
        [JsonProperty("districtLewisville")]
        public int DistrictLewisville { get; set; }
        [JsonProperty("districtMckinney")]
        public int DistrictMckinney { get; set; }
        [JsonProperty("mathAlg1")]
        public int MathAlg1 { get; set; }
        [JsonProperty("mathGeom")]
        public int MathGeom { get; set; }
        [JsonProperty("mathAlg2")]
        public int MathAlg2 { get; set; }
        [JsonProperty("mathModels")]
        public int MathModels { get; set; }
        [JsonProperty("mathPreCal")]
        public int MathPreCal { get; set; }
        [JsonProperty("biology")]
        public int Biology { get; set; }
        [JsonProperty("anatomyPhysiology")]
        public int AnatomyPhysiology { get; set; }
        [JsonProperty("willingToTeachChemestry")]
        public string WillingToTeachChemestry { get; set; }
        [JsonProperty("anythingElseScheduling")]
        public string AnythingElseScheduling { get; set; }

        
    }
    public class MentorTeacher
    {
        private string _firstName;
        [JsonProperty("first_name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _lastName;
        [JsonProperty("last_name")]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
            }

        }
        private string _major;
        [JsonProperty("major")]
        public string Major
        {
            get { return _major; }
            set
            {
                _major = value;
            }
        }
        private string _grade;
        [JsonProperty("grade")]
        public string Grade
        {
            get { return _grade; }
            set
            {
                _grade = value;
            }
        }
        private string _room;
        [JsonProperty("room")]
        public string Room
        {
            get { return _room; }
            set
            {
                _room = value;
            }
        }
        private string _email;
        [JsonProperty("email")]
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
            }
        }
        //private DateTime _startDayTime;
        //[JsonProperty("start_daytime")]
        //public DateTime StartDayTime 
        //{
        //    get { return _startDayTime; }
        //    set
        //    {
        //        _startDayTime = value;
        //    }
        //}
        //private DateTime _endDayTime;
        // [JsonProperty("end_daytime")]
        //public DateTime EndDayTime
        //{
        //    get { return _endDayTime; }
        //    set
        //    {
        //        _endDayTime = value;
        //    }
        //}
        private bool _isTeacher;
        [JsonProperty("isTeacher")]
        public bool IsTeacher
        {
            get { return _isTeacher; }
            set
            {
                _isTeacher = value;
            }
        }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("cellphone")]
        public string CellPhone { get; set; }
        [JsonProperty("homePhone")]
        public string HomePhone { get; set; }
         [JsonProperty("numberStudent")]
        public int NumberStudent { get; set; }
        [JsonProperty("schedule")]
        public List<Availability> Schedule { get; set; }
        [JsonProperty("transportation")]
        public string Transportation { get; set; }
        [JsonProperty("willingToDrive")]
        public string WillingToDrive { get; set; }
        [JsonProperty("willingToTeach")]
        public string WillingToTeach { get; set; }
        [JsonProperty("partner")]
        public string Partner { get; set; }
        [JsonProperty("school")]
        public string School { get; set; }
        [JsonProperty("isPreferedPartner")]
        public bool IsPreferedPartner { get; set; }
        [JsonProperty("preferedPartner")]
        public string PreferedPartner { get; set; }
        [JsonProperty("districtDenton")]
        public int DistrictDenton { get; set; }
        [JsonProperty("districtForthWorth")]
        public int DistrictForthWorth { get; set; }
        [JsonProperty("districtLewisville")]
        public int DistrictLewisville { get; set; }
        [JsonProperty("districtMckinney")]
        public int DistrictMckinney { get; set; }
        [JsonProperty("mathAlg1")]
        public int MathAlg1 { get; set; }
        [JsonProperty("mathGeom")]
        public int MathGeom { get; set; }
        [JsonProperty("mathAlg2")]
        public int MathAlg2 { get; set; }
        [JsonProperty("mathModels")]
        public int MathModels { get; set; }
        [JsonProperty("mathPreCal")]
        public int MathPreCal { get; set; }
        [JsonProperty("biology")]
        public int Biology { get; set; }
        [JsonProperty("anatomyPhysiology")]
        public int AnatomyPhysiology { get; set; }
        [JsonProperty("workMorePairStudent")]
        public string WorkMorePairStudent { get; set; }
        [JsonProperty("attendMeeting")]
        public bool AttendMeeting { get; set; }




    }
   

    
}
