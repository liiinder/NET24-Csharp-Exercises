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

namespace E14_WPF_Dialogs.Windows
{
    /// <summary>
    /// Interaction logic for E01.xaml
    /// </summary>
    public partial class E01 : Window
    {
        public E01()
        {
            MessageBoxResult result = MessageBox.Show(
                "Application is about to start!", 
                "App starting",
                MessageBoxButton.OK);

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Application started!",
                "App started",
                MessageBoxButton.OK);
        }
    }
}

