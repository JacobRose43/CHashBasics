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

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {ABWindow abDialog = new ABWindow();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buton1_Click(object sender, RoutedEventArgs e)
        {
            
            // zmienna abDialog, 
            bool? result =  abDialog.ShowDialog();
            if(result.HasValue && result.Value)
            {
                double a = double.Parse(abDialog.ATBox.Text), 
                       b = double.Parse(abDialog.BTBox.Text);
                ResultTBlock.Text = $"{a}+{b} ={a+b}";
            }

        }
    }
}
