using DigitalMediaLibrary.Client.HelpUtils;
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
                if(!(value is null))
                    OnChange(value.FullPath);
            }
        }

        public delegate void CurrentNodeChanged(string path);

        public event CurrentNodeChanged OnChange;

        public DirectoryTreeViewModel()
        {
            DirectoryNode directoryNode = StartProperties.Get().directoryNode;
            DirectoryTree = new DirectoryTree(directoryNode.FullPath);
            currentNode = DirectoryTree.StartNode;
        }
               
        public void ExpandNode(object sender, RoutedEventArgs e)
        {
            var head= (DirectoryNode)((TreeViewItem)e.OriginalSource).Header;
            if (head is null)
                return;
            CurrentNode = head;
            CurrentNode.LoadSubdirs_NextLevels();
            OnPropertyChanged("DirectoryTree");
        }

        public void SelectNode(object sender, RoutedEventArgs e)
        {
            CurrentNode = (DirectoryNode)((TreeViewItem)e.OriginalSource).Header;
        }
    }
}
