using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace program1
{
    public class Order
    {
        [Key,MaxLength(11),MinLength(11)]
        public string num { get; set; }

        public string name { get; set; }

        public string phone { get; set; }

        public List<Product> products { get; set; }

        public Order()
        {
            products = new List<Product>();
        }

        public Order(string num,string name,string phone ,List<Product> products)
        {
            this.num = num;
            this.name = name;
            this.phone = phone;
            this.products = products;
        }
    }
}
