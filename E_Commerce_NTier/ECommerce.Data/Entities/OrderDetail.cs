using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
   public class OrderDetail:BaseEntity
    {
        public Guid ProductID { get; set; }

        public Guid OrderID { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }


        // İlişkili Tablolar .
        public virtual Product _Product { get; set; }

        public virtual Order _Order { get; set; }
    }
}
