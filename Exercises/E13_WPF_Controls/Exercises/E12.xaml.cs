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
    /// Interaction logic for E12.xaml
    /// </summary>
    public partial class E12 : UserControl
    {
        private readonly int x = 10;
        private readonly int y = 10;

        public E12()
        {
            InitializeComponent();

            Populate();
        }

        private void Populate()
        {
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
                    var button = new Button();
                    button.Name = "_" + (i + (j * x)).ToString();
                    button.Content = (i + (j * x)).ToString();
                    button.Click += Button_Click; 

                    Grid.SetColumn(button, i);
                    Grid.SetRow(button, j);
                    grid.Children.Add(button);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Int32.TryParse(button.Content.ToString(), out int value);
                
                if (value == 0) button.Content = button.Name[1..];
                else button.Content = value - 1;
            }
        }
    }
}
