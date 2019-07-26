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
        private List<MediaFileViewModel> mediaFiles;
        public List<MediaFileViewModel> MediaFiles {
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
            mediaFiles = new List<MediaFileViewModel>();
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
            }
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
            MediaFiles = new List<MediaFileViewModel>();
            foreach(var mf in HelpUtils.FileManager.GetFilesFromDirectory(path))
            {
                MediaFiles.Add(new MediaFileViewModel(mf));
            }
        }
    }
}
