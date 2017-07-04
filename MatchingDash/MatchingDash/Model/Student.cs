using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;

namespace MatchingDash.Model
{
    public class Student: ObservableObject
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
        public string AlternativePhone { get; set;}
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
        //[JsonProperty("mathAlg1")]
        //public int MathAlg1 { get; set; }
        //[JsonProperty("mathGeom")]
        //public int MathGeom { get; set; }
        //[JsonProperty("mathAlg2")]
        //public int MathAlg2 { get; set; }
        //[JsonProperty("mathModels")]
        //public int MathModels { get; set; }
        //[JsonProperty("mathPreCal")]
        //public int MathPreCal { get; set; }
        //[JsonProperty("biology")]
        //public int Biology { get; set; }
        //[JsonProperty("anatomyPhysiology")]
        //public int AnatomyPhysiology { get; set; }
        //[JsonProperty("willingToTeachChemestry")]
        //public string WillingToTeachChemestry { get; set; }
        [JsonProperty("anythingElseScheduling")]
        public string AnythingElseScheduling { get; set; }

        
        
      
    }
    public class Availability
    {
        [JsonProperty("time")]
        public string Time{get;set;}
        [JsonProperty("monday")]
        public bool Monday { get; set; }
        [JsonProperty("tuesday")]
        public bool Tuesday { get; set; }
        [JsonProperty("wednesday")]
        public bool Wednesday { get; set; }
        [JsonProperty("thursday")]
        public bool Thursday { get; set; }
        [JsonProperty("friday")]
        public bool Friday { get; set; }

    }
}
