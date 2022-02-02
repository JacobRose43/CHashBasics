using Microsoft.Win32;
using System.Windows;
using System.IO;

namespace EditorApp
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
            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Otwieranie Pliku";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Pliki tekstowe |*.txt|Wszystkie Pliku|*.*";
            openFileDialog.FilterIndex = 1;
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            bool? result = openFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                MainTextBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
    }
}
