using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请开始创建你的订单表：");
            while (OrderService.orderList.Count <= OrderService.orderList.Capacity)
            {
                OrderService.AddOrder();
                Console.WriteLine("按任意键继续，按esc键停止添加。\n");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            OrderService.findOrderByCustomerName();
            OrderService.DeleteOrder();
            OrderService.findOrderByOrderNum();
            OrderService.ChangeOrder();
            OrderService.AddOrder();
            OrderService.findOrderByProductName();
            OrderService.DeleteOrder();
            OrderService.findOrderByOrderCost();

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
