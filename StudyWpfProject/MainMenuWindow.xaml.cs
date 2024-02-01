using StudyLibraryProject.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace StudyWpfProject
{
    /// <summary>
    /// Interaction logic for MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {
        private int number = 0;
        public string UserLogin { get; set; }

        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void OnStartTestClick(object sender, RoutedEventArgs e)
        {
            TestWindow window = new TestWindow();
            window.Show();
            this.Close();
        }

        private void OnEditTestClick(object sender, RoutedEventArgs e)
        {
            EditWindow window = new EditWindow();
            window.Show();
            this.Close();
        }

        private void OnCheckHistoryClick(object sender, RoutedEventArgs e)
        {
            HistoryWindow window = new HistoryWindow();
            window.Show();
            this.Close();
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            (App.Current as App)?.Logout();
        }
    }
}
