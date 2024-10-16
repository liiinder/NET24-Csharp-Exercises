using Microsoft.Win32;
using System;
using System.Collections;
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

namespace E12_XAML
{
    /// <summary>
    /// Interaction logic for E08.xaml
    /// </summary>
    public partial class E08 : UserControl
    {
        public E08()
        {
            InitializeComponent();

            listOfStudents.Items.Add(new Student("Kalle", "Andersson", "kaand@iths.se"));
            listOfStudents.Items.Add(new Student("Anders", "Karlsson", "ankar@iths.se"));
            listOfStudents.Items.Add(new Student("Camilla", "Johansson", "cajoh@iths.se"));
            listOfStudents.Items.Add(new Student("Johan", "Svensson", "josve@iths.se"));
            listOfStudents.Items.Add(new Student("Mia", "Karlsson", "mikar@iths.se"));
        }

        private void listOfStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListBox box)
            {
                if (e.AddedItems.Count > 0)
                {
                    var last = e.AddedItems[0];
                    foreach (var item in new ArrayList(box.SelectedItems))
                    {
                        if (item != last) box.SelectedItems.Remove(item);
                    }
                }

                if (box.SelectedItem is Student student && box.SelectedItems.Count > 0)
                {
                    firstName.Text = student.FirstName;
                    lastName.Text = student.LastName;
                    email.Text = student.Email;
                    confirmButton.Content = "Save";
                    removeButton.Visibility = Visibility.Visible;
                }
                else
                {
                    firstName.Text = string.Empty;
                    lastName.Text = string.Empty;
                    email.Text = string.Empty;
                    confirmButton.Content = "Add";
                    removeButton.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listOfStudents.SelectedItems.Count == 1)
            {
                if (listOfStudents.SelectedItem is Student student)
                {
                    MessageBoxResult result = MessageBox.Show(
                        $"Do you want to save changes to {firstName.Text} {lastName.Text}",
                        "Save changes",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        student.FirstName = firstName.Text;
                        student.LastName = lastName.Text;
                        student.Email = email.Text;
                        listOfStudents.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Do you want to add {firstName.Text} {lastName.Text}?",
                    "Add Student",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    listOfStudents.Items.Add(
                    new Student(
                        firstName.Text,
                        lastName.Text,
                        email.Text));
                }
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Do you want to remove {firstName.Text} {lastName.Text}?",
                    "Remove Student",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    if (ExtraConfirm()) listOfStudents.Items.Remove(listOfStudents.SelectedItem);
                }
            }
        }

        private void Change_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) Button_Click(sender, e);
        }

        /// <summary>
        /// Just an extra Confirm to annoy people
        /// </summary>
        /// <returns>
        /// True or False depending on which button that is pressed
        /// </returns>
        private bool ExtraConfirm()
        {
            MessageBoxResult result = MessageBox.Show(
                $"Are you 100% sure?",
                "Confirm the confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Stop);

            if (result == MessageBoxResult.Yes) return true;
            return false;
        }
    }

    public class Student
    {
        public Student(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
