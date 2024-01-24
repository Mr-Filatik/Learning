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
            var result = MessageBox.Show("Text?", "Hello message", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("ДА");
            }
            if (result == MessageBoxResult.No)
            {
                MessageBox.Show("НЕТ");
            }

            //string? login = loginTextBox.Text;
            //string? password = passwordTextBox.Text;
            //if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password) && password == "1234")
            //{
            //    //MessageBox.Show($"ПРИВЕТ {login}");

            //}
        }
    }
}
