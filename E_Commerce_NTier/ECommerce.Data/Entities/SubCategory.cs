using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
   public class SubCategory:BaseEntity
    {

        public string Name { get; set; }
        public string Description { get; set; }

        public Guid MainCategoryID { get; set; }

        public virtual Category _MainCategory{ get; set; }

        public virtual List<Product> _Products { get; set; }

    }
}
