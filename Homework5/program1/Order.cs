using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Order
    {
        public OrderDetailIs aDetail = new OrderDetailIs();

        public void SetData()
        {
            Console.WriteLine("请输入订单信息：");

            Console.Write("订单号：");
            string anOrderNum = Console.ReadLine();
            if (anOrderNum != "")
            {
                foreach (char num in anOrderNum)
                {
                    if (char.IsDigit(num) == false)
                    {
                        throw new OrderException("你输入的订单号不全为数字。");
                    }
                }
                aDetail.orderNum = anOrderNum;
            }

            Console.Write("客户名：");
            string aCustomerName = Console.ReadLine();
            if (aCustomerName != "")
            {
                aDetail.cutomerName = aCustomerName;
            }

            Console.Write("商品名：");
            string aProductName = Console.ReadLine();
            if (aProductName != "")
            {
                aDetail.productName = aProductName;
            }

            Console.Write("订单金额：");
            string anOrderCost = Console.ReadLine();
            if (anOrderCost != "")
            {
                if (double.TryParse(anOrderCost, out double cost) == false)
                {
                    throw new OrderException("你输入的订单金额有误。");
                }
                aDetail.orderCost = anOrderCost;
            }
        }
    }
}
