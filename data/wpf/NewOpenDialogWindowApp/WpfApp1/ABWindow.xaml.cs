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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy ABWindow.xaml
    /// </summary>
    public partial class ABWindow : Window
    {
        public ABWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(!double.TryParse(ATBox.Text,out double a))
            {
                MessageBox.Show("Błędna liczba w polu a!");
                ATBox.Focus();
                return;
            }
            if (!double.TryParse(BTBox.Text, out double b))
            {
                MessageBox.Show("Błędna liczba w polu b!");
                BTBox.Focus();
                return;
            }
            DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
