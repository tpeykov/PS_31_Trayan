using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student
    {
        public int studentId { get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string lastName { get; set; }
        public byte[] Photo { get; set; }
        public string faculty { get; set; }
        public string speciality { get; set; }
        public string degree { get; set; }
        public string status { get; set; }
        public string facultyNumber { get; set; }
        public int course { get; set; }
        public int stream { get; set; }
        public int groupa { get; set; }

        public Student(string firstName, string secondName, string lastName, string faculty, string speciality,
            string degree, string status, string facultyNumber, int course, int stream, int group)
        {
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.speciality = speciality;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.stream = stream;
            this.groupa = group;
        }

        public Student() { }
    }
}
