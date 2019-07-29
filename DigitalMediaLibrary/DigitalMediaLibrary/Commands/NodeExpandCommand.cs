using DigitalMediaLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigitalMediaLibrary.Commands
{
    public class NodeExpandCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private DirectoryTreeViewModel DirectoryTreeViewModel;

        public NodeExpandCommand(DirectoryTreeViewModel directoryTree)
        {
            DirectoryTreeViewModel = directoryTree;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            //DirectoryTreeViewModel.ExpandNode();
        }
    }
}
