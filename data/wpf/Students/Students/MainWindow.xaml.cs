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
using Microsoft.Win32;


namespace Students
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OpenFileDialog openFileDialog;

        public MainWindow()
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files | *.jpg; *.jpeg",
                Title = "Open Graphic File"
            };
            Image_Form.Source = null;
        }

        private void Image_Btn_Click(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                Image picutre = new Image
                {
                    Width = 75,
                    Height = 75,
                    Source = new BitmapImage(
                        new Uri(openFileDialog.FileName))
                };

                Image_Form.Source = (picutre as Image).Source;
            }
        }

        private void Firstname_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Firstname_Input.Text, @"^[a-zA-Z]+$"))
            {
                Firstname_Input.Text = String.Empty;
                Firstname_Input.Focus();
            }
        }

        private void Lastname_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(Lastname_Input.Text, @"^[a-zA-Z]+$"))
            {
                Lastname_Input.Text = String.Empty;
                Lastname_Input.Focus();
            }
        }

        private void Form_submit_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Firstname_Input.Text) && !string.IsNullOrWhiteSpace(Lastname_Input.Text) && !(Image_Form.Source==null))
            {
                StackPanel sp = new StackPanel
                {
                    Orientation = Orientation.Horizontal
                };

                sp.Children.Add(
                    new Image
                    {
                        Width = 75,
                        Height = 75,
                        Source = new BitmapImage(
                            new Uri(Image_Form.Source.ToString()))
                    }
                    );

                sp.Children.Add(new TextBlock
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(5, 0, 5, 0),
                    Text = $"{Firstname_Input.Text} {Lastname_Input.Text}"
                }); ;

                List_ListBox.Items.Add(sp);

                Firstname_Input.Text = String.Empty;
                Lastname_Input.Text = String.Empty;
                Image_Form.Source = null;
                Firstname_Input.Focus();

                //Create stack panel inside ListBox, as item, putting data in stack panel
            }
        }

        private void List_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

                Visual imageChild = (Visual)VisualTreeHelper.GetChild((DependencyObject)List_ListBox.SelectedItem, 0);
            // get first children 
                Visual textBoxChild = (Visual)VisualTreeHelper.GetChild((DependencyObject)List_ListBox.SelectedItem, 1);
            // get second children 

                Image picture = (Image)imageChild;
                TextBlock text = (TextBlock)textBoxChild;
            // get it as Image and TextBlock
                
                Image_Display.Source = (picture as Image).Source;
                Name_TextBlock.Text = (text as TextBlock).Text;
            // Assignment


        }
    }
}
