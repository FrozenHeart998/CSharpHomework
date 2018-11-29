using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace program1
{
    public class OrdersDB:DbContext
    {
        public DbSet<Order> orders { get; set; }
        public DbSet<Product> products { get; set; }

        public OrdersDB():base("OrderDataBase")
        {

        }
    }
}
