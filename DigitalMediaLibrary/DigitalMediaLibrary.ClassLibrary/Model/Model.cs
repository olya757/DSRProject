using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.ClassLibrary.Model
{
    public class MediaType
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }

        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        [Key]
        public long ID { get; set; }

        [ForeignKey("MediaType")]
        public long ID_Type { get; set; }
        public MediaType MediaType { get; set; }
        public string Name { get; set; }

        public List<MediaFile> MediaFiles { get; set; }
    }

    public class MediaFile
    {
        [Key]
        public long ID { get; set; }

        [ForeignKey("Category")]
        public long ID_Category { get; set; }
        public Category Category { get; set; }

        public string Name { get; set; }
        public string FullName { get; set; }
        public string Extension { get; set; }
        public DateTime DateOfCreation { get; set; }
        public double Size { get; set; }
        public byte[] Content { get; set; }
    }
}
