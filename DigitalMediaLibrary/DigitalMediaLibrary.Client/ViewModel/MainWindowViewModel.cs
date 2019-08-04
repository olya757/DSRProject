using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Client.ViewModel
{
    public class MainWindowViewModel
    {
        public CategoryTreeViewModel CategoryTreeViewModel { get; set; }
        public DirectoryTreeViewModel DirectoryTreeViewModel { get; set; }
        public IndexMediaFilesViewModel IndexMediaFilesViewModel { get; set; }

        public MainWindowViewModel()
        {
            CategoryTreeViewModel = new CategoryTreeViewModel();
            DirectoryTreeViewModel = new DirectoryTreeViewModel();
            IndexMediaFilesViewModel = new IndexMediaFilesViewModel();
            DirectoryTreeViewModel.OnChange += IndexMediaFilesViewModel.ChangeDirectory;
            CategoryTreeViewModel.OnChange += IndexMediaFilesViewModel.ChangeCategory;
        }
    }
}
