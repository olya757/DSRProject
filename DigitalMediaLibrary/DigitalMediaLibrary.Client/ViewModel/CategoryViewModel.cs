using DigitalMediaLibrary.ClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.ViewModel
{
    public class CategoryViewModel:ViewModel
    {
        private Category category;

        public CategoryViewModel()
        {
            category = new Category();
        }

        public CategoryViewModel(Category category)
        {
            this.category = category;
        }

        public long ID
        {
            get
            {
                return category.ID;
            }
        }

        public string Name
        {
            get
            {
                return category.Name;
            }
            set
            {
                category.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public MediaType MediaType
        {
            get
            {
                return category.MediaType;
            }
            set
            {
                category.MediaType = value;
                category.ID_Type = value.ID;
                OnPropertyChanged("MediaType");
            }
        }

        

    }
}
