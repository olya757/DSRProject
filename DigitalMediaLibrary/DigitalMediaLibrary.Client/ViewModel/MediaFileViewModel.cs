using DigitalMediaLibrary.Client.Commands;
using DigitalMediaLibrary.ClassLibrary.Model;
using DigitalMediaLibrary.ClassLibrary.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Client.ViewModel
{
    public class MediaFileViewModel:ViewModel
    {
        private MediaFile mediaFile;

        public MediaFileViewModel()
        {
            mediaFile = new MediaFile();
            SaveFileCommand = new SaveFileCommand(this);
        }

        public MediaFileViewModel(MediaFile mediaFile)
        {
            this.mediaFile = mediaFile;
            SaveFileCommand = new SaveFileCommand(this);
        }

        public SaveFileCommand SaveFileCommand { get; set; }

        public long ID
        {
            get
            {
                return mediaFile.ID;
            }
        }

        public string FullName
        {
            get
            {
                return mediaFile.FullName;
            }
        }

        public string MediaTypeName
        {
            get
            {
                if (Category.MediaType is null)
                    Category.MediaType = MediaTypeDAL.GetMediaType(Category.ID_Type);
                return Category.MediaType.Name;
            }
        }

        public Category Category
        {
            get
            {
                if(mediaFile.Category is null)
                mediaFile.Category= CategoryDAL.GetCategory(mediaFile.ID_Category);
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
        public string Extension
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
         
        public bool Save()
        {
            return  MediaFileDAL.AddMediaFile(mediaFile);
        }
    }
}
