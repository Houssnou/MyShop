using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public class CategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Category> categories;

        public CategoryRepository()
        {
            categories = cache["categories"] as List<Category>;

            if (categories == null)
            {
                categories = new List<Category>();
            }
        }

        public void Commit()
        {
            cache["categories"] = categories;
        }

        // add a Category
        public void Insert(Category c)
        {
            categories.Add(c);
        }

        // update a Category
        public void Update(Category category)
        {
            Category categoryToUpdate = categories.Find(c => c.Id == category.Id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate = category;
            }
            else
            {
                throw new Exception("Product Category not found!");
            }
        }
        // Find a Category
        public Category Find(string Id)
        {
            Category categoryToFind = categories.Find(c => c.Id == Id);
            if (categoryToFind != null)
            {
                return categoryToFind;
            }
            else
            {
                throw new Exception("Product Category not found!");
            }
        }

        // List of categories
        public IQueryable<Category> ListCategories()
        {
            return categories.AsQueryable();
        }

        // Delete a Category
        public void Delete(string Id)
        {
            Category categoryToDelete = categories.Find(c => c.Id == Id);
            if (categoryToDelete != null)
            {
                categories.Remove(categoryToDelete);
            }
            else
            {
                throw new Exception("Product Category not found!");
            }
        }
    }
}
