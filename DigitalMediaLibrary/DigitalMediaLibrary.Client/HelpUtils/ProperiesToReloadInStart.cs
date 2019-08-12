using DigitalMediaLibrary.ClassLibrary.Model;
using DigitalMediaLibrary.ClassLibrary.Model.DataAccess;
using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace DigitalMediaLibrary.Client.HelpUtils
{
    [Serializable]
    public class Properties
    {
        public CategoryNode categoryNode { get; set; }
        public DirectoryNode directoryNode { get; set; }

        public Properties()
        {
            categoryNode = new CategoryNode(CategoryDAL.GetCategories().First());
            directoryNode = new DirectoryNode();
        }
    }

    public static class StartProperties
    {
        private static Properties Properties;

        public static string path = "StartProperies.xml";

        public static void SetCategory(Category category)
        {
            if(Properties is null)
            {
                Properties = Get();
            }
            Properties.categoryNode = new CategoryNode(category);
            Save(Properties);
        }

        public static void SetDirectory(string path)
        {
            if (Properties is null)
            {
                Properties = Get();
            }
            Properties.directoryNode = new DirectoryNode(path);
            Save(Properties);
        }

        private static Properties CreateNew()
        {
            var set = new Properties();
            var writer = new XmlSerializer(typeof(Properties));
            var wfile = new StreamWriter(@path);
            writer.Serialize(wfile, set);
            wfile.Close();
            return set;
        }

        public static Properties Get()
        {
            if (Properties != null)
                return Properties;
            if (!File.Exists(@path))
            {
                return CreateNew();
            }
            var Serializer = new XmlSerializer(typeof(Properties));
            var file = new StreamReader(@path);
            try
            {
                Properties properties = (Properties)Serializer.Deserialize(file);
                file.Close();
                Properties = properties;
                string directoryPath = Properties.directoryNode.FullPath;
                if (!File.Exists(directoryPath))
                {
                    return CreateNew();
                }
                return Properties;
            }
            catch (System.InvalidOperationException e)
            {
                file.Close();
                return CreateNew();
            }
        }

        public static void Save(Properties properies)
        {
            Properties = properies;
            var writer = new XmlSerializer(typeof(Properties));
            var wfile = new StreamWriter(@path);
            writer.Serialize(wfile, Properties);
            wfile.Close();
        }
    }
}
