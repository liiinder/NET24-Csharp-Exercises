using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _241015_WPF_Windows_and_Dialogs
{
    /// <summary>
    /// Interaction logic for MessageBoxes.xaml
    /// </summary>
    public partial class MessageBoxes : UserControl
    {
        public MessageBoxes()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(); // true if user chooses a file and not pressing cancel

            if (result == true)
            {
                buttonOpenFile.Content = System.IO.Path.GetFileName(dialog.FileName);
            }
        }

        private void buttonSaveFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            var result = dialog.ShowDialog();

            if (result == true)
            {
                buttonSaveFile.Content = System.IO.Path.GetFileName(dialog.FileName);
            }
        }

        private void showMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "This is a message?",
                "Important message",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Yes");
            }
            else MessageBox.Show("What?");
        }

        private void buttonPrint_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PrintDialog();
            var result = dialog.ShowDialog();

            if (result == true)
            {
                buttonPrint.Content = "Printed!";
            }
        }
    }
}
