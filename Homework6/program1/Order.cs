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
        public OrderDetailIs aDetail = new OrderDetailIs();

        public Order()
        {

        }

        public Order(string num, string name, string product, string cost)
        {
            foreach (char letter in num)
            {
                if (char.IsDigit(letter) == false && num != "")
                {
                    throw new OrderException("你输入的订单号不全为数字。");
                }
            }
            if (double.TryParse(cost, out double result) == false && cost != "")
            {
                throw new OrderException("你输入的订单金额有误。");
            }
            this.aDetail.orderNum = num;
            this.aDetail.cutomerName = name;
            this.aDetail.productName = product;
            this.aDetail.orderCost = cost;
        }

        public override string ToString()
        {
            return $"订单号：{aDetail.orderNum}\n客户名：{aDetail.cutomerName}\n商品名：{aDetail.productName}\n订单金额：{aDetail.orderCost}元\n";
        }

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
