using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests//只测试了能够测试的public方法
    {
        List<Order> list = new List<Order>
            (new Order[]
            {
                new Order("1","吴笛","羽毛球","10"),
                new Order("2","吴笛","羽毛球拍","100"),
                new Order("3","余念麟","笔记本电脑","10000"),
                new Order("4","杨忠森","手办","200"),
                new Order("5","孟昊","羽毛球拍","200"),
                new Order("","","","")
            });


        [TestMethod()]
        public void findOrderByCustomerNameTest()
        {
            OrderService.orderList = list;
            OrderService.findOrderByCustomerName("");
            foreach (var obj in OrderService.foundOrderList)
            {
                Assert.AreEqual("", obj.aDetail.cutomerName);
                Assert.AreEqual(1, OrderService.foundOrderList.Count);
            }
            OrderService.findOrderByCustomerName("错误测试");
            Assert.AreEqual(0, OrderService.foundOrderList.Count);
        }

        [TestMethod()]
        public void findOrderByProductNameTest()
        {
            OrderService.orderList = list;
            OrderService.findOrderByProductName("羽毛球拍");
            foreach (var obj in OrderService.foundOrderList)
            {
                Assert.AreEqual("羽毛球拍", obj.aDetail.productName);
                Assert.AreEqual(2, OrderService.foundOrderList.Count);
            }
            OrderService.findOrderByCustomerName("错误测试");
            Assert.AreEqual(0, OrderService.foundOrderList.Count);
        }

        [TestMethod()]
        public void findOrderByOrderNumTest()
        {
            OrderService.orderList = list;
            OrderService.findOrderByOrderNum("1");
            foreach (var obj in OrderService.foundOrderList)
            {
                Assert.AreEqual("1", obj.aDetail.orderNum);
                Assert.AreEqual(1, OrderService.foundOrderList.Count);
            }
            OrderService.findOrderByCustomerName("错误测试");
            Assert.AreEqual(0, OrderService.foundOrderList.Count);
        }

        [TestMethod()]
        public void findOrderByOrderCostTest()
        {
            OrderService.orderList = list;
            OrderService.findOrderByOrderCost("200");
            foreach (var obj in OrderService.foundOrderList)
            {
                Assert.AreEqual("200", obj.aDetail.orderCost);
                Assert.AreEqual(2, OrderService.foundOrderList.Count);
            }
            OrderService.findOrderByCustomerName("错误测试");
            Assert.AreEqual(0, OrderService.foundOrderList.Count);
        }

        [TestMethod()]
        public void AddOrderTest()
        {
            Assert.IsTrue(OrderService.AddOrder("10", "用户", "商品", "10"));
            Assert.IsFalse(OrderService.AddOrder("错误订单号", "用户", "商品", "10"));
            Assert.IsFalse(OrderService.AddOrder("10", "用户", "商品", "错误金额"));
            Assert.AreEqual(1, OrderService.orderList.Count);
        }
    }
}