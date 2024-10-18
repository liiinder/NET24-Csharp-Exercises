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
    /// Interaction logic for E10.xaml
    /// </summary>
    public partial class E10 : UserControl
    {
        private readonly int x = 10;
        private readonly int y = 10;

        public E10()
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
