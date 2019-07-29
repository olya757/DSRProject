using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.HelpUtils
{
    public class DirectoryNode
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        public ObservableCollection<DirectoryNode> directoryNodes { get; set; }

        public DirectoryNode(string path)
        {
            FullPath = path;
            DirectoryInfo directoryInfo = new DirectoryInfo(FullPath);
            Name = directoryInfo.Name;
        }

        public DirectoryNode()
        {
            Init();
            FullPath = "";
            Name = "/..";
        }

        public void LoadSubdirs_NextLevels()
        {
            if ( directoryNodes is null || directoryNodes.Count() == 0)
                return;
            foreach(var subdir in directoryNodes)
            {
                if(subdir.directoryNodes is null)
                    subdir.LoadSubdirs();
            }
        }

        public bool LoadSubdirs()
        {
            if (Directory.Exists(FullPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(FullPath);
                Name = directoryInfo.Name;
                directoryNodes = new ObservableCollection<DirectoryNode>();
                try
                {
                    var collection = Directory.GetDirectories(FullPath);
                    foreach (var subdir in collection)
                    {
                        DirectoryNode node = new DirectoryNode(subdir);
                        directoryNodes.Add(node);
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }
            return false;
        }

        public void Init()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            directoryNodes = new ObservableCollection<DirectoryNode>();
            foreach(var d in drives)
            {
                directoryNodes.Add(new DirectoryNode(d.RootDirectory.FullName));
            }
        }
    }

    public class DirectoryTree
    {
        public DirectoryNode Root { get; set; }

        public DirectoryTree()
        {
            Root = new DirectoryNode();
            Root.LoadSubdirs_NextLevels();
        }
    }
}
