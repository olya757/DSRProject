using DigitalMediaLibrary.ClassLibrary.Model;
using DigitalMediaLibrary.ClassLibrary.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Client.HelpUtils
{
    public enum MediaTypeEnum
    {
        picture,
        video,
        audio,
        undefined
    }
    public static class FileManager
    {
        public static MediaFile LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            FileInfo fileInfo = new FileInfo(path);
            MediaFile mediaFile = new MediaFile();
            mediaFile.DateOfCreation = fileInfo.CreationTime;
            mediaFile.Name = fileInfo.Name;
            mediaFile.Extension = fileInfo.Extension;
            mediaFile.FullName = fileInfo.FullName;
            MediaTypeEnum mediaType = GetMediaType(mediaFile.Extension);
            long ID_Type = 0;
            switch (mediaType)
            {
                case MediaTypeEnum.audio:ID_Type = 1;break;
                case MediaTypeEnum.video:ID_Type = 2;break;
                case MediaTypeEnum.picture:ID_Type = 3;break;
                case MediaTypeEnum.undefined:ID_Type = 4;break;
            }
            mediaFile.Category = CategoryDAL.GetCategories(ID_Type).First();
            mediaFile.ID_Category = mediaFile.Category.ID;
            //определить категорию
            try
            {
                mediaFile.Content = File.ReadAllBytes(@path);
            }
            catch(Exception e)
            {
                mediaFile.Content = null;
            }
            mediaFile.Size = fileInfo.Length;
            return mediaFile;
        }

        public static List<MediaFile> GetFilesFromDirectory(string path)
        {
            if (!Directory.Exists(path))
                return null;
            List<MediaFile> mediaFiles = new List<MediaFile>();
            try
            {
                foreach (var filePath in Directory.GetFiles(path))
                {
                    var file = LoadFile(filePath);
                    if (!(file is null))
                        mediaFiles.Add(file);
                }
            }
            catch(Exception e)
            {

            }
            return mediaFiles;
        }

        public static List<string> PictureExtensions = new List<string>() { ".png", ".jpg",".gif",".bmp" };
        public static List<string> VideoExtensions = new List<string>() { ".avi", ".mp4", ".mpg", ".asf",".mkv",".mov" };
        public static List<string> AudioExtensions = new List<string>() { ".wav", ".aif", ".mp3", ".mid"};



        public static MediaTypeEnum GetMediaType(string extension)
        {
            if (PictureExtensions.Contains(extension.ToLower()))
                return MediaTypeEnum.picture;
            if (VideoExtensions.Contains(extension.ToLower()))
                return MediaTypeEnum.video;
            if (AudioExtensions.Contains(extension.ToLower()))
                return MediaTypeEnum.audio;
            return MediaTypeEnum.undefined;
        }
    }
}
