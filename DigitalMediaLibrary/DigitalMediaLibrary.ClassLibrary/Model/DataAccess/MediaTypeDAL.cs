using System.Collections.ObjectModel;
using System.Linq;


namespace DigitalMediaLibrary.ClassLibrary.Model.DataAccess
{
    public static class MediaTypeDAL
    {
        public static MediaType GetMediaType(long ID)
        {
            using(Context db = new Context())
            {
                if(db.MediaTypes.Any(mt => mt.ID == ID))
                    return db.MediaTypes.Where(mt => mt.ID == ID).First();
                return null;
            }
        }

        public static ObservableCollection<MediaType> GetMediaTypes()
        {
            using (Context db = new Context())
            {
                ObservableCollection<MediaType> mediaTypes = new ObservableCollection<MediaType>();
                foreach(var mt in db.MediaTypes)
                {
                    mediaTypes.Add(mt);
                }
                return mediaTypes;
            }
        }

        public static void DeleteMediaType(long ID)
        {
            using (Context db = new Context())
            {
                MediaType mediaType = GetMediaType(ID);
                if (mediaType is null)
                    return;
                db.MediaTypes.Remove(mediaType);
                db.SaveChanges();
            }
        }

        public static void SetMediatype(MediaType mediaType)
        {
            using (Context db = new Context())
            {
                if (db.MediaTypes.Any(mt => mt.ID == mediaType.ID))
                    db.MediaTypes.Remove(mediaType);
                db.MediaTypes.Add(mediaType);
                db.SaveChanges();
            }
        }
    }
}
