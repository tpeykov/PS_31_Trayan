using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
    class Program
    {
        public static void ActionOnError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
        static void Main(string[] args)
        {
            saveTestUsers();
            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();

            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();

            Console.WriteLine();

            LoginValidation validator = new LoginValidation(userName, pass, ActionOnError);

            User user = null;

            if (validator.ValidateUserInput(ref user))
            {
                Console.WriteLine("Name: " + user.userName);
                Console.WriteLine("Pass: " + user.password);
                Console.WriteLine("Fac Num: " + user.facNumber);
                Console.WriteLine("Role: " + user.role);

                switch (Convert.ToInt32(LoginValidation.currentUserRole))
                {
                    case 0:
                        Console.WriteLine("Ролята на потребителя е: Анонимен");
                        break;
                    case 1:
                        Console.WriteLine("Ролята на потребителя е: Админ");

                        Boolean displayMenu = true;
                        while (displayMenu)
                        {
                            displayMenu = displayAdminMenu();
                        }

                        break;
                    case 2:
                        Console.WriteLine("Ролята на потребителя е: Инспектор");
                        break;
                    case 3:
                        Console.WriteLine("Ролята на потребителя е: Професор");
                        break;
                    case 4:
                        Console.WriteLine("Ролята на потребителя е: Студент");
                        break;
                }
            }
        }

        private static Boolean displayAdminMenu()
        {
            string userName;

            Console.WriteLine("Меню");
            Console.WriteLine("0: Изход");
            Console.WriteLine("1: Промяна на роля на потребител");
            Console.WriteLine("2: Промяна на активност на потребител");
            Console.WriteLine("3: Списък на потребителите");
            Console.WriteLine("4: Преглед на лог на активност");
            Console.WriteLine("5: Преглед на текуща активност");
            Console.Write("\r\nИзберете опция: ");

            switch (Console.ReadLine())
            {
                case "0":
                    return false;
                case "1":
                    Console.Write("\r\nВъведете потребителско име на потребителя който искате да редактирате: ");
                    userName = Console.ReadLine();

                    Console.Write("\r\nВъведете новата роля: ");
                    UserRoles role = (UserRoles)Convert.ToInt32(Console.ReadLine());

                    UserData.AssignUserRole(userName, role);

                    return true;
                case "2":
                    Console.Write("\r\nВъведете потребителско име на потребителя който искате да редактирате: ");
                    userName = Console.ReadLine();

                    Console.Write("\r\nВъведете новата дата: ");
                    DateTime date = Convert.ToDateTime(Console.ReadLine());

                    UserData.SetUserActiveTo(userName, date);

                    return true;
                case "3":
                    UserData.seeAllUsers();
                    return true;
                case "4":
                    IEnumerable<string> logs = Logger.GetLogsFromFile();
                    StringBuilder sb = new StringBuilder();

                    foreach (string log in logs)
                    {
                        sb.Append(log).Append(Environment.NewLine);
                    }

                    Console.WriteLine(sb.ToString());
                    return true;
                case "5":
                    Console.Write("\nВеведете филтър: ");
                    string filter = Console.ReadLine();

                    StringBuilder builder = new StringBuilder();
                    IEnumerable<string> currentActs = Logger.GetCurrentSessionActivities(filter);

                    foreach (string message in currentActs)
                    {
                        builder.Append(message).Append(Environment.NewLine);
                    }

                    Console.Write(builder.ToString());
                    return true;
                default:
                    return true;
            }
        }

        private static void saveTestUsers()
        {
            UserContext context = new UserContext();

            IEnumerable<User> queryUsers = context.Users;

            if (queryUsers.Count() == 0)
            {
                foreach (User user in UserData.TestUsers)
                {
                    context.Users.Add(user);
                }

                context.SaveChanges();
            }
        }
    }
}

