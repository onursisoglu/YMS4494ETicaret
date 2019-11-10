using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
   public class Product:BaseEntity
    {

        public string Name { get; set; }

        public decimal Price { get; set; }
        public short UnitsInStock { get; set; }

        public string PicturePath { get; set; }

        public Guid  SubCategoryID { get; set; }

        public virtual SubCategory _SubCategory { get; set; }

        public virtual List<OrderDetail> _OrderDetails { get; set; }


    }
}
