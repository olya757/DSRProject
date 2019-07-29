﻿using DigitalMediaLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DigitalMediaLibrary.Commands
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
            return true;
        }

        public void Execute(object parameter)
        {
            mediaFileViewModel.Save();
        }
    }
}