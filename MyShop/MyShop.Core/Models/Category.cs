using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
   public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
