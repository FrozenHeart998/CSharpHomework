using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    [Serializable]
    public class Order
    {
        public string num { get; set; }
        public string name { get; set; }
        public string product { get; set; }
        public string cost { get; set; }
        public string phone { get; set; }

        public Order()
        {

        }

        public Order(string num, string name, string product, string cost,string phone)
        {
            this.num = num;
            this.name = name;
            this.product = product;
            this.cost = cost;
            this.phone = phone;
        }
    }
}
