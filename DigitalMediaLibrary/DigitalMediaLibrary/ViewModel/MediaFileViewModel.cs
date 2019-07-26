using DigitalMediaLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.ViewModel
{
    public class MediaFileViewModel:ViewModel
    {
        private MediaFile mediaFile;

        public MediaFileViewModel()
        {
            mediaFile = new MediaFile();
        }

        public MediaFileViewModel(MediaFile mediaFile)
        {
            this.mediaFile = mediaFile;
        }

        public long ID
        {
            get
            {
                return mediaFile.ID;
            }
        }

        public Category Category
        {
            get
            {
                return mediaFile.Category;
            }
            set
            {
                mediaFile.Category = value;
                if(!(value is null))
                    mediaFile.ID_Category = value.ID;
                OnPropertyChanged("Category");
            }
        }

        public string Name
        {
            get
            {
                return mediaFile.Name;
            }
            set
            {
                mediaFile.Name = value;
                OnPropertyChanged("Name");
            }
        }
        public string Extention
        {
            get
            {
                return mediaFile.Extension;
            }
            set
            {
                mediaFile.Extension = value;
                OnPropertyChanged("Extention");
            }
        }
        public DateTime DateOfCreation
        {
            get
            {
                return mediaFile.DateOfCreation;
            }
            set
            {
                mediaFile.DateOfCreation = value;
                OnPropertyChanged("DateOfCreation");
            }
        }
        public double Size
        {
            get
            {
                return mediaFile.Size;
            }
            set
            {
                mediaFile.Size = value;
                OnPropertyChanged("Size");
            }
        }
        public byte[] Content
        {
            get
            {
                return mediaFile.Content;
            }
            set
            {
                mediaFile.Content = value;
                OnPropertyChanged("Content");
            }
        }
         
    }
}
