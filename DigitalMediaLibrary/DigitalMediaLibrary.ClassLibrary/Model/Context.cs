using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.ClassLibrary.Model
{
    public class Context: DbContext
    {
        //public static string _path = @"Data Source=MediaLibrary.db";
        public Context() : base("DbConnection")
        {
        }

        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
    }
}
