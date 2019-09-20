using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;

            if (products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        // add a product
        public void Insert(Product p)
        {
            products.Add(p);
        }

        // update a product
        public void Update(Product product)
        {
            Product productToUpdate = products.Find(p => p.Id == product.Id);
            if(productToUpdate != null)
            {
                productToUpdate = product;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }
        // Find a product
        public Product Find(string Id)
        {
            Product productToFind = products.Find(p => p.Id == Id);
            if (productToFind != null)
            {
                return productToFind;
            }
            else
            {
                throw new Exception("Product not found!");
            }
        }

        // list of prodcuts
        public IQueryable<Product> ListProducts()
        {
            return products.AsQueryable();
        }

        // delete a product
        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found!");
            }
        } 
    }
}
