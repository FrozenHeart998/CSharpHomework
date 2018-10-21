using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = @"E:\C#\CSharpHomework\Homework6\program1\order.xml";

            OrderService.Import(xmlSerializer, xmlFileName, OrderService.orderList);

            //Console.WriteLine("请开始创建你的订单表：");
            //while (OrderService.orderList.Count <= OrderService.orderList.Capacity)
            //{
            //    OrderService.AddOrder();
            //    Console.WriteLine("按任意键继续，按esc键停止添加。\n");
            //    if (Console.ReadKey().Key == ConsoleKey.Escape)
            //    {
            //        break;
            //    }
            //}

            //OrderService.findOrderByCustomerName();
            //OrderService.DeleteOrder();
            //OrderService.findOrderByOrderNum();
            //OrderService.ChangeOrder();
            //OrderService.AddOrder();
            //OrderService.findOrderByProductName();
            //OrderService.DeleteOrder();
            //OrderService.findOrderByOrderCost();



            foreach(Order anOrder in OrderService.orderList)
            {
                Console.WriteLine(anOrder);
            }
            OrderService.Export(xmlSerializer, xmlFileName, OrderService.orderList);

            Console.WriteLine(File.ReadAllText(xmlFileName));

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
