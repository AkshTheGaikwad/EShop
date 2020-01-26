using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Eshop.CoreLib.Models;

namespace EShop.DataAccess.INMemoryCacheLib
{
   public  class ProductCategoriesRepository
    {
        ObjectCache Cache = MemoryCache.Default;
        List<ProductCategories> productCategories= new List<ProductCategories>();

        public ProductCategoriesRepository()
        {
            productCategories = Cache["productCategories"] as List<ProductCategories>;
            if (productCategories == null)
            {
                productCategories = new List<ProductCategories>();
            }



        }

        public void CommitChanges()
        {
            Cache["productCategories"] = productCategories;
        }

        public void AddProductCategoriess(ProductCategories prod)
        {
            productCategories.Add(prod);
        }

        public void Update(ProductCategories prod)
        {
            ProductCategories productCategoriesToUpdate = productCategories.Find(p => p.Id == prod.Id);
            if (productCategoriesToUpdate != null)
            {
                productCategoriesToUpdate = prod;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }
        public ProductCategories Find(string id)
        {
            ProductCategories productCategoryToSearch = productCategories.Find(p => p.Id == id);
            if (productCategoryToSearch != null)
            {
                return productCategoryToSearch;
            }
            else
            {
                throw new Exception("Product Category not found");
            }
        }

        public void Delete(string id)
        {
            ProductCategories productCategoryToDelete = productCategories.Find(p => p.Id == id);
            if (productCategoryToDelete != null)
            {
                productCategories.Remove(productCategoryToDelete);
            }
            else
            {
                throw new Exception("ProductCategories not found");
            }
        }
        public IQueryable<ProductCategories> Collection()
        {
            return productCategories.AsQueryable<ProductCategories>();
        }
    }
}
