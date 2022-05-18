using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers;
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static void ResetTestUserData()
        {
            if (_testUsers == null)
            {
                _testUsers = new List<User>();

                User firstUser = new User
                {
                    userName = "trayan",
                    password = "123456",
                    facNumber = "121219050",
                    role = 4,
                    created = DateTime.Now,
                    activeUntil = DateTime.MaxValue
                };

                _testUsers.Add(firstUser);

                User secondUser = new User
                {
                    userName = "Second Student",
                    password = "Second pass",
                    facNumber = "654321",
                    role = 4,
                    created = DateTime.Now,
                    activeUntil = DateTime.MaxValue
                };

                _testUsers.Add(secondUser);

                User adminUser = new User
                {
                    userName = "Admin",
                    password = "Admin pass",
                    facNumber = "65432198",
                    role = 1,
                    created = DateTime.Now,
                    activeUntil = DateTime.MaxValue
                };

                _testUsers.Add(adminUser);
            }
        }

        public static User IsUserPassCorrect(string userName, string pass)
        {
            UserContext context = new UserContext();

            User user = (from u in context.Users
                         where u.userName.Equals(userName) && u.password.Equals(pass)
                         select u).FirstOrDefault();

            return user;
        }

        public static void SetUserActiveTo(string userName, DateTime newDate)
        {
            UserContext context = new UserContext();

            foreach (User user in context.Users)
            {
                if (user.userName.Equals(userName))
                {
                    user.activeUntil = newDate;
                }
            }

            context.SaveChanges();
            Logger.LogActivity("Промяна на активност на " + userName);
        }

        public static void AssignUserRole(string userName, UserRoles role)
        {
            UserContext context = new UserContext();

            foreach (User user in context.Users)
            {
                if (user.userName.Equals(userName))
                {
                    user.role = Convert.ToInt32(role);
                }
            }

            context.SaveChanges();
            Logger.LogActivity("Промяна на роля на " + userName);
        }

        public static void seeAllUsers()
        {
            UserContext context = new UserContext();

            foreach (User user in context.Users)
            {
                Console.WriteLine("\nUsername: " + user.userName);
                Console.WriteLine("Role: " + user.role);
                Console.WriteLine("Faculty Number: " + user.facNumber);
                Console.WriteLine("Created: " + user.created);
                Console.WriteLine("Active until: " + user.activeUntil);
            }
        }
    }
}
