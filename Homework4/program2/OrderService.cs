using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class OrderService
    {
        static public List<Order> orderList = new List<Order>();
        static private List<Order> foundOrderList = new List<Order>();

        static public void findOrderByCustomerName()
        {
            foundOrderList.Clear();
            Console.Write("请输入你想寻找的订单的客户名：");
            string customerName = Console.ReadLine();
            foreach (Order anOrder in orderList)
            {
                if (anOrder.aDetail.cutomerName.Equals(customerName))
                {
                    foundOrderList.Add(anOrder);
                }
            }
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("未找到符号搜索条件的订单。\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByProductName()
        {
            foundOrderList.Clear();
            Console.Write("请输入你想寻找的订单的商品名：");
            string productName = Console.ReadLine();
            foreach (Order anOrder in orderList)
            {
                if (anOrder.aDetail.productName.Equals(productName))
                {
                    foundOrderList.Add(anOrder);
                }
            }
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("未找到符号搜索条件的订单。\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static public void findOrderByOrderNum()
        {
            foundOrderList.Clear();
            Console.Write("请输入你想寻找的订单的订单号：");
            string orderNum = Console.ReadLine();
            foreach (Order anOrder in orderList)
            {
                if (anOrder.aDetail.orderNum.Equals(orderNum))
                {
                    foundOrderList.Add(anOrder);
                }
            }
            if (foundOrderList.Count == 0)
            {
                Console.WriteLine("未找到符号搜索条件的订单。\n");
            }
            else
            {
                ShowOrder();
            }
        }

        static private void ShowOrder()
        {
            Console.WriteLine("你所寻找的订单有：");
            foreach (Order anOrder in foundOrderList)
            {
                Console.WriteLine("订单号：" + anOrder.aDetail.orderNum);
                Console.WriteLine("客户名：" + anOrder.aDetail.cutomerName);
                Console.WriteLine("商品名：" + anOrder.aDetail.productName + "\n");
            }
        }

        static public void AddOrder()
        {
            Order anOrder = new Order();
            try
            {
                anOrder.SetData();
                orderList.Add(anOrder);
                Console.WriteLine("添加完成。\n");
            }
            catch (OrderException exception)
            {
                Console.WriteLine("你输入有误，因为" + exception.Message + "\n");
            }
        }

        static public void DeleteOrder()
        {
            try
            {
                if (foundOrderList.Count == 0)
                {
                    throw new OrderException("未找到你想要删除的订单。");
                }
                Console.Write("请选择你要删除找到的第几个订单，如果直接回车删除所有符合条件的订单：");
                string condition = Console.ReadLine();
                if (int.TryParse(condition, out int num) == true)
                {
                    if (num > foundOrderList.Count)
                    {
                        throw new OrderException("你输入的数字超出所找到的订单数。");
                    }
                    orderList.Remove(foundOrderList[num - 1]);
                    Console.WriteLine("删除完成。\n");
                }
                else if (condition == "")
                {
                    foreach (Order anOrder in foundOrderList)
                    {
                        orderList.Remove(anOrder);
                    }
                    Console.WriteLine("删除完成。\n");
                }
                else
                {
                    throw new OrderException("你输入非法字符或者超出找到的订单个数。");
                }
            }
            catch (OrderException exception)
            {
                Console.WriteLine("你输入有误，因为" + exception.Message + "\n");
            }

        }

        static public void ChangeOrder()
        {
            try
            {
                if (foundOrderList.Count == 0)
                {
                    throw new OrderException("未找到你想要修改的订单。");
                }
                Console.Write("请选择你要修改找到的第几个订单，如果直接回车则不修改：");
                string condition = Console.ReadLine();
                if (int.TryParse(condition, out int num) == true)
                {
                    if (num > foundOrderList.Count)
                    {
                        throw new OrderException("你输入的数字超出所找到的订单数。");
                    }
                    Console.WriteLine("请输入修改后的信息，如果直接回车则不修改：");
                    foundOrderList[num - 1].SetData();
                    Console.WriteLine("修改完成。\n");
                }
                else if (condition == "")
                {
                    Console.WriteLine("修改完成。\n");
                }
                else
                {
                    throw new OrderException("你输入非法字符。");
                }
            }
            catch (OrderException exception)
            {
                Console.WriteLine("修改失败，因为" + exception.Message + "\n");
            }
        }
    }
}
