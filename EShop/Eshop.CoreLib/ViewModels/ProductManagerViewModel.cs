using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eshop.CoreLib.Models;

namespace Eshop.CoreLib.ViewModels
{
    public class ProductManagerViewModel
    {
       public Product product { get; set; }
        public IEnumerable<ProductCategories> productCategories { get; set; }
       
    }
}
