using StudyLibraryProject.Entities;
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

namespace StudyWpfProject
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void OnRegisterClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"REGISTER NOT WORK");
        }

        private void OnLoginClick(object sender, RoutedEventArgs e)
        {
            string? login = loginTextBox.Text;
            string? password = passwordTextBox.Text;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && password == "1234")
            {
                (App.Current as App)?.Login(new User() { Id = 1, Name = login, HashPassword = password, Role = UserRole.Admin });

                //(App.Current as App).UserLogin = "HoHoHo";
                //}
                //else
                //{
                //    var win = this.OwnedWindows[0] as MainMenuWindow;
                //    if (win != null) win.UserLogin = login;

                //    foreach (var item in App.Current.Windows)
                //    {
                //        win = item as MainMenuWindow;
                //        var app = App.Current as App;
                //        if (win != null) win.UserLogin += $", hello! {app.UserLogin}";
                //    }
                //}
            }
        }
    }
}
