using FitnessTrackerApp.Model;
using FitnessTrackerApp.Service;
using FitnessTrackerApp.Utility;
using FitnessTrackerApp.View;
using System;
using System.Windows.Forms;

namespace FitnessTrackerApp
{
    internal static class Program
    {
       
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CreateDefaultUserIfNotExists();

            Application.Run(new LoginForm());
        }

        private static void CreateDefaultUserIfNotExists()
        {
            UserService userService = new UserService();

            if (userService.GetUserByName("Refa3e") != null)
            {
                return; 
            }

            User defaultUser = new User
            {
                Name = "Mohamed Refaie",
                Gender = Enumeration.Gender.MALE,
                UserName = "Refa3e",
                Password = PasswordManager.GetSaltedHash("1111"),
                Height = 183,
                DateofBirth = new DateTime(2006, 9, 14)
            };

            try
            {
                userService.AddNewUser(defaultUser);
                Console.WriteLine("تم إنشاء المستخدم الافتراضي بنجاح!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("حصل خطأ أثناء إنشاء المستخدم الافتراضي: " + ex.Message);
            }
        }
    }
}