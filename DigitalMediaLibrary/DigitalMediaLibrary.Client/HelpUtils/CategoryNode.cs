using DigitalMediaLibrary.ClassLibrary.Model;
using DigitalMediaLibrary.ClassLibrary.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Client.HelpUtils
{
    public class Node:ViewModel.ViewModel
    {
        private bool isSelected;
        public bool IsSelected {
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
        public string Name { get; set; }

        public List<Node> Nodes { get; set; }
    }

    public class CategoryNode : Node
    {
        public Category Category { get; set; }
        public CategoryNode(Category category)
        {
            Category = category;
            Name = Category.Name;
            Nodes = null;
            IsSelected = false;
            IsExpanded = false;
        }

        public CategoryNode() {
            IsSelected = false;
            IsExpanded = false;
        }
    }

    public class MediaTypeNode : Node
    {
        public MediaType MediaType { get; set; }
        public MediaTypeNode(MediaType mediaType)
        {
            MediaType = mediaType;
            Name = MediaType.Name;
            Nodes = new List<Node>();
            var categories = CategoryDAL.GetCategories(MediaType.ID);
            foreach(var cat in categories)
            {
                Nodes.Add(new CategoryNode(cat));
            }
            IsExpanded = true;
        }
    }

    public class NodesTree
    {
        public List<MediaTypeNode> RootNodes { get; set; }

        public CategoryNode SelectedNode { get; set; }

        public NodesTree()
        {
            RootNodes = new List<MediaTypeNode>();
            var mediatypes = MediaTypeDAL.GetMediaTypes();
            foreach(var mt in mediatypes)
            {
                RootNodes.Add(new MediaTypeNode(mt));
            }
            SelectedNode = StartProperties.Get().categoryNode;
            foreach(var mn in RootNodes)
            {
                if (mn.MediaType.ID == (SelectedNode.Category.ID_Type)){
                    mn.IsExpanded = true;
                    foreach(var cat in mn.Nodes)
                    {
                        if (((CategoryNode)cat).Category.ID == SelectedNode.Category.ID)
                        {
                            SelectedNode = (CategoryNode)cat;
                            SelectedNode.IsSelected = true;
                            break;
                        }

                    }
                    break;
                }
            }
        }
    }
}
