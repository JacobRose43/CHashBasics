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
        private SaveFileDialog saveFileDialog;
        private string fullPathFileName;
        public MainWindow()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Otwieranie Pliku";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Pliki tekstowe |*.txt|Wszystkie Pliku|*.*";
            openFileDialog.FilterIndex = 1;

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Zapisywanie Pliku";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = openFileDialog.Filter;
            saveFileDialog.FilterIndex = 1; 
        }

        private void MenuItem_Open_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fullPathFileName))
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(fullPathFileName);
                openFileDialog.FileName = Path.GetFileName(fullPathFileName);
            }
            bool? result = openFileDialog.ShowDialog();
            //false if click "x" in dialog box;

            if (result.HasValue && result.Value)
            { 
                fullPathFileName = openFileDialog.FileName;
                MainTextBox.Text = File.ReadAllText(fullPathFileName);
                fileNameTextBlock.Text = Path.GetFileName(fullPathFileName);
            }
        }

        private void MenuItem_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(fullPathFileName))
            {
                saveFileDialog.InitialDirectory = Path.GetDirectoryName(fullPathFileName);
                saveFileDialog.FileName = Path.GetFileName(fullPathFileName); 
            }

            bool? result = saveFileDialog.ShowDialog();
            if (result.HasValue && result.Value)
            {
                fullPathFileName = saveFileDialog.FileName;
                File.WriteAllText(fullPathFileName, MainTextBox.Text);
                fileNameTextBlock.Text = Path.GetFileName(fullPathFileName);
            }
        }
    }
}
