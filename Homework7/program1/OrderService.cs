using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace program1
{
    public class OrderService
    {
        static public List<Order> orders = new List<Order>();

        static public IEnumerable<Order> FindByNum(string condition)
        {
            return orders.Where(order => order.num.Equals(condition));
        }

        static public IEnumerable<Order> FindByName(string condition)
        {
            return orders.Where(order => order.name.Equals(condition));
        }

        static public IEnumerable<Order> FindByProduct(string condition)
        {
            return orders.Where(order => order.product.Equals(condition));
        }

        static public IEnumerable<Order> FindByCost(string condition)
        {
            return orders.Where(order => order.cost.Equals(condition));
        }

        static public void DelOrder(Order obj)
        {
            orders.Remove(obj);
        }

        static private void IsRight(string num, string name, string product, string cost)
        {
            if (!uint.TryParse(num, out uint uintNum) || !double.TryParse(cost, out double doubleNum) || name == "" || product == "")
            {
                throw new Exception("你输入的订单信息有误");
            }
            else
            {
                foreach (Order obj in orders)
                {
                    if (obj.num.Equals(num))
                    {
                        throw new Exception("你添加的订单的订单号已经存在");
                    }
                }
            }
        }

        static public void AddOrder(string num, string name, string product, string cost)
        {
            IsRight(num, name, product, cost);
            orders.Add(new Order(num, name, product, cost));
        }

        static public void ChangeOrder(string num, string name, string product, string cost,Order obj)
        {
            IsRight(num, name, product, cost);
            obj.num = num;
            obj.name = name;
            obj.product = product;
            obj.cost = cost;
        }

        static public void Import(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Read);
            orders = xmlSerializer.Deserialize(fileStream) as List<Order>;
            fileStream.Close();
        }

        static public void Export(XmlSerializer xmlSerializer, string fileName, object obj)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, obj);
            fileStream.Close();
        }
    }
}
