using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingDash.Model
{
    public interface IDataService
    {
         Task<IEnumerable<Teacher>> RefreshTeacher();
         Task<IEnumerable<TeacherStep2>> RefreshTeacherStep2();
         Task<IEnumerable<TeacherStep1>> RefreshTeacherStep1();
         Task<IEnumerable<TeacherCI>> RefreshTeacherCI();
         Task<IEnumerable<Student>> RefreshStudent();
         Task<IEnumerable<StudentStep2>> RefreshStudentStep2();
         Task<IEnumerable<StudentStep1>> RefreshStudentStep1();
         Task<IEnumerable<StudentCI>> RefreshStudentCI();
        Task<string> EditTeacher(Teacher updatedTeacher);
         Task<string> AddTeacher(Teacher addingTeacher);
         Task<string> AddTeacherStep2(TeacherStep2 addingTeacher);
         Task<string> AddTeacherStep1(TeacherStep1 addingTeacher);
         Task<string> AddTeacherCI(TeacherCI addingTeacher);
         Task<string> AddStudent(Student addingStudent);
         Task<string> AddStudentStep2(StudentStep2 addingStudent);
         Task<string> AddStudentStep1(StudentStep1 addingStudent);
         Task<string> AddStudentCI(StudentCI addingStudent);
    }
}
