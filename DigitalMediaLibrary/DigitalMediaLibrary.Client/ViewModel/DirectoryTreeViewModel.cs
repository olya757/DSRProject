using DigitalMediaLibrary.Client.Commands;
using DigitalMediaLibrary.Client.HelpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DigitalMediaLibrary.Client.ViewModel
{
    public class DirectoryTreeViewModel:ViewModel
    {
        public DirectoryTree DirectoryTree { get; set; }

        private DirectoryNode currentNode;

        public DirectoryNode CurrentNode
        {
            get
            {
                return currentNode;
            }
            set
            {
                currentNode = value;
                OnPropertyChanged("CurrentNode");
                OnChange(value.FullPath);
            }
        }

        public delegate void CurrentNodeChanged(string path);

        public event CurrentNodeChanged OnChange;


        public NodeExpandCommand NodeExpandCommand { get; set; }
        public NodeSelectCommand NodeSelectCommand { get; set; }

        public DirectoryTreeViewModel()
        {
            DirectoryTree = new DirectoryTree();
            currentNode = DirectoryTree.Root;
            NodeExpandCommand = new NodeExpandCommand(this);
            NodeSelectCommand = new NodeSelectCommand(this);
        }

        public void ExpandNode(object sender, RoutedEventArgs e)
        {
            CurrentNode = (DirectoryNode)((TreeViewItem)e.OriginalSource).Header;
            CurrentNode.LoadSubdirs_NextLevels();
            OnPropertyChanged("DirectoryTree");
        }

        public void SelectNode(object sender, RoutedEventArgs e)
        {
            CurrentNode = (DirectoryNode)((TreeViewItem)e.OriginalSource).Header;
        }
    }
}
