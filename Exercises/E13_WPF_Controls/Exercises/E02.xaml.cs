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
    /// Interaction logic for E02.xaml
    /// </summary>
    public partial class E02 : UserControl
    {
        private int counter;
        public int Counter 
        {
            get => counter;
            set
            {
                counter = Math.Clamp(value, 0, 9);
            }
        }
        public E02()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Content.ToString() == "-") Counter--;
                else if (button.Content.ToString() == "+") Counter++;
                display.Content = Counter;
            }
        }
    }
}
