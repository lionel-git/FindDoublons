using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Hasher;
using Microsoft.Win32;

namespace FindDoublons
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HashDBViewModel _hashDbViewModel;

        private HashDb _hashDb;
        private FileWalker _fileWalker;

        public MainWindow()
        {
            InitializeComponent();

            _hashDb = new HashDb();
            _fileWalker = new FileWalker(_hashDb);

            _hashDbViewModel= new HashDBViewModel();
            DataContext = _hashDbViewModel;

            UpdateScan(@"c:\tmp");

            Width = 1200;
            Height = 600;
        }

        void UpdateScan(string path)
        {
            _fileWalker.WalkDirectory(path);
            _hashDbViewModel.Hashes.Clear();
            _hashDbViewModel.Hashes = new ObservableCollection<Hash>(_hashDb.GetAllHashes());
        }


        private void StartScan_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            openFileDialog.ValidateNames = false;
            openFileDialog.CheckFileExists = false;
            openFileDialog.CheckPathExists = true;

            openFileDialog.FileName = "Folder Selection";
            openFileDialog.ReadOnlyChecked = true;
            openFileDialog.Title = "Select Directory";
            openFileDialog.InitialDirectory = @"c:\"; // Mettre un directory std

            if (openFileDialog.ShowDialog() ?? false)
            {
                var s = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                Console.WriteLine(s);
                myStatus2.Text = s;
                UpdateScan(s);
            }




        }

    }
}
