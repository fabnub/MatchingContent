using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingDash.Model
{
    public class ListofData
    {
        [JsonProperty("listofTeachers")]
        public List<Teacher> ListofTeachers
        {
            get;
            set;
        }
        [JsonProperty("listofTeacherstep2")]
        public List<TeacherStep2> ListofTeacherstep2
        {
            get;
            set;
        }
        [JsonProperty("listofStudents")]
        public List<Student> ListofStudents
        {
            get;
            set;
        }
        [JsonProperty("listofStudentstep2")]
        public List<Student> ListofStudentstep2
        {
            get;
            set;
        }
        public ListofData()
        {
            this.ListofStudents = ListofStudents;
            this.ListofTeachers = ListofTeachers;
            this.ListofTeacherstep2 = ListofTeacherstep2;
            this.ListofStudentstep2 = ListofStudentstep2;
        }
        public List<Availability> addAvailability()
        {
            List<Availability> mytime = new List<Availability>();
            mytime.Add(new Availability() {Time="7:30 AM-8:00 AM",Monday=false,Tuesday=false,Wednesday=false,Thursday=false,Friday=false});
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
            return mytime;
        }
    }
}
