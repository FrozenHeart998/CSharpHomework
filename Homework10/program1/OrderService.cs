using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace program1
{
    public class OrderService
    {
        static public void AddOrder(Order order)
        {
            using (var dataBase = new OrdersDB())
            {
                dataBase.orders.Add(order);
                dataBase.SaveChanges();
            }
        }

        static public void DeletOrder(Order order)
        {
            using (var dataBase = new OrdersDB())
            {
                var tempOrder = dataBase.orders.Include("products").SingleOrDefault(temp => temp.num.Equals(order.num));
                dataBase.products.RemoveRange(tempOrder.products);
                dataBase.orders.Remove(tempOrder);
                dataBase.SaveChanges();
            }
        }

        static public void ChangeOrder(Order order)
        {
            using (var dataBase = new OrdersDB())
            {
                dataBase.orders.Attach(order);
                dataBase.Entry(order).State = EntityState.Modified;
                order.products.ForEach
                    (product => dataBase.Entry(product).State = EntityState.Modified); 
                dataBase.SaveChanges();
            }
        }

        static public List<Order> GetAllOrders()
        {
            using (var dataBase = new OrdersDB())
            {
                return dataBase.orders.Include("products").ToList<Order>();
            }
        }

        static public List<Order> FindByNum(string condition)
        {
            using (var dataBase = new OrdersDB())
            {
                var found = dataBase.orders.Include("products")
                    .Where(order => order.num == condition);
                return found.ToList<Order>();
            }
        }

        static public List<Order> FindByName(string condition)
        {
            using (var dataBase = new OrdersDB())
            {
                var found = dataBase.orders.Include("products")
                    .Where(order => order.name == condition);
                return found.ToList<Order>();
            }
        }

        static public List<Order> FindByPhone(string condition)
        {
            using (var dataBase = new OrdersDB())
            {
                var found = dataBase.orders.Include("products")
                    .Where(order => order.num == condition);
                return found.ToList<Order>();
            }
        }

        static public List<Order> FindByProduct(string condition)
        {
            using (var dataBase = new OrdersDB())
            {
                var found = dataBase.orders.Include("products")
                    .Where(order => order.num == condition);
                return found.ToList<Order>();
            }
        }

        static public List<Order> FindByCost(string condition)
        {
            if (double.TryParse(condition, out double cost))
            {
                using (var dataBase = new OrdersDB())
                {
                    var found = dataBase.orders.Include("products")
                        .Where(order => order.products
                        .Where(product => product.cost.Equals(cost)).Count() > 0);
                    return found.ToList<Order>();
                }
            }
            else
            {
                return new List<Order>();
            }
        }

        static public List<Order> FindByProductName(string condition)
        {
            using (var dataBase = new OrdersDB())
            {
                var found = dataBase.orders.Include("products")
                    .Where(order => order.products
                    .Where(product => product.productName.Equals(condition)).Count() > 0);
                return found.ToList<Order>();
            }
        }
    }
}
