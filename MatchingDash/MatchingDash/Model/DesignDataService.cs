using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingDash.Model
{
    public class DesignDataService: IDataService
    {
        public Task<IEnumerable<Teacher>> RefreshTeacher()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TeacherCI>> RefreshTeacherCI()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TeacherStep2>> RefreshTeacherStep2()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TeacherStep1>> RefreshTeacherStep1()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Student>> RefreshStudent()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<StudentStep2>> RefreshStudentStep2()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<StudentCI>> RefreshStudentCI()
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<StudentStep1>> RefreshStudentStep1()
        {
            throw new NotImplementedException();
        }
         public Task<string> EditTeacher(Teacher updatedTeacher)
        {
            throw new NotImplementedException();
        }
         public Task<string> AddTeacher(Teacher addingTeacher)
         {
             throw new NotImplementedException();
         }
         public Task<string> AddTeacherCI(TeacherCI addingTeacher)
         {
             throw new NotImplementedException();
         }
         public Task<string> AddTeacherStep2(TeacherStep2 addingTeacher)
         {
             throw new NotImplementedException();
         }
         public Task<string> AddTeacherStep1(TeacherStep1 addingTeacher)
         {
             throw new NotImplementedException();
         }
         public Task<string> AddStudent(Student addingStudent)
         {
             throw new NotImplementedException();
         }
         public Task<string> AddStudentStep2(StudentStep2 addingStudent)
         {
             throw new NotImplementedException();
         }
         public Task<string> AddStudentStep1(StudentStep1 addingStudent)
         {
             throw new NotImplementedException();
         }
         public Task<string> AddStudentCI(StudentCI addingStudent)
         {
             throw new NotImplementedException();
         }

    }
}
