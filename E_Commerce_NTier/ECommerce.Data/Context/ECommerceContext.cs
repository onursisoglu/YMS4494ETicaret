using ECommerce.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data.Context
{
    // Bu class veri tabanı ile iletişim kuırduğumuz yerdir. Code Firstte hangi class(lar) veritabanında tablo olacağınız belirtiyoruz. Bu iletişimi sağlamak için EntityFramework ile ilgili katmanda C# ' ın sunduğu DbContext class'ın miras almalıyız.
   public class ECommerceContext:DbContext
    {
        public ECommerceContext()
        {
            //Database.Connection.ConnectionString = "Server=.;Database=4494DB;uid=sa;pwd=123";
            Database.Connection.ConnectionString = "Server=.;Database=4494DB;Trusted_Connection=true";
        }

        
        public DbSet<Category> Categories { get; set; }

        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }


    }
}
