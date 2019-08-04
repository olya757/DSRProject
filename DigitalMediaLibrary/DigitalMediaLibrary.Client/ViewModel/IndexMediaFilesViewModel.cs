﻿using DigitalMediaLibrary.ClassLibrary.Model;
using DigitalMediaLibrary.ClassLibrary.Model.DataAccess;
using DigitalMediaLibrary.Client.HelpUtils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Client.ViewModel
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
            currentMediaType = MediaTypeDAL.GetMediaTypes().First();
            currentDirectory = DriveInfo.GetDrives().First().RootDirectory.FullName;
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
                ReloadFiles();
                OnPropertyChanged("CurrentDirectory");
                OnPropertyChanged("MediaFiles");
            }
        }

        public void ChangeDirectory(string path)
        {
            CurrentDirectory = path;
        }

        public void ChangeCategory(Node node)
        {
            if(node is CategoryNode)
            {
                CurrentCategory = ((CategoryNode)node).Category;
            }
            else
            {
                if(node is MediaTypeNode)
                {
                    CurrentMediaType = ((MediaTypeNode)node).MediaType;
                }
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
                CurrentMediaType = MediaTypeDAL.GetMediaType( value.ID_Type);
            }
        }

        private MediaType currentMediaType;
        public MediaType CurrentMediaType
        {
            get
            {
                return currentMediaType;
            }
            set
            {
                currentMediaType = value;
                OnPropertyChanged("CurrentMediaType");
                if (!(value is null))
                {
                    if (currentCategory is null || currentCategory.ID_Type != value.ID)
                        currentCategory = CategoryDAL.GetCategories(value.ID).First();
                    ReloadFiles();
                }
            }
        }

        public void ReloadFiles()
        {
            MediaFiles = new ObservableCollection<MediaFileViewModel>();
            foreach (var mf in HelpUtils.FileManager.GetFilesFromDirectory(CurrentDirectory))
            {
                if (mf.Category.ID_Type == CurrentMediaType.ID)
                {
                    mf.Category = CurrentCategory;
                    MediaFiles.Add(new MediaFileViewModel(mf));
                }

                    
            }
        }

    }
}