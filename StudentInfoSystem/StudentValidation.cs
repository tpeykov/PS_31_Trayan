using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem
{
    public class StudentValidation
    {
        public Student GetStudentByUser(User user)
        {
            StudentData studentData = new StudentData();
            if (String.IsNullOrWhiteSpace(user.facNumber) || user == null)
            {
                Console.WriteLine("Faculty number is empty or there is no such student with this faculty number");
                return null;
            }

            IEnumerable<Student> students = studentData.getStudents();

            foreach (Student student in students)
            {
                if (student.facultyNumber.Equals(user.facNumber))
                {
                    return student;
                }
            }

            Console.WriteLine("No such student!");
            return null;
        }
    }
}
