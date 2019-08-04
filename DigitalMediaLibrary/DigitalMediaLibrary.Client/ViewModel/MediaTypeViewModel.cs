using DigitalMediaLibrary.ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.ViewModel
{
    public class MediaTypeViewModel:ViewModel
    {
        private MediaType mediaType;

        public MediaTypeViewModel()
        {
            mediaType = new MediaType();
        }

        public MediaTypeViewModel(MediaType mediaType)
        {
            this.mediaType = mediaType;
        }

        public long ID
        {
            get
            {
                return mediaType.ID;
            }
        }

        public string Name
        {
            get
            {
                return mediaType.Name;
            }
            set
            {
                mediaType.Name = value;
                OnPropertyChanged("Name");
            }
        }
    }
}
