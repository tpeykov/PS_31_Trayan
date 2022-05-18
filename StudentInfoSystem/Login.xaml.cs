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
using System.Windows.Shapes;
using UserLogin;

namespace StudentInfoSystem
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            LoginVM login = new LoginVM();
            DataContext = login;
            if (login.CloseAction == null)
            {
                login.CloseAction = new Action(this.Close);
            }
        }

        public void ShowAlertMessage()
        {
            MessageBox.Show("Грешен потребител или парола", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowMessage(string username, string password)
        {
            MessageBox.Show("Потребител: " + username + " Парола: " + password, "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowMainWindow(Student student)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.enableControls();
            FillTextFields(mainWindow, student);

            mainWindow.btnTest.Visibility = Visibility.Hidden;
            mainWindow.btnTest2.Visibility = Visibility.Hidden;
            mainWindow.btnLock.Visibility = Visibility.Hidden;
            mainWindow.btnUnlock.Visibility = Visibility.Hidden;
            mainWindow.Show();
            this.Close();
        }

        private void FillTextFields(MainWindow mainWindow, Student student)
        {
            mainWindow.txtFirstName.Text = student.firstName;
            mainWindow.txtSecondName.Text = student.secondName;
            mainWindow.txtLastName.Text = student.lastName;
            mainWindow.txtFaculty.Text = student.faculty;
            mainWindow.txtSpeciality.Text = student.speciality;
            mainWindow.txtDegree.Text = student.degree;
            mainWindow.txtStatus.Text = student.status;
            mainWindow.txtFacultyNumber.Text = student.facultyNumber;
            mainWindow.txtCourse.Text = student.course.ToString();
            mainWindow.txtStream.Text = student.stream.ToString();
            mainWindow.txtGroup.Text = student.groupa.ToString();
        }
    }
}
