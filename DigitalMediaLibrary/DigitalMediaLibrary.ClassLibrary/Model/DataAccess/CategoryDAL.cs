using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalMediaLibrary.ClassLibrary.Model.DataAccess
{
    public static class CategoryDAL
    {
        public static Category GetCategory(long ID)
        {
            using(Context db=new Context())
            {
                var categories = db.Categories.Where(c => c.ID == ID);
                if (categories.Count() > 0)
                    return categories.First();
                return null;
            }
        }

        public static ObservableCollection<Category> GetCategories(long ID_type)
        {
            using (Context db = new Context())
            {
                ObservableCollection<Category> categories = new ObservableCollection<Category>();
                foreach (var category in db.Categories.Where(c=>c.ID_Type==ID_type))
                    categories.Add(category);
                return categories;
            }
        }

        public static ObservableCollection<Category> GetCategories()
        {
            using (Context db = new Context())
            {
                ObservableCollection<Category> categories = new ObservableCollection<Category>();
                foreach (var category in db.Categories)
                    categories.Add(category);
                return categories;
            }
        }

        public static void SetCategory(Category category)
        {
            using(Context db=new Context())
            {
                if (category is null)
                    return;
                if (db.Categories.Any(c => c.ID == category.ID))
                {
                    db.Categories.Remove(category);
                }
                db.Categories.Add(category);
                db.SaveChanges();
            }
        }

        public static void DeleteCategory(long ID)
        {
            using (Context db = new Context())
            {
                var categories = db.Categories.Where(c => c.ID == ID);
                if (categories.Count() == 0)
                    return;
                db.Categories.Remove(categories.First());
                db.SaveChanges();
            }
        }
    }
}
