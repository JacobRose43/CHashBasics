using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CalcApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static StackPanel CreateListItem(double number1, double number2, double result, string mathOption)
        {
            StackPanel sp = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };

            sp.Children.Add(
                new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5, 0, 5, 0),
                    Text = number1.ToString()
                });

            sp.Children.Add(
               new Label
               {
                   HorizontalAlignment = HorizontalAlignment.Center,
                   VerticalAlignment = VerticalAlignment.Center,
                   Margin = new Thickness(5, 0, 5, 0),
                   Content = mathOption
               }); ;

            sp.Children.Add(
                new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5, 0, 5, 0),
                    Text = number2.ToString()
                });

            sp.Children.Add(
               new Label
               {
                   HorizontalAlignment = HorizontalAlignment.Center,
                   VerticalAlignment = VerticalAlignment.Center,
                   Margin = new Thickness(5, 0, 5, 0),
                   Content = "="
               });

            sp.Children.Add(
                new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5, 0, 5, 0),
                    Text = result.ToString()
                });

            return sp;
        }

        public void ChangeColor(string mathContent)
        {
            Color myColor = new Color();
            myColor = Color.FromRgb(113, 113, 113);
            Brush myBrush = new SolidColorBrush(myColor);

            Plus_Btn.Background = Brushes.WhiteSmoke;
            Plus_Btn.Foreground = myBrush;
            Minus_Btn.Background = Brushes.WhiteSmoke;
            Minus_Btn.Foreground = myBrush;
            Multip_Btn.Background = Brushes.WhiteSmoke;
            Multip_Btn.Foreground = myBrush;
            Division_Btn.Background = Brushes.WhiteSmoke;
            Division_Btn.Foreground = myBrush;

            if (mathContent == "+")
            {
                Plus_Btn.Background = myBrush;
                Plus_Btn.Foreground = Brushes.WhiteSmoke;
            }
            if (mathContent == "-")
            {
                Minus_Btn.Background = myBrush;
                Minus_Btn.Foreground = Brushes.WhiteSmoke;
            }
            if (mathContent == "*")
            {
                Multip_Btn.Background = myBrush;
                Multip_Btn.Foreground = Brushes.WhiteSmoke;
            }
            if (mathContent == "/")
            {
                Division_Btn.Background = myBrush;
                Division_Btn.Foreground = Brushes.WhiteSmoke;
            }
        }

        public void BackColor()
        {
            if (Plus_Btn.Foreground == Brushes.WhiteSmoke || Minus_Btn.Foreground == Brushes.WhiteSmoke ||
                Multip_Btn.Foreground == Brushes.WhiteSmoke || Division_Btn.Foreground == Brushes.WhiteSmoke)
            {
                ChangeColor(String.Empty);
            }
        }

        public static void AllowValue(TextBox textBox, KeyEventArgs e)
        {
            if (int.TryParse(e.Key.ToString().Substring(1), out _) ||
                (e.Key.ToString() == "OemPeriod") || (e.Key.ToString() == "OemMinus"))
            {
                if (textBox.Text.Count(f => f == '.').Equals(0))
                {
                    e.Handled = false;
                }
                else
                {
                    if ((e.Key.ToString() == "OemPeriod") || (e.Key.ToString() == "OemMinus"))
                    {
                        e.Handled = true;
                    }
                    else
                    {
                        e.Handled = false;
                    }
                }
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Plus_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstNumber_Input.Text, out double number1) && double.TryParse(SecondNumber_Input.Text, out double number2))
            {
                double result = number1 + number2;
                Result_TextBlock.Text = result.ToString();

                History_ListBox.Items.Add(CreateListItem(number1, number2, result, "+"));
            }
            else if (!double.TryParse(SecondNumber_Input.Text, out _))
            {
                SecondNumber_Input.Text = String.Empty;
                SecondNumber_Input.Focus();
            }
            else
            {
                FirstNumber_Input.Text = String.Empty;
                SecondNumber_Input.Text = String.Empty;
                FirstNumber_Input.Focus();
            }

            BackColor();
        }

        private void Minus_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstNumber_Input.Text, out double number1) && double.TryParse(SecondNumber_Input.Text, out double number2))
            {
                double result = number1 - number2;
                Result_TextBlock.Text = result.ToString();

                History_ListBox.Items.Add(CreateListItem(number1, number2, result, "-"));
            }
            else if (!double.TryParse(SecondNumber_Input.Text, out _))
            {
                SecondNumber_Input.Text = String.Empty;
                SecondNumber_Input.Focus();
            }
            else
            {
                FirstNumber_Input.Text = String.Empty;
                SecondNumber_Input.Text = String.Empty;
                FirstNumber_Input.Focus();
            }

            BackColor();
        }

        private void Multip_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstNumber_Input.Text, out double number1) && double.TryParse(SecondNumber_Input.Text, out double number2))
            {
                if (number1 != 0 && number2 != 0)
                {
                    double result = Math.Round(number1 * number2, 2);
                    Result_TextBlock.Text = result.ToString();
                    History_ListBox.Items.Add(CreateListItem(number1, number2, result, "*"));
                }
                else if (number1 == 0 && number2 == 0)
                {
                    double result = number1;
                    Result_TextBlock.Text = result.ToString();
                    History_ListBox.Items.Add(CreateListItem(number1, number2, result, "*"));
                }
                else if (number2 == 0)
                {
                    double result = number2;
                    Result_TextBlock.Text = result.ToString();
                    History_ListBox.Items.Add(CreateListItem(number1, number2, result, "*"));
                }
                else if (number1 == 0)
                {
                    double result = number1;
                    Result_TextBlock.Text = result.ToString();
                    History_ListBox.Items.Add(CreateListItem(number1, number2, result, "*"));
                }
            }
            else if (!double.TryParse(SecondNumber_Input.Text, out _))
            {
                SecondNumber_Input.Text = String.Empty;
                SecondNumber_Input.Focus();
            }
            else
            {
                FirstNumber_Input.Text = String.Empty;
                SecondNumber_Input.Text = String.Empty;
                FirstNumber_Input.Focus();
            }

            BackColor();
        }

        private void Division_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstNumber_Input.Text, out double number1) && double.TryParse(SecondNumber_Input.Text, out double number2))
            {
                if ((number1 != 0) && (number2 != 0))
                {
                    double result = Math.Round(number1 / number2, 2);
                    Result_TextBlock.Text = result.ToString();

                    History_ListBox.Items.Add(CreateListItem(number1, number2, result, "/"));
                }
                else if (number1 != 0)
                {
                    SecondNumber_Input.Text = String.Empty;
                    SecondNumber_Input.Focus();
                }
                else
                {
                    FirstNumber_Input.Text = String.Empty;
                    SecondNumber_Input.Text = String.Empty;
                    FirstNumber_Input.Focus();
                }
            }
            else if (!double.TryParse(SecondNumber_Input.Text, out _))
            {

                SecondNumber_Input.Text = String.Empty;
                SecondNumber_Input.Focus();
            }
            else
            {
                FirstNumber_Input.Text = String.Empty;
                SecondNumber_Input.Text = String.Empty;
                FirstNumber_Input.Focus();
            }

            BackColor();
        }

        private void History_ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!(History_ListBox.Items.Count == 0))
            {
                Visual number1Selector = (Visual)VisualTreeHelper.GetChild((DependencyObject)History_ListBox.SelectedItem, 0);
                Visual number2Selector = (Visual)VisualTreeHelper.GetChild((DependencyObject)History_ListBox.SelectedItem, 2);
                Visual resultSelector = (Visual)VisualTreeHelper.GetChild((DependencyObject)History_ListBox.SelectedItem, 4);
                Visual signSelector = (Visual)VisualTreeHelper.GetChild((DependencyObject)History_ListBox.SelectedItem, 1);

                TextBlock number1 = (TextBlock)number1Selector;
                TextBlock number2 = (TextBlock)number2Selector;
                TextBlock result = (TextBlock)resultSelector;
                Label sign = (Label)signSelector;

                FirstNumber_Input.Text = number1.Text;
                SecondNumber_Input.Text = number2.Text;
                Result_TextBlock.Text = result.Text;

#pragma warning disable CS8604 // Possible null reference argument.
                ChangeColor(sign.Content.ToString());
#pragma warning restore CS8604 // Possible null reference argument.
            }
        }

        private void Reset_Btn_Click(object sender, RoutedEventArgs e)
        {
            History_ListBox.Items.Clear();
            FirstNumber_Input.Text = String.Empty;
            SecondNumber_Input.Text = String.Empty;
            Result_TextBlock.Text = String.Empty;
            FirstNumber_Input.Focus();
        }

        private void Clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            FirstNumber_Input.Text = String.Empty;
            SecondNumber_Input.Text = String.Empty;
            Result_TextBlock.Text = String.Empty;
            ChangeColor(String.Empty);
            FirstNumber_Input.Focus();
        }

        private void FirstNumber_Input_KeyDown(object sender, KeyEventArgs e)
        {
            AllowValue(FirstNumber_Input, e);
        }

        private void SecondNumber_Input_KeyDown(object sender, KeyEventArgs e)
        {
            AllowValue(SecondNumber_Input, e);
        }
    }
}