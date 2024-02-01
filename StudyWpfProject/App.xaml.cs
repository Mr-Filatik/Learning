using StudyLibraryProject.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace StudyWpfProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public User? CurrentUser { get; private set; }

        public void Login(User user)
        {
            CurrentUser = user;

            MainMenuWindow mainMenuWindow = new MainMenuWindow();
            mainMenuWindow.Show();

            foreach (var item in Current.Windows)
            {
                if ((item as MainMenuWindow) == null)
                {
                    (item as Window)?.Close();
                }
            }
        }

        public void Logout()
        {
            CurrentUser = null;

            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();

            foreach (var item in Current.Windows)
            {
                if ((item as LoginWindow) == null)
                {
                    (item as Window)?.Close();
                }
            }
        }
    }
}
