using DigitalMediaLibrary.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DigitalMediaLibrary.Client.Commands
{
    public class PauseMediaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private MediaFileViewModel MediaFileViewModel;
        public PauseMediaCommand(MediaFileViewModel mediaFileViewModel)
        {
            MediaFileViewModel = mediaFileViewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MediaElement mediaElement = (MediaElement)parameter;
            
            mediaElement.Pause();
        }
    }
}
