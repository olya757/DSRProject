using DigitalMediaLibrary.Client.ViewModel;
using System;
using System.Windows;
using System.Windows.Input;

namespace DigitalMediaLibrary.Client.Commands
{
    public class SaveFileCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MediaFileViewModel mediaFileViewModel;

        public SaveFileCommand(MediaFileViewModel mediaFileViewModel)
        {
            this.mediaFileViewModel = mediaFileViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return !(mediaFileViewModel.Category is null);
        }

        public void Execute(object parameter)
        {
           if(!mediaFileViewModel.Save())
            {
                MessageBox.Show("Данный файл уже содержится в базе");
            }
        }
    }
}
