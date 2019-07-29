using DigitalMediaLibrary.ViewModel;
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

namespace DigitalMediaLibrary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DirectoryTreeViewModel = new DirectoryTreeViewModel();
            DirectoriesTreeView.DataContext = DirectoryTreeViewModel;
            IndexMediaFilesViewModel = new IndexMediaFilesViewModel();
            MediaFilesListBox.DataContext = IndexMediaFilesViewModel;
            DirectoryTreeViewModel.OnChange += IndexMediaFilesViewModel.ChangeDirectory;
        }

        public DirectoryTreeViewModel DirectoryTreeViewModel { get; set; }
        public IndexMediaFilesViewModel IndexMediaFilesViewModel { get; set; }

        private void TreeView_Expanded(object sender, RoutedEventArgs e)
        {
            DirectoryTreeViewModel.ExpandNode(sender, e);
        }

        private void DirectoriesTreeView_Selected(object sender, RoutedEventArgs e)
        {
            DirectoryTreeViewModel.SelectNode(sender, e);
        }
    }
}
