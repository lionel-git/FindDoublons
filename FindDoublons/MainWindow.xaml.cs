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
using Hasher;

namespace FindDoublons
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HashDBViewModel _hashDbViewModel;

        public MainWindow()
        {
            InitializeComponent();
            _hashDbViewModel= new HashDBViewModel();

            var h = new HashDb();
            var w = new FileWalker(h);
            w.WalkDirectory(@"c:\tmp");
            _hashDbViewModel.Hashes = h.GetAllHashes();

            DataContext = _hashDbViewModel;
        }

        private void StartScan_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void SelectDirectory_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
