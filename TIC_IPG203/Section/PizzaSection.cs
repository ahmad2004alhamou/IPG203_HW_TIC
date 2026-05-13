using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_OOP
{
    public class PizzaSection : RestaurantSection//انشئنا كلاس يرث من كلاس الاب المجرد (الابن الاول) ويقوم باستخدام الميثودات المجردة
    {
        //قمنا باستخدام مصفوفة من نوع MenuItem حصرا لنستطيع الوصول الى الكيانات الخاصة بها و نقوم بتمرير المتغيرات المطلوبة
        private MenuItem[] _menu;      //  مصفوفة من كلاس MenuItem لعرض مينيو القسم و عناصرها كائنات لكلاس آخر
        private MenuItem[] _order;     // مصفوفة من كلاس MenuItem لتخزين الطلبات بداخلها و عناصرها كائنات لكلاس آخر
        private int orderIndex = 0;


        public PizzaSection() : base("Pizza Section")//انشئنا كونستراكتر و يقوم بتمرير اسم القسم الى كلاس الاب ("Pizza Section")
        {
            _menu = new MenuItem[]
            {
            new Pizza("Margherita", 10, "Medium"),//نقوم بكلا العناصر بارسال اسم البيتزا مع السعر و الحجم الى كوانستراكتر من كلاس pizza
            new Pizza("Pepperoni", 12, "Large")
            };
            _order = new MenuItem[10];   
        }

        public override void ShowMenu()//قمنا باستخدام ال override للوصول الى الميثود و استخدامها
        {
            Console.WriteLine($"--- {SectionName} ---");
            for (int i = 0; i < _menu.Length; i++)
                Console.WriteLine($"{i + 1}. {_menu[i].GetInfo()}");
        }

        public override void TakeOrder()//قمنا باستخدام ال override للوصول الى الميثود و استخدامها
        {
            Console.Write("Enter item number: ");
            int choice = int.Parse(Console.ReadLine()) - 1;

            if (!DataValidator.IsValidIndex(choice, _menu.Length))
            {
                Console.WriteLine("Invalid choice!");
                return;
            }

            var item = _menu[choice];      // تعريف item
            _order[orderIndex++] = item;


            OrderTracker.AddOrder();
            RaiseOrderAdded(item.Name);

        }

        public override void ShowBill()//قمنا باستخدام ال override للوصول الى الميثود و استخدامها
        {
            if (orderIndex == 0)
            {
                Console.WriteLine("No items ordered yet.");
                return;
            }

            Console.WriteLine($"\n--- Bill for {SectionName} ---");

            decimal total = 0;

            for (int i = 0; i < orderIndex; i++)
            {
                var item = _order[i];
                Console.WriteLine(item.GetInfo());
                total += item.CalculatePrice();
            }

            Console.WriteLine($"Total: {total}");
        }

    }

}
