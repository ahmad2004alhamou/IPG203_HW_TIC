using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_OOP
{
    public class DrinksSection : RestaurantSection//انشئنا كلاس يرث من كلاس الاب المجرد (الابن الثالث) ويقوم باستخدام الميثودات المجردة
    {
        //قمنا باستخدام مصفوفة من نوع MenuItem حصرا لنستطيع الوصول الى الكيانات الخاصة بها و نقوم بتمرير المتغيرات المطلوبة
        private MenuItem[] _menu;      //  مصفوفة من كلاس MenuItem لعرض مينيو القسم و عناصرها كائنات لكلاس آخر
        private MenuItem[] _order;     // مصفوفة من كلاس MenuItem لتخزين الطلبات بداخلها و عناصرها كائنات لكلاس آخر
        private int orderIndex = 0;


        public DrinksSection() : base("Drinks Section")//انشئنا كونستراكتر و يقوم بتمرير اسم القسم الى كلاس الاب ("Drink Section")
        {
            _menu = new MenuItem[]
            {
            new Drink("Cola", 3, true),//نقوم بارسال اسم و سعر المشروب واذا كان مشروب بارد او لا
            new Drink("Tea", 2, false)
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
            RaiseOrderAdded(item.Name);//لاعلان عن الاشعار بأنه

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
