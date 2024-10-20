using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for E03.xaml
    /// </summary>
    public partial class E03 : Window
    {
        public E03()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog(); // true if user chooses a file and not pressing cancel

            if (result == true)
            {
                output.Text = File.ReadAllText(dialog.FileName);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

// Skapa en applikation där hela fönstret består av en readonly TextBox.

// Programmet ska ha en meny med en File->Open som visar en OpenFileDialog,
// och en File->Exit som avslutar programmet.

// När användaren valt en fil i OpenFileDialog så ska filen läsas in och visas i TextBoxen.