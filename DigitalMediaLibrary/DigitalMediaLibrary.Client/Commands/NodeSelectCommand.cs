using DigitalMediaLibrary.Client.HelpUtils;
using DigitalMediaLibrary.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigitalMediaLibrary.Client.Commands
{
    public class NodeSelectCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private DirectoryTreeViewModel DirectoryTreeViewModel;

        public NodeSelectCommand(DirectoryTreeViewModel directoryTreeViewModel)
        {
            DirectoryTreeViewModel = directoryTreeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DirectoryTreeViewModel.CurrentNode = (DirectoryNode)parameter;
        }
    }
}
