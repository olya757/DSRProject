using System.Data.Entity;


namespace DigitalMediaLibrary.ClassLibrary.Model
{
    public class Context: DbContext
    {
        public Context() : base("DbConnection")
        {
        }

        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
    }
}
