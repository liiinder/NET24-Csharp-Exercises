using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace E13_WPF_Controls
{
    /// <summary>
    /// Interaction logic for E04.xaml
    /// </summary>
    public partial class E04 : UserControl
    {
        private int x;
        private int y;
        public E04()
        {
            InitializeComponent();
            UpdateLabel();
        }

        private void xPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                x = (int)slider.Value;
                UpdateLabel();
            }
        }

        private void yPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                y = (int)slider.Value;
                UpdateLabel();
            }
        }
        
        private void UpdateLabel()
        {
            currentPosition.Content = $"x: {x}  y: {y}";
            Canvas.SetTop(currentPosition, y);
            Canvas.SetLeft(currentPosition, x);
        }
    }
}
