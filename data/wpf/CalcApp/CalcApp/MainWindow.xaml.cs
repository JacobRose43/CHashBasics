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
            Plus_Btn.Background = Brushes.WhiteSmoke;
            Plus_Btn.Foreground = Brushes.DarkGray;
            Minus_Btn.Background = Brushes.WhiteSmoke;
            Minus_Btn.Foreground = Brushes.DarkGray;
            Multip_Btn.Background = Brushes.WhiteSmoke;
            Multip_Btn.Foreground = Brushes.DarkGray;
            Division_Btn.Background = Brushes.WhiteSmoke;
            Division_Btn.Foreground = Brushes.DarkGray;

            if (mathContent == "+")
            {
                Plus_Btn.Background = Brushes.DarkGray;
                Plus_Btn.Foreground = Brushes.WhiteSmoke;
            }
            if (mathContent == "-")
            {
                Minus_Btn.Background = Brushes.DarkGray;
                Minus_Btn.Foreground = Brushes.WhiteSmoke;
            }
            if (mathContent == "*")
            {
                Multip_Btn.Background = Brushes.DarkGray;
                Multip_Btn.Foreground = Brushes.WhiteSmoke;
            }
            if (mathContent == "/")
            {
                Division_Btn.Background = Brushes.DarkGray;
                Division_Btn.Foreground = Brushes.WhiteSmoke;
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
        }

        private void Minus_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstNumber_Input.Text, out double number1) && double.TryParse(SecondNumber_Input.Text, out double number2))
            {
                double result = number1 - number2;
                Result_TextBlock.Text = result.ToString();

                History_ListBox.Items.Add(CreateListItem(number1, number2, result, "-"));
            }
        }

        private void Multip_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstNumber_Input.Text, out double number1) && double.TryParse(SecondNumber_Input.Text, out double number2))
            {
                double result = number1 * number2;
                Result_TextBlock.Text = result.ToString();

                History_ListBox.Items.Add(CreateListItem(number1, number2, result, "*"));
            }
        }

        private void Division_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(FirstNumber_Input.Text, out double number1) && double.TryParse(SecondNumber_Input.Text, out double number2))
            {
                if (number1 > 0 && number2 > 0)
                {
                    double result = Math.Round(number1 / number2, 3);
                    Result_TextBlock.Text = result.ToString();

                    History_ListBox.Items.Add(CreateListItem(number1, number2, result, "/"));
                }
            }
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

                ChangeColor(sign.Content.ToString());
            }
        }

        private void FirstNumber_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SecondNumber_Input_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Reset_Btn_Click(object sender, RoutedEventArgs e)
        {
            History_ListBox.Items.Clear();
            FirstNumber_Input.Text = "";
            SecondNumber_Input.Text = "";
            FirstNumber_Input.Focus();
        }
    }
}
