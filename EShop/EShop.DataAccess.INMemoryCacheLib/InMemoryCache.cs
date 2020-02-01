using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using Eshop.CoreLib.Models;
using EShop.CoreLib;

namespace EShop.DataAccess.INMemoryCacheLib 
{
    public class InMemoryCache<T> : ICache<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;


        public InMemoryCache()
        {
            className = typeof(T).Name;
            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void CommitChanges()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            if (t != null)
            {
                items.Add(t);
            }
            else
            {
                throw new Exception(className + "Not found");
            }
        }

        public T Find(string id)
        {
            T tToSearch = items.Find(t => t.Id == id);
            if (tToSearch == null)
            {
                throw new Exception(className + "Not found");
            }
            else
            {
                return tToSearch;
            }
        }
        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id);
            if (tToUpdate == null)
            {
                throw new Exception(className + "Not found");
            }
            else
            {
                tToUpdate = t;
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string id)
        {
            T tToDelete = items.Find(t => t.Id == id);
            if (tToDelete == null)
            {
                throw new Exception(className + "Not found");
            }
            else
            {
                items.Remove(tToDelete);
            }
        }
    }
}
