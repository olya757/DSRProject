using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DigitalMediaLibrary.Client.HelpUtils;

using System.Threading.Tasks;
using DigitalMediaLibrary.ClassLibrary.Model;
using System.Windows;
using System.Windows.Controls;

namespace DigitalMediaLibrary.Client.ViewModel
{
    public class CategoryTreeViewModel:ViewModel
    {
        public NodesTree NodesTree { get; set; }

        private Node currentNode;
        public Node CurrentNode
        {
            get
            {
                return currentNode;
            }
            set
            {
                currentNode = value;
                OnPropertyChanged("CurrentNode");
                OnChange(value);
            }
        }

        public CategoryTreeViewModel()
        {
            NodesTree = new NodesTree();
            currentNode = NodesTree.RootNodes[0].Nodes[0];
        }

        public delegate void CurrentNodeChanged(Node node);

        public event CurrentNodeChanged OnChange;

        public void SelectNode(object sender, RoutedEventArgs e)
        {
            CurrentNode = (Node)((TreeViewItem)e.OriginalSource).Header;
        }
    }
}
