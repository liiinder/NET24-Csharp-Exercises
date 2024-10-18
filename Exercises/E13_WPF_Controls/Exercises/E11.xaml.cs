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
    /// Interaction logic for E11.xaml
    /// </summary>
    public partial class E11 : UserControl
    {
        private int x = 10;
        private int y = 10;

        public E11()
        {
            InitializeComponent();

            Populate();
        }

        private void xPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                x = (int)slider.Value;
                Populate();
            }
        }

        private void yPos_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                y = (int)slider.Value;
                Populate();
            }
        }

        private void Populate()
        {
            grid.Children.Clear();
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();

            for (int i = 0; i < y; i++)
            {
                var rowDef = new RowDefinition();
                grid.RowDefinitions.Add(rowDef);
            }
            for (int i = 0; i < x; i++)
            {
                var colDef = new ColumnDefinition();
                grid.ColumnDefinitions.Add(colDef);

                for (int j = 0; j < y; j++)
                {
                    var label = new Label();
                    label.Content = (i + (j * x)).ToString();
                    label.HorizontalAlignment = HorizontalAlignment.Center;
                    label.VerticalAlignment = VerticalAlignment.Center;
                    Grid.SetColumn(label, i);
                    Grid.SetRow(label, j);
                    grid.Children.Add(label);
                }
            }
        }
    }
}
