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
    /// Interaction logic for E03.xaml
    /// </summary>
    public partial class E03 : UserControl
    {
        public E03()
        {
            InitializeComponent();
        }

        private int counter;
        public int Counter
        {
            get => counter;
            set
            {
                counter = Math.Clamp(value, 0, 9);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Content.ToString() == "-") Counter--;
                else if (button.Content.ToString() == "+") Counter++;
                display.Content = Counter;
                slider.Value = Counter;
            }
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                Counter = (int)slider.Value;
                display.Content = Counter;
            }
        }
    }
}
