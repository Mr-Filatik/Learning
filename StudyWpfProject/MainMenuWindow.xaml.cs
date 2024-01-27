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
        public string UserLogin 
        {
            get 
            {
                return textBlock.Text; 
            }
            set 
            {
                textBlock.Text = value;
            }
        }

        List<RadioButton> radioButtons = new List<RadioButton>();

        public MainMenuWindow()
        {
            InitializeComponent();

            //spawnPanel
            //< RadioButton x: Name = "rcheck3" GroupName = "g1" > Button 3 </ RadioButton >
            //    < Button Width = "100" Click = "GetResultForGroup" ></ Button >
            for (int i = 0; i < 7; i++)
            {
                RadioButton radioButton = new RadioButton();
                radioButton.Content = $"Button {i + 1}";
                radioButton.GroupName = "g11";

                radioButtons.Add(radioButton);
                spawnPanel.Children.Add(radioButton);
            }

            Button button = new Button();
            button.Content = "Подать ответ";
            button.Width = 100;
            button.Click += GetResultFor2Group;

            spawnPanel.Children.Add(button);
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string expression = "2+3-(12*4)";

            DataTable dt = new DataTable();
            var result = dt.Compute(expression, string.Empty); //+ TryParse

            textBlock.Text = result.ToString();
            //textBlock.Text = (number++).ToString();
            //if (check1.IsChecked == true)
            //{
            //    textBlock.Text = true.ToString();
            //}
        }

        private void ButtonChecked(object sender, RoutedEventArgs e)
        {
            textBlock.Text += "*";
        }

        private void ButtonUnchecked(object sender, RoutedEventArgs e)
        {
            if (textBlock.Text[^1] == '*')
            {
                textBlock.Text = textBlock.Text.Replace("*", "");
            }
        }

        private void CheckedCheckBox(object sender, RoutedEventArgs e)
        {
            check3.IsChecked = null;
        }

        private void GetResultForGroup(object sender, RoutedEventArgs e)
        {
            int result = 0;
            if (rcheck1.IsChecked == true)
            {
                result = 1;
            }
            if (rcheck2.IsChecked == true)
            {
                result = 2;
            }
            if (rcheck3.IsChecked == true)
            {
                result = 3;
            }
            (sender as Button).Content = result.ToString();
        }

        private void GetResultFor2Group(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].IsChecked == true)
                {
                    MessageBox.Show($"Выбран ответ: {i + 1}");
                }
            }
        }

        private void SliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            textSlider.Text = slider.Value.ToString();
        }
    }
}
