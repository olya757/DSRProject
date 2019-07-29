using DigitalMediaLibrary.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.ViewModel
{
    public class IndexMediaFilesViewModel:ViewModel
    {
        private ObservableCollection<MediaFileViewModel> mediaFiles;
        public ObservableCollection<MediaFileViewModel> MediaFiles {
            get
            {
                return mediaFiles;
            }
            set
            {
                mediaFiles = value;
                OnPropertyChanged("MediaFiles");
            }
        }

        public IndexMediaFilesViewModel()
        {
            mediaFiles = new ObservableCollection<MediaFileViewModel>();
        }

        private MediaFileViewModel selectedMediaFile;
        public MediaFileViewModel SelectedMediaFile
        {
            get
            {
                return selectedMediaFile;
            }
            set
            {
                selectedMediaFile = value;
                OnPropertyChanged("SelectedMediaFile");
            }
        }

        private string currentDirectory;

        public string CurrentDirectory
        {
            get
            {
                return currentDirectory;
            }
            set
            {
                currentDirectory = value;
                ReloadFiles(value);
                OnPropertyChanged("CurrentDirectory");
                OnPropertyChanged("MediaFiles");
            }
        }

        public void ChangeDirectory(string path)
        {
            CurrentDirectory = path;
        }

        private Category currentCategory;
        public Category CurrentCategory
        {
            get
            {
                return currentCategory;
            }
            set
            {
                currentCategory = value;
                OnPropertyChanged("CurrentCategory");
            }
        }

        public void ReloadFiles(string path)
        {
            MediaFiles = new ObservableCollection<MediaFileViewModel>();
            foreach(var mf in HelpUtils.FileManager.GetFilesFromDirectory(path))
            {
                MediaFiles.Add(new MediaFileViewModel(mf));
            }
        }
    }
}
