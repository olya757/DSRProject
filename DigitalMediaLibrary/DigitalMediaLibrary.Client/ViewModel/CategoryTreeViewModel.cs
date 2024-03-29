﻿using DigitalMediaLibrary.Client.HelpUtils;
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
                if(!(OnChange is null))
                OnChange(value);
            }
        }

        public CategoryTreeViewModel()
        {
            NodesTree = new NodesTree();
            CurrentNode = NodesTree.SelectedNode;
        }

        public delegate void CurrentNodeChanged(Node node);

        public event CurrentNodeChanged OnChange;

        public void SelectNode(object sender, RoutedEventArgs e)
        {
            CurrentNode = (Node)((TreeViewItem)e.OriginalSource).Header;
        }
    }
}
