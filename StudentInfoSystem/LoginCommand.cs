using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserLogin;

namespace StudentInfoSystem
{
    public class LoginCommand : ICommand
    {
        public void Execute(object parameter)
        {
            var context = parameter as LoginVM;
            Login login = new Login();
            Student student;
            string userName = context.Username;
            string password = context.Password;

            User user = UserData.IsUserPassCorrect(userName, password);

            if (user == null)
            {
                login.ShowAlertMessage();
                login.Close();
                return;
            }

            StudentValidation studentValidation = new StudentValidation();

            student = studentValidation.GetStudentByUser(user);

            if (student != null)
            {
                login.ShowMainWindow(student);
                context.CloseAction();
            }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

    }
}
