using DigitalMediaLibrary.ClassLibrary.Model;
using DigitalMediaLibrary.ClassLibrary.Model.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.Client.HelpUtils
{
    public class Node
    {
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
        }

        public CategoryNode() { }
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
        }
    }

    public class NodesTree
    {
        public List<MediaTypeNode> RootNodes { get; set; }

        public NodesTree()
        {
            RootNodes = new List<MediaTypeNode>();
            var mediatypes = MediaTypeDAL.GetMediaTypes();
            foreach(var mt in mediatypes)
            {
                RootNodes.Add(new MediaTypeNode(mt));
            }
        }
    }
}
