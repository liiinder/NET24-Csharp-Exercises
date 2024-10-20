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
    /// Interaction logic for E02.xaml
    /// </summary>
    public partial class E02 : Window
    {
        public E02()
        {
            InitializeComponent();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Do you really want to close the app?",
                "App about to be closed",
                MessageBoxButton.YesNo);

            if (result == MessageBoxResult.No) e.Cancel = true;
        }
    }
}
