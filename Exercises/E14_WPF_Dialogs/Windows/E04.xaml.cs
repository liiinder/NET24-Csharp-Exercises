using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
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
using System.Security.Cryptography;
using System.Diagnostics;

namespace E14_WPF_Dialogs.Windows
{
    /// <summary>
    /// Interaction logic for E04.xaml
    /// </summary>
    public partial class E04 : Window
    {
        private bool hasChanged;
        private string filePath = string.Empty;
        public E04()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            var result = new MessageBoxResult();

            if (hasChanged) result = SaveChanges();
            
            if (result != MessageBoxResult.Cancel)
            {
                var dialog = new OpenFileDialog();
                dialog.FileName = "Document"; // Default file name
                dialog.DefaultExt = ".txt"; // Default file extension
                dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

                var openResult = dialog.ShowDialog(); // true if user chooses a file and not pressing cancel

                if (openResult == true)
                {
                    textBox.Text = System.IO.File.ReadAllText(dialog.FileName);
                    Title = dialog.SafeFileName;
                    filePath = dialog.FileName;
                    hasChanged = false;
                    statusBar.Content = filePath;
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var result = new MessageBoxResult();
            if (hasChanged) result = SaveChanges();

            if (result != MessageBoxResult.Cancel) Application.Current.Shutdown();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Title[^1] != '*')
            {
                Title+= '*';
                hasChanged = true;
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            if (hasChanged)
            {
                if (SaveChanges() != MessageBoxResult.Cancel)
                {
                    textBox.Clear();
                    Title = "Untitled Document";
                    filePath = string.Empty;
                    hasChanged = false;
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem item)
            {
                if (item.Header == "Save _As...") SaveAs();
                else if (hasChanged && filePath.Length > 0) Save();
                else SaveAs();
            }
        }

        private void Save()
        {
            System.IO.File.WriteAllText(filePath, textBox.Text);
            Title = Title[..^1];
            hasChanged = false;
        }

        private void SaveAs()
        {
            var dialog = new SaveFileDialog();
            dialog.FileName = (Title[^1] == '*') ? Title[..^1] : Title; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension
            var result = dialog.ShowDialog();

            if (result == true)
            {
                System.IO.File.WriteAllText(dialog.FileName, textBox.Text);
                Title = dialog.SafeFileName;
                hasChanged = false;
            }
        }

        private MessageBoxResult SaveChanges()
        {
            MessageBoxResult result = MessageBox.Show(
                $"Do you want to save changes to {Title[..^1]}?",
                ".NETpad",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                if (filePath.Length > 0) Save();
                else SaveAs();
            }
            return result;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (hasChanged && SaveChanges() == MessageBoxResult.Cancel) e.Cancel = true;
        }
    }
}