using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Client.HelpUtils
{
    public class DirectoryNode:ViewModel.ViewModel
    {
        public string Name { get; set; }
        public string FullPath { get; set; }
        private bool isSelected;
             
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                    isSelected = value;
                    OnPropertyChanged("IsSelected");
            }

        }
        private bool isExpanded;
        public bool IsExpanded
        {
            get
            {
                return isExpanded;
            }
            set
            {
                isExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }
        public ObservableCollection<DirectoryNode> directoryNodes { get; set; }
        public List<DirectoryNode> pathToStart { get; set; }


        public DirectoryNode(string path)
        {
            IsSelected = false;
            IsExpanded = false;
            FullPath = path;
            DirectoryInfo directoryInfo = new DirectoryInfo(FullPath);
            Name = directoryInfo.Name;
        }


        public DirectoryNode()
        {
            IsSelected = false;
            IsExpanded = false;
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

        public DirectoryNode Init(string fullPath)
        {
            if (fullPath == "")
            {
                return this;
            }
            
            DirectoryInfo directoryInfo = new DirectoryInfo(fullPath);
            Stack<DirectoryInfo> directoryInfos = new Stack<DirectoryInfo>();
            while(!(directoryInfo is null))
            {
                directoryInfos.Push(directoryInfo);
                directoryInfo = directoryInfo.Parent;
            }
            pathToStart = new List<DirectoryNode>();
            var nodes = directoryNodes;
            DirectoryNode directoryNode=this;
            while (directoryInfos.Count > 0)
            {
                DirectoryInfo directory = directoryInfos.Pop();
                foreach(var n in nodes)
                {
                    if (n.FullPath == directory.FullName)
                    {
                        pathToStart.Add(n);
                        directoryNode = n;
                        nodes = n.directoryNodes;
                        n.LoadSubdirs_NextLevels();
                        break;
                    }
                }
            }
            return directoryNode;
        }
    }

    public class DirectoryTree
    {
        public DirectoryNode Root { get; set; }

        public DirectoryNode StartNode { get; set; }

        public List<DirectoryNode> PathToStart { get; set; }

        public DirectoryTree()
        {
            Root = new DirectoryNode();
            Root.LoadSubdirs_NextLevels();
            
        }

        public DirectoryTree(string fullPath)
        {
            Root = new DirectoryNode();
            Root.LoadSubdirs_NextLevels();
            StartNode = Root.Init(fullPath);
            PathToStart = Root.pathToStart;
            for (int i = 0; i < PathToStart.Count()-1; i++)
                PathToStart[i].IsExpanded = true;
            StartNode.IsSelected = true;
        }
    }
}
