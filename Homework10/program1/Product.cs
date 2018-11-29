using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace program1
{
    public class Product
    {
        [Key]
        public string productID { get; set; }

        [Required]
        public double cost { get; set; }

        [Required]
        public string productName { get; set; }

        public Product()
        {
            productID= Guid.NewGuid().ToString();
        }

        public Product(string productID,double cost)
        {
            this.productID = productID;
            this.cost = cost;
        }
    }
}
