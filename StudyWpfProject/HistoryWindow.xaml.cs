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
    /// Interaction logic for HistoryWindow.xaml
    /// </summary>
    public partial class HistoryWindow : Window
    {
        List<History> histories = new List<History>();

        public HistoryWindow()
        {
            InitializeComponent();

            histories.Add(new History() { Id = 1, Description = "Description 1", UserId = 1, Percent = 50F, DateTime = DateTime.UtcNow});
            histories.Add(new History() { Id = 2, Description = "Description 2", UserId = 2, Percent = 60F, DateTime = DateTime.UtcNow });
            histories.Add(new History() { Id = 3, Description = "...", UserId = 3, Percent = 30F, DateTime = DateTime.UtcNow });

            listView.ItemsSource = histories;
        }

        private void OnMainMenuClick(object sender, RoutedEventArgs e)
        {
            MainMenuWindow window = new MainMenuWindow();
            window.Show();
            this.Close();
        }
    }

    public class History
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public float Percent { get; set; }

        public override string ToString()
        {
            return $"{Id} {UserId} - {Description} - {DateTime}";
        }
    }
}
