using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentInfoSystem
{
    public partial class MainWindow : Window
    {
        public Student student;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clear()
        {
            foreach (var item in personData.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }

            foreach (var item in studentInfo.Children)
            {
                if (item is TextBox)
                {
                    ((TextBox)item).Clear();
                }
            }
        }

        private void setStudent(Student student)
        {
            if (isStudentDataCorrect(student))
            {
                enableControls();
                fillStudentInfo(student);
            }
            else
            {
                clear();
                disableControls();
            }

        }

        private Boolean isStudentDataCorrect(Student student)
        {
            return student != null && !String.IsNullOrWhiteSpace(student.firstName) && !String.IsNullOrWhiteSpace(student.secondName) && !String.IsNullOrWhiteSpace(student.lastName)
                && !String.IsNullOrWhiteSpace(student.faculty) && !String.IsNullOrWhiteSpace(student.speciality) && !String.IsNullOrWhiteSpace(student.degree)
                && !String.IsNullOrWhiteSpace(student.status) && !String.IsNullOrWhiteSpace(student.facultyNumber) && student.course != 0
                && student.stream != 0 && student.groupa != 0;
        }

        private void fillStudentInfo(Student student)
        {
            this.student = student;

            txtFirstName.Text = this.student.firstName;
            txtSecondName.Text = this.student.secondName;
            txtLastName.Text = this.student.lastName;
            txtFaculty.Text = this.student.faculty;
            txtSpeciality.Text = this.student.speciality;
            txtDegree.Text = this.student.degree;
            txtStatus.Text = this.student.status;
            txtFacultyNumber.Text = this.student.facultyNumber;
            txtCourse.Text = Convert.ToString(this.student.course);
            txtStream.Text = Convert.ToString(this.student.stream);
            txtGroup.Text = Convert.ToString(this.student.groupa);
        }

        private void disableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                if (ctr.Name == "btnUnlock" || ctr.Name == "btnTest")
                {
                    ctr.IsEnabled = true;
                }
                else
                {
                    ctr.IsEnabled = false;
                }
            }
        }

        public void enableControls()
        {
            foreach (Control ctr in MainGrid.Children)
            {
                ctr.IsEnabled = true;
            }
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            StudentData data = new StudentData();
            setStudent(data.getStudents().First());
        }

        private void btnTest2_Click(object sender, RoutedEventArgs e)
        {
            setStudent(null);
        }

        private void btnLock_Click(object sender, RoutedEventArgs e)
        {
            disableControls();
        }

        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {
            enableControls();
        }

        private Boolean TestStudentsIfEmpty()
        {
            StudentInfoContext context = new StudentInfoContext();

            IEnumerable<Student> queryStudents = context.Students;
            int countStudents = queryStudents.Count();

            return countStudents == 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Boolean result = TestStudentsIfEmpty();
            MessageBox.Show("Result is: " + result, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
            if (result)
            {
                CopyTestStudents();
            }
        }

        private void CopyTestStudents()
        {
            StudentInfoContext context = new StudentInfoContext();

            StudentData data = new StudentData();
            foreach (Student st in data.getStudents())
            {
                context.Students.Add(st);
            }

            context.SaveChanges();
            MessageBox.Show("Test student saved into database: ", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
