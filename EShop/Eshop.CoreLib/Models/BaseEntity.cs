using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eshop.CoreLib.Models
{
   public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset createdon { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
            createdon = DateTime.Now;


        }
    }
}
