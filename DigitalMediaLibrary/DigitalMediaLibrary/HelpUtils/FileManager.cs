using DigitalMediaLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.HelpUtils
{
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
            mediaFile.Content = File.ReadAllBytes(path);
            mediaFile.Size = fileInfo.Length;
            return mediaFile;
        }

        public static List<MediaFile> GetFilesFromDirectory(string path)
        {
            if (!Directory.Exists(path))
                return null;
            List<MediaFile> mediaFiles = new List<MediaFile>();
            foreach(var filePath in Directory.GetFiles(path))
            {
                var file = LoadFile(filePath);
                if (!(file is null))
                    mediaFiles.Add(file);
            }
            return mediaFiles;
        }
    }
}
