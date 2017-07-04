using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;
using System.Net;
namespace MatchingDash.Model
{
    public class DataService : IDataService
    {
        string default_path = Directory.GetCurrentDirectory();
        string target_path = @"\DataInfo";
     //   private ListofData mydata=new ListofData();
       
        public  Task<IEnumerable<Teacher>> RefreshTeacher()
        {
            //throw new NotImplementedException();
             return Task.Run(() =>{
            if (!Directory.Exists(default_path+target_path))
            {
                Directory.CreateDirectory(default_path + target_path);              
            }
            if (!File.Exists(default_path + target_path + @"\teachers.txt"))
            {
                System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\teachers.txt");
                fs.Close();
            }
           
            var result=JsonConvert.DeserializeObject<IEnumerable<Teacher>>(File.ReadAllText(default_path + target_path + @"\teachers.txt",System.Text.Encoding.Default));
            return result;
             });
            //System.IO.File.ReadAllText()
        }
        public Task<IEnumerable<TeacherStep2>> RefreshTeacherStep2()
        {
            //throw new NotImplementedException();
            return Task.Run(() =>
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);
                }
                if (!File.Exists(default_path + target_path + @"\teacherstep2.txt"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\teacherstep2.txt");
                    fs.Close();
                }
               
                var result = JsonConvert.DeserializeObject<IEnumerable<TeacherStep2>>(File.ReadAllText(default_path + target_path + @"\teacherstep2.txt", System.Text.Encoding.Default));
                return result;
            });
            //System.IO.File.ReadAllText()
        }
        public Task<IEnumerable<TeacherStep1>> RefreshTeacherStep1()
        {
            //throw new NotImplementedException();
            return Task.Run(() =>
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);
                }
                if (!File.Exists(default_path + target_path + @"\teacherstep1.txt"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\teacherstep1.txt");
                    fs.Close();
                }

                var result = JsonConvert.DeserializeObject<IEnumerable<TeacherStep1>>(File.ReadAllText(default_path + target_path + @"\teacherstep1.txt", System.Text.Encoding.Default));
                return result;
            });
            //System.IO.File.ReadAllText()
        }
        public Task<IEnumerable<TeacherCI>> RefreshTeacherCI()
        {
            //throw new NotImplementedException();
            return Task.Run(() =>
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);
                }
                if (!File.Exists(default_path + target_path + @"\teacherCI.txt"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\teacherCI.txt");
                    fs.Close();
                }

                var result = JsonConvert.DeserializeObject<IEnumerable<TeacherCI>>(File.ReadAllText(default_path + target_path + @"\teacherCI.txt", System.Text.Encoding.Default));
                return result;
            });
            //System.IO.File.ReadAllText()
        }
        public Task<IEnumerable<Student>> RefreshStudent()
        {
            //throw new NotImplementedException();
            return Task.Run(() =>
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);                   
                }
                if (!File.Exists(default_path + target_path + @"\tudents.txt"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\tudents.txt");
                    fs.Close();
                }
                var result = JsonConvert.DeserializeObject<IEnumerable<Student>>(File.ReadAllText(default_path + target_path + @"\tudents.txt", System.Text.Encoding.Default));
                return result;
            });
            //System.IO.File.ReadAllText()
        }
        public Task<IEnumerable<StudentStep2>> RefreshStudentStep2()
        {
            //throw new NotImplementedException();
            return Task.Run(() =>
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);
                }
                if (!File.Exists(default_path + target_path + @"\tudentstep2.txt"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\tudentstep2.txt");
                    fs.Close();
                }
                var result = JsonConvert.DeserializeObject<IEnumerable<StudentStep2>>(File.ReadAllText(default_path + target_path + @"\tudentstep2.txt", System.Text.Encoding.Default));
                return result;
            });
            //System.IO.File.ReadAllText()
        }
        public Task<IEnumerable<StudentStep1>> RefreshStudentStep1()
        {
            //throw new NotImplementedException();
            return Task.Run(() =>
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);
                }
                if (!File.Exists(default_path + target_path + @"\tudentstep1.txt"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\tudentstep1.txt");
                    fs.Close();
                }
                var result = JsonConvert.DeserializeObject<IEnumerable<StudentStep1>>(File.ReadAllText(default_path + target_path + @"\tudentstep1.txt", System.Text.Encoding.Default));
                return result;
            });
            //System.IO.File.ReadAllText()
        }

        public Task<IEnumerable<StudentCI>> RefreshStudentCI()
        {
            //throw new NotImplementedException();
            return Task.Run(() =>
            {
                if (!Directory.Exists(default_path + target_path))
                {
                    Directory.CreateDirectory(default_path + target_path);
                }
                if (!File.Exists(default_path + target_path + @"\tudentCI.txt"))
                {
                    System.IO.FileStream fs = System.IO.File.Create(default_path + target_path + @"\tudentCI.txt");
                    fs.Close();
                }
                var result = JsonConvert.DeserializeObject<IEnumerable<StudentCI>>(File.ReadAllText(default_path + target_path + @"\tudentCI.txt", System.Text.Encoding.Default));
                return result;
            });
            //System.IO.File.ReadAllText()
        }
        public Task<string> EditTeacher(Teacher updatedTeacher)
        {
            throw new NotImplementedException();
        }
        public Task<string> AddTeacher(Teacher addingTeacher)
        {
             return Task.Run(() =>{
            try
            {
                //if (!Directory.Exists(target_path))
                //{
                //    Directory.CreateDirectory(target_path);
                //}
               // mydata.ListofTeachers = RefreshTeacher().Result.ToList();
                List<Teacher>listofteacher=new List<Teacher>();
                if (RefreshTeacher().Result!=null)
                    listofteacher = RefreshTeacher().Result.ToList();
                //Add availability first

               // List<Availability> newschedule = new List<Availability>().Add { };
                listofteacher.Add(addingTeacher);
                String json = JsonConvert.SerializeObject(listofteacher);
                File.WriteAllText(default_path + target_path + @"\teachers.txt", string.Empty);
                File.WriteAllText(default_path + target_path + @"\teachers.txt", json);
                //Task<string> result = new Task<string>("success");
                //string result = "success";
                return "success";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return ex.Message;
            }
             });
        }
        public Task<string> AddTeacherStep2(TeacherStep2 addingTeacher)
        {
            return Task.Run(() =>
            {
                try
                {
                    
                    List<TeacherStep2> listofteacher = new List<TeacherStep2>();
                    if (RefreshTeacherStep2().Result != null)
                        listofteacher = RefreshTeacherStep2().Result.ToList();
                   
                    listofteacher.Add(addingTeacher);
                    String json = JsonConvert.SerializeObject(listofteacher);
                    File.WriteAllText(default_path + target_path + @"\teacherstep2.txt", string.Empty);
                    File.WriteAllText(default_path + target_path + @"\teacherstep2.txt", json);
                    
                    return "success";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ex.Message;
                }
            });
        }
        public Task<string> AddTeacherStep1(TeacherStep1 addingTeacher)
        {
            return Task.Run(() =>
            {
                try
                {

                    List<TeacherStep1> listofteacher = new List<TeacherStep1>();
                    if (RefreshTeacherStep1().Result != null)
                        listofteacher = RefreshTeacherStep1().Result.ToList();

                    listofteacher.Add(addingTeacher);
                    String json = JsonConvert.SerializeObject(listofteacher);
                    File.WriteAllText(default_path + target_path + @"\teacherstep1.txt", string.Empty);
                    File.WriteAllText(default_path + target_path + @"\teacherstep1.txt", json);

                    return "success";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ex.Message;
                }
            });
        }
        public Task<string> AddTeacherCI(TeacherCI addingTeacher)
        {
            return Task.Run(() =>
            {
                try
                {

                    List<TeacherCI> listofteacher = new List<TeacherCI>();
                    if (RefreshTeacherCI().Result != null)
                        listofteacher = RefreshTeacherCI().Result.ToList();

                    listofteacher.Add(addingTeacher);
                    String json = JsonConvert.SerializeObject(listofteacher);
                    File.WriteAllText(default_path + target_path + @"\teacherCI.txt", string.Empty);
                    File.WriteAllText(default_path + target_path + @"\teacherCI.txt", json);

                    return "success";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ex.Message;
                }
            });
        }
        public Task<string> AddStudent(Student addingStudent)
        {
            return Task.Run(() =>
            {
                try
                {
                    //if (!Directory.Exists(target_path))
                    //{
                    //    Directory.CreateDirectory(target_path);
                    //}
                    List<Student> listofstudent = new List<Student>();
                    if (RefreshStudent().Result != null)
                    listofstudent = RefreshStudent().Result.ToList();
                    //Add availability first

                    // List<Availability> newschedule = new List<Availability>().Add { };
                    listofstudent.Add(addingStudent);
                    String json = JsonConvert.SerializeObject(listofstudent);
                    File.WriteAllText(default_path + target_path + @"\tudents.txt", string.Empty);
                    File.WriteAllText(default_path + target_path + @"\tudents.txt", json);
                    //Task<string> result = new Task<string>("success");
                    //string result = "success";
                    return "success";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ex.Message;
                }
            });
        }
        public Task<string> AddStudentStep2(StudentStep2 addingStudent)
        {
            return Task.Run(() =>
            {
                try
                {
                    
                    List<StudentStep2> listofstudent = new List<StudentStep2>();
                    if (RefreshStudentStep2().Result != null)
                        listofstudent = RefreshStudentStep2().Result.ToList();
                   
                    listofstudent.Add(addingStudent);
                    String json = JsonConvert.SerializeObject(listofstudent);
                    File.WriteAllText(default_path + target_path + @"\tudentstep2.txt", string.Empty);
                    File.WriteAllText(default_path + target_path + @"\tudentstep2.txt", json);
                    //Task<string> result = new Task<string>("success");
                    //string result = "success";
                    return "success";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ex.Message;
                }
            });
        }
        public Task<string> AddStudentStep1(StudentStep1 addingStudent)
        {
            return Task.Run(() =>
            {
                try
                {

                    List<StudentStep1> listofstudent = new List<StudentStep1>();
                    if (RefreshStudentStep1().Result != null)
                        listofstudent = RefreshStudentStep1().Result.ToList();

                    listofstudent.Add(addingStudent);
                    String json = JsonConvert.SerializeObject(listofstudent);
                    File.WriteAllText(default_path + target_path + @"\tudentstep1.txt", string.Empty);
                    File.WriteAllText(default_path + target_path + @"\tudentstep1.txt", json);
                    //Task<string> result = new Task<string>("success");
                    //string result = "success";
                    return "success";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ex.Message;
                }
            });
        }
        public Task<string> AddStudentCI(StudentCI addingStudent)
        {
            return Task.Run(() =>
            {
                try
                {

                    List<StudentCI> listofstudent = new List<StudentCI>();
                    if (RefreshStudentCI().Result != null)
                        listofstudent = RefreshStudentCI().Result.ToList();

                    listofstudent.Add(addingStudent);
                    String json = JsonConvert.SerializeObject(listofstudent);
                    File.WriteAllText(default_path + target_path + @"\tudentCI.txt", string.Empty);
                    File.WriteAllText(default_path + target_path + @"\tudentCI.txt", json);
                    //Task<string> result = new Task<string>("success");
                    //string result = "success";
                    return "success";

                }
                catch (Exception ex)
                {
                    MessageBox.Show("can't interpret some values .\n\n" + ex.Message + "\n\n Please check   ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return ex.Message;
                }
            });
        }
        public int DownloadTeacherFile(){
             // Get the object used to communicate with the server.
            int i = 0;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://kkomedja.com/public_ftp/DataInfo/teachers.txt");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("kkomedja", "z5291nrFxJ");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
    
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
          //  Console.WriteLine(reader.ReadToEnd());

          //  Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
            if (response.StatusCode.ToString() == "200")
            {
                i = 1;
                File.WriteAllText(default_path + target_path + @"\teachers.txt", reader.ReadToEnd());
            }
            reader.Close();
            response.Close();
            return i;
        }
        public int DownloadStudentFile()
        {
            // Get the object used to communicate with the server.
            int i = 0;
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://kkomedja.com/public_ftp/DataInfo/tudents.txt");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            // This example assumes the FTP site uses anonymous logon.
            request.Credentials = new NetworkCredential("kkomedja", "z5291nrFxJ");

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);
          //  Console.WriteLine(reader.ReadToEnd());

           // Console.WriteLine("Download Complete, status {0}", response.StatusDescription);
            if (response.StatusCode.ToString() == "200")
            {
                i = 1;
                File.WriteAllText(default_path + target_path + @"\tudents.txt", reader.ReadToEnd());
            }
            reader.Close();
            response.Close();
            return i;
        }
        public void UploadTeacherFile(){

        }
        public void UploadStudentFile()
        {

        }
    }
}