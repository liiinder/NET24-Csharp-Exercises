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

namespace E13_WPF_Controls
{
    /// <summary>
    /// Interaction logic for E05.xaml
    /// </summary>
    public partial class E05 : UserControl
    {
        private double x;
        private double y;

        public E05()
        {
            InitializeComponent();
            UpdateLabel();
        }

        private void position_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                if (xLock.IsChecked == false) x = position.Value;
                if (yLock.IsChecked == false) y = position.Value;
                UpdateLabel();
            }
        }
        private void UpdateLabel()
        {
            currentPosition.Content = $"x: {(int)x}  y: {(int)y}";
            Canvas.SetTop(currentPosition, y);
            Canvas.SetLeft(currentPosition, x);
        }

        private void Lock_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox box)
            {
                if (box.IsChecked == false)
                {
                    if (box.Name == "xLock") x = position.Value;
                    else if (box.Name == "yLock") y = position.Value;
                    UpdateLabel();
                }
            }
        }
    }
}
