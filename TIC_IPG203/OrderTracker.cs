using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_OOP
{
    public class OrderTracker
    {
        public static int TotalOrders { get; private set; }

        public static void AddOrder()//مثود لحساب عدد الطلبات الاجمالي في كل الاقسام
        {
            TotalOrders++;
        }
    }

}
