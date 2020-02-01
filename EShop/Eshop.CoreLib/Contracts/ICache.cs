using System.Linq;
using Eshop.CoreLib.Models;

namespace EShop.CoreLib
{
    public interface ICache<T> where T : BaseEntity
    {
        IQueryable<T> Collection();
        void CommitChanges();
        void Delete(string id);
        T Find(string id);
        void Insert(T t);
        void Update(T t);
    }
}