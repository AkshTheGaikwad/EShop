using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Caching;
using EShop.Core.Models;

namespace EShop.DataAccess.INMemoryCache
{
   public class ProductRepository
    {
        ObjectCache Cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = Cache["Products"] as List<Product>;
            if(products==null)
            {
                products = new List<Product>();
            }



        }

        public void commitChanges()
        {
            Cache["Products"] = products;
        }

        public void AddProducts(Product prod)
        {
            products.Add(prod);
        }

        public void UpdateProduct(Product prod)
        {
            Product productToUpdate = products.Find(p => p.Id == prod.Id);
            if(productToUpdate == null)
            {
                productToUpdate = prod;
            }
            else
            {
                throw new Exception("No Product not found");
            }
        }
        public Product FindProduct(string id )
        {
            Product productToSearch = products.Find(p => p.Id == id);
            if (productToSearch == null)
            {
                return productToSearch;
            }
            else
            {
                throw new Exception("No Product not found");
            }
        }

        public void DeleteProduct(string id)
        {
            Product productToDelete = products.Find(p => p.Id == id);
            if (productToDelete == null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }

}
