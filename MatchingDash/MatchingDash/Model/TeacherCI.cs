using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatchingDash.Model
{
  public  class TeacherCI
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
        private string _course;
        [JsonProperty("course")]
        public string Course
        {
            get { return _course; }
            set
            {
                _course = value;
            }
        }
        private string _school;
        [JsonProperty("school")]
        public string School
        {
            get { return _school; }
            set
            {
                _school = value;
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
        [JsonProperty("preferredContact")]
        public string PreferredContact { get; set; }
        [JsonProperty("district")]
        public string District { get; set; }
        [JsonProperty("phone")]
        public string Phone { get; set; }
        [JsonProperty("pair")]
        public string Pair { get; set; }
        [JsonProperty("schoolPhone")]
        public string SchoolPhone { get; set; }
        [JsonProperty("room")]
        public string Room { get; set; }
        [JsonProperty("schedule")]
        public List<Avail> Schedule { get; set; }
        [JsonProperty("anythingElse")]
        public string AnythingElse { get; set; }
        [JsonProperty("noSchedulingDay")]
        public string NoSchedulingDay { get; set; }
        [JsonProperty("attendMentorMatching")]
        public string AttendMentorMatching { get; set; }
        [JsonProperty("teachCount")]
        public int TeachCount { get; set; }
       [JsonProperty("backDays")]
        public List<Back> BackDays { get; set; }
       [JsonProperty("typeOfSchedule")]
       public string TypeOfSchedule { get; set; }
       [JsonProperty("isBackToBack")]
       public string IsBackToBack { get; set; }
    }
  public class Back
  {
       [JsonProperty("subject")]
      public string Subject { get; set; }
       [JsonProperty("day")]
      public string Day { get; set; }
  }
}
