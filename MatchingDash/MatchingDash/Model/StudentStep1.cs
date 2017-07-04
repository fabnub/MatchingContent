using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatchingDash.Model
{
   public  class StudentStep1
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
       [JsonProperty("year")]
       public string Year { get; set; }
       [JsonProperty("section")]
       public string Section { get; set; }
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
       [JsonProperty("bilingualClass")]
       public string BilingualClass { get; set; }
       [JsonProperty("preferredDays")]
       public string PreferredDays { get; set; }
       [JsonProperty("campus")]
       public string Campus { get; set; }
       // [JsonProperty("isPreferedPartner")]
       //public bool IsPreferedPartner { get; set; }
       [JsonProperty("town")]
       public string Town { get; set; }
       [JsonProperty("districtDenton")]
       public int DistrictDenton { get; set; }
       [JsonProperty("districtForthWorth")]
       public int DistrictForthWorth { get; set; }
       [JsonProperty("districtLewisville")]
       public int DistrictLewisville { get; set; }
       [JsonProperty("districtMckinney")]
       public int DistrictMckinney { get; set; }
       [JsonProperty("districtPropser")]
       public int DistrictProsper { get; set; }
       [JsonProperty("districtSanger")]
       public int DistrictSanger { get; set; }
       [JsonProperty("anythingElseScheduling")]
       public string AnythingElseScheduling { get; set; }
    }
}
