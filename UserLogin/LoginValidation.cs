using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin {
    public class LoginValidation{
        private static int MIN_LENGHT = 5;
        public static UserRoles currentUserRole { get; private set; }
        public static string currentUserName { get; private set; }
        public delegate void ActionOnError(string errorMsg);

        private string userName;
        private string password;
        private string errorMessage;
        private ActionOnError errorFunc;

        public LoginValidation(string userName, string password, ActionOnError errorFunc)
        {
            this.userName = userName;
            this.password = password;
            this.errorFunc = errorFunc;
        }

        public bool ValidateUserInput(ref User user)
        {
            Boolean emptyUserName = this.userName.Equals(String.Empty);
            if(emptyUserName)
            {
                this.errorMessage = "Не е посочено потребителско име";
                this.errorFunc(this.errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            Boolean emptyPass = this.password.Equals(String.Empty);
            if(emptyPass)
            {
                this.errorMessage = "Не е посочена парола";
                this.errorFunc(this.errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if(this.userName.Length < MIN_LENGHT)
            {
                this.errorMessage = "Потребителското име съдържа по-малко от 5 символа";
                this.errorFunc(this.errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            if (this.password.Length < MIN_LENGHT)
            {
                this.errorMessage = "Паролата съдържа по-малко от 5 символа";
                this.errorFunc(this.errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            user = UserData.IsUserPassCorrect(this.userName, this.password);

            if (user == null)
            {
                this.errorMessage = "Не съществува потребител със зададените потребителско име и парола";
                this.errorFunc(this.errorMessage);
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }

            currentUserName = this.userName;
            currentUserRole = (UserRoles)user.role;
            Logger.LogActivity("Успешен Login");
            return true;
        }
    }
}
