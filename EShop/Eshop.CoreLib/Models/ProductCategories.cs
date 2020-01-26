using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.CoreLib.Models
{
    public class ProductCategories
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }

        public ProductCategories()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
