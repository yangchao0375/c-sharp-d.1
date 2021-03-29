using OrderManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_d._1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("p01", "香蕉", 2);
            Product p2 = new Product("p02", "橙子", 2);
            Product p3 = new Product("p03", "梨", 2);

            //生成客户
            Client c1 = new Client("c01");

            //生成订单项
            OrderItem odi1 = new OrderItem("Item1", p1, 1);
            OrderItem odi2 = new OrderItem("Item2", p2, 2);
            OrderItem odi3 = new OrderItem("Item3", p3, 3);
            OrderItem odi4 = new OrderItem("Item4", p2, 4);


            //生成订单项列表
            List<OrderItem> l1 = new List<OrderItem>();
            List<OrderItem> l2 = new List<OrderItem>();
            List<OrderItem> l3 = new List<OrderItem>();


            l1.Add(odi1);
            l1.Add(odi2);
            l2.Add(odi4);
            l2.Add(odi3);
            l3.Add(odi1);

            //生成订单
            Order od1 = new Order("o01", c1, "address1", l1);
            Order od2 = new Order("o02", c1, "address2", l2);
            Order od3 = new Order("o03", c1, "address3", l3);

            List<Order> orders = new List<Order>();

            //生成订单服务对象
            OrderService ods = new OrderService(orders);


            //添加订单测试
            Console.WriteLine("添加订单测试");
            try
            {
                ods.AddOrder(od1);
                //ods.AddOrder(od1);
                ods.AddOrder(od2);
                ods.AddOrder(od3);
                Console.WriteLine("添加订单成功");
            }
            catch (Exception e)
            {
                Console.WriteLine("添加订单失败！原因：" + e.Message);
            }
            //查询订单测试
            Console.WriteLine("查询订单测试");

            IEnumerable<Order> q1 = ods.SearchOrder(1, "o02");
            foreach (Order od in q1) Console.WriteLine(od);

            IEnumerable<Order> q2 = ods.SearchOrder(2, "橙子");
            foreach (Order od in q2) Console.WriteLine(od);

            //删除订单测试
            Console.WriteLine("删除订单2测试");
            try
            {
                ods.DeleteOrder(od2);
                //ods.DeleteOrder(od3);
                Console.WriteLine("删除订单成功");
            }
            catch (Exception e)
            {
                Console.WriteLine("删除订单失败！原因：" + e.Message);
            }

            


            //排序测试
            Console.WriteLine("排序测试");
            ods.SortOrder();
            foreach (Order od in ods.orders) Console.WriteLine(od);
            ods.SortOrder((a1, a2) => Convert.ToInt32(a1.TotalPrice - a2.TotalPrice));
            foreach (Order od in ods.orders) Console.WriteLine(od);

        } 
     }
    }





