using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Model
{
    public class Context: DbContext
    {
        public Context() : base()
        {

        }

        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
    }
}
