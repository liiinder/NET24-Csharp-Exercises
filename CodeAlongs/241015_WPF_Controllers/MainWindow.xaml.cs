using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _241015_WPF_Controllers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            myComboBox.Items.Clear(); // rensar XAML'ens items och skapar dessa
            myComboBox.Items.Add(new Language("English", "Engelska"));
            myComboBox.Items.Add(new Language("Swedish", "Svenska"));
            myComboBox.Items.Add(new Language("Norwegian", "Norska"));
            myComboBox.DisplayMemberPath = "SwedishName";

            myListBox.Items.Add("Spain"); // Har typ samma saker som ComboBox
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myLabel.Content = myTextBox.Text;
            if (sender is Button button)
            {
                button.Content = myTextBox2.Text;
                var newItem = new Language(myTextBox.Text, myTextBox2.Text);
                myComboBox.Items.Add(newItem);
            }
        }

        private void myTextBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            myButton.Content = myTextBox2.Text;
        }

        private void myTextBox_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) myLabel.Content = "Enter";
            else if (e.Key == Key.Back) myLabel.Content = "Sudda";
            else myLabel.Content = e.Key;
        }

        private void myCheckBox_Click(object sender, RoutedEventArgs e)
        {
            myButton.IsEnabled = (myCheckBox.IsChecked == true);
        }

        private void myCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Turquoise, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.LightBlue, 0.33));
            myBrush.GradientStops.Add(new GradientStop(Colors.Violet, 0.66));
            myBrush.GradientStops.Add(new GradientStop(Colors.Pink, 1.0));

            myButton.Background = myBrush;
        }

        private void myCheckBox_Unchecked(object sender, RoutedEventArgs e) { }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                if (radioButton.IsChecked == true) myLabel.Content = radioButton.Content;
            }
        }

        private void mySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider) myLabel.Content = slider.Value.ToString("F2");
        }

        private void myComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                if (comboBox.SelectedItem is Language language)
                {
                    myTextBox.Text = language.EnglishName;
                    myTextBox2.Text = language.SwedishName;
                }
            }
        }
    }

    public class Language
    {
        public string EnglishName { get; set; }
        public string SwedishName { get; set; }
        public Language(string englishName, string swedishName)
        {
            EnglishName = englishName;
            SwedishName = swedishName;
        }
    }
}