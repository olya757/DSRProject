using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Model.DataAccess
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

        public static void SetMediaFile(MediaFile mediaFile)
        {
            using (Context db = new Context())
            {
                if (mediaFile is null)
                    return;
                if (db.MediaFiles.Any(mf => mf.ID == mediaFile.ID))
                    db.MediaFiles.Remove(mediaFile);
                db.MediaFiles.Add(mediaFile);
                db.SaveChanges();
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
