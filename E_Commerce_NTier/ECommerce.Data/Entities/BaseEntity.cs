using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
   public class BaseEntity
    {
        // Guid => 32 karakterli aralarında - bulunan harf ve sayı karışımı bir unique key oluşturur.
        public Guid ID { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
