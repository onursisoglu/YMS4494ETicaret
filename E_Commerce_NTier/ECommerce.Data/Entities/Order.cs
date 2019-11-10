using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
   public class Order:BaseEntity
    {

        public Guid AppUserID { get; set; }

        public string ShippingAddress { get; set; }


        // İlişkili tablolar.

        public virtual List<OrderDetail> _OrderDetails { get; set; }
        public virtual AppUser _AppUser { get; set; }


    }
}
