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

namespace wzw13Aka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            number1Tbox.Text = string.Empty;
            number2Tbox.Text = string.Empty;
            number1Tbox.ToolTip = "Enter number>0";
            number2Tbox.ToolTip = "Enter number>0";
            resultTblock.ToolTip = "Your result";
        }

        private void number1Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void number2Tbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            double number1;
            double number2;


            if (!string.IsNullOrWhiteSpace(number2Tbox.Text) && !double.TryParse(number2Tbox.Text, out number2))
            {
                number2Tbox.Text = string.Empty;
                if(!double.TryParse(number1Tbox.Text, out number1))
                {
                    number1Tbox.Text = string.Empty;
                    number1Tbox.Focus();
                } else
                {
                    number2Tbox.Focus();
                }
                
            }
            else if(!string.IsNullOrWhiteSpace(number1Tbox.Text) && !double.TryParse(number1Tbox.Text, out number1))
            {

                number1Tbox.Text = string.Empty;
                number2Tbox.Text = string.Empty;
                number1Tbox.Focus();
            }
            else
            {

                double.TryParse(number1Tbox.Text, out number1);
                double.TryParse(number2Tbox.Text, out number2);

                if(number2 < 0)
                {
                    number2Tbox.Text = string.Empty;
                    number2Tbox.Focus();
                }
                else if(number1 < 0)
                {
                    number1Tbox.Text = string.Empty;
                    number2Tbox.Text = string.Empty;
                    number1Tbox.Focus();
                }
                else
                {
                    double result = number1 * number2;

                    resultTblock.Text = result.ToString();
                }

            } 

        }
    }
}
