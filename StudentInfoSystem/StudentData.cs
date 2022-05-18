using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class StudentData
    {
        private List<Student> TestStudents;

        public StudentData()
        {
            TestStudents = new List<Student>
            {
                exampleStudent()
            };
        }

        public List<Student> getStudents()
        {
            return this.TestStudents;
        }

        private void setStudents(List<Student> students)
        {
            this.TestStudents = students;
        }

        private Student exampleStudent()
        {
            Student student = new Student("Trayan", "Nikolaev", "Peykov", "FKST", "KSI", "Bakalavur", "Zaveril",
                "121219050", 3, 9, 31);

            return student;
        }

        public Student IsThereStudent(string facNum)
        {
            StudentInfoContext context = new StudentInfoContext();

            Student result = (from st in context.Students
                              where st.facultyNumber == facNum
                              select st).FirstOrDefault();

            return result;
        }
    }
}
