using System.Collections.ObjectModel;
using System.Linq;


namespace DigitalMediaLibrary.ClassLibrary.Model.DataAccess
{
    public static class MediaFileDAL
    {
        public static MediaFile GetMediaFile(long ID)
        {
            using (Context db = new Context())
            {
                var mediaFiles = db.MediaFiles.Where(mf => mf.ID == ID);
                if (mediaFiles.Count() > 0)
                    return mediaFiles.First();
                return null;
            }
        }

        public static ObservableCollection<MediaFile> GetMediaFiles()
        {
            using (Context db = new Context())
            {
                ObservableCollection<MediaFile> MediaFiles = new ObservableCollection<MediaFile>();
                foreach (var mediaFile in db.MediaFiles)
                    MediaFiles.Add(mediaFile);
                return MediaFiles;
            }
        }

        public static bool AddMediaFile(MediaFile mediaFile)
        {
            if (mediaFile is null)
                return false;
            using (Context db = new Context())
            {
                mediaFile.Category = null;
                if (db.MediaFiles.Any(mf => mf.ID == mediaFile.ID || mf.FullName == mediaFile.FullName))
                {
                    mediaFile.Category = CategoryDAL.GetCategory(mediaFile.ID_Category);
                    return false;
                }
                db.MediaFiles.Add(mediaFile);
                db.SaveChanges();
                mediaFile.Category = CategoryDAL.GetCategory(mediaFile.ID_Category);
                return true;
            }
        }

        public static void DeleteMediaFile(long ID)
        {
            using (Context db = new Context())
            {
                var mediaFiles = db.MediaFiles.Where(mf => mf.ID == ID);
                if (mediaFiles.Count() == 0)
                    return;
                db.MediaFiles.Remove(mediaFiles.First());
                db.SaveChanges();
            }
        }
    }
}
