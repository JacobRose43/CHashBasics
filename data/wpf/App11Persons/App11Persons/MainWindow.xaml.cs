using App11Persons.Classes;
using System.Windows;

namespace App11Persons
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AgeSlider.Value = 0;
            AgeTBlock.Text = "0";
            FNameTBox.Text = string.Empty;
            LNameTBox.Text = string.Empty;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (AgeSlider == null || AgeTBlock == null)
                return;
            AgeTBlock.Text = ((int)AgeSlider.Value).ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person newPerson = new Person(FNameTBox.Text, LNameTBox.Text, (int)AgeSlider.Value);

            if (PersonsLBox.Items.IndexOf(newPerson) == -1)
                PersonsLBox.Items.Add(newPerson);
            else
                MessageBox.Show("Już jest taki!");
            /*
            PersonsLBox.Items.Add(
                new Person(FNameTBox.Text,
                LNameTBox.Text,
                (int)AgeSlider.Value));
            */
        }

        private void PersonsLBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FNameTBox.Text = (PersonsLBox.SelectedItem as Person).FName;
            LNameTBox.Text = (PersonsLBox.SelectedItem as Person).LName;
            AgeSlider.Value = (PersonsLBox.SelectedItem as Person).Age;
        }
    }
}
