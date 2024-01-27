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



        private void TestClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button is not null)
            {
                MessageBox.Show(button.Content.ToString());
            }
        }

        private void EnterClick(object sender, RoutedEventArgs e)
        {
            //var result = MessageBox.Show("Text?", "Hello message", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            //if (result == MessageBoxResult.Yes)
            //{
            //    MessageBox.Show("ДА");
            //}
            //if (result == MessageBoxResult.No)
            //{
            //    MessageBox.Show("НЕТ");
            //}

            string? login = loginTextBox.Text;
            string? password = passwordTextBox.Text;
            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && password == "1234")
            {
                //MessageBox.Show($"ПРИВЕТ {login}");

                if (this.OwnedWindows.Count == 0) // проверка на отсутствие зависимых окон
                {
                    MainMenuWindow mainMenuWindow = new MainMenuWindow();
                    mainMenuWindow.UserLogin = login; // наше кастомное свойство для передачи данных
                    mainMenuWindow.Owner = this; // указание родительского окна
                    mainMenuWindow.Show();

                    (App.Current as App).UserLogin = "HoHoHo";
                }
                else
                {
                    var win = this.OwnedWindows[0] as MainMenuWindow;
                    if(win != null) win.UserLogin = login;

                    foreach (var item in App.Current.Windows)
                    {
                        win = item as MainMenuWindow;
                        var app = App.Current as App;
                        if (win != null) win.UserLogin += $", hello! {app.UserLogin}";
                    }
                }
                
                //this.Close();
            }
        }
    }
}
