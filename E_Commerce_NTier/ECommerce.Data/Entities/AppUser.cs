using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Entities
{
   public class AppUser:BaseEntity
    {
        
        public string Name { get; set; }
        public string SurName { get; set; }
        public string ProfilePicturePath { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime BirthDate { get; set; }

        public char Gender { get; set; }

        public string Address { get; set; }

        public string Role { get; set; }

        public virtual List<Order> _Orders { get; set; }
    }
}
