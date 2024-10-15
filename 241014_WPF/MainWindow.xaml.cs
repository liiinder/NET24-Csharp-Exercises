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

namespace _241014_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int clickCounter;
        public MainWindow()
        {
            InitializeComponent();

            myButton.Content = "HejHej: " + clickCounter;
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            clickCounter++;
            myButton.Content = "HejHej: " + clickCounter;
        }
    }
}