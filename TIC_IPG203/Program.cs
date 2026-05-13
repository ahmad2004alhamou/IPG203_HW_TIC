using System;

namespace IPG203_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainRestaurant restaurant = new MainRestaurant();//انشئنا كائن من كلاس MainRestaurant

            while (true)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1. Show All Menus");
                Console.WriteLine("2. Go to Pizza Section");
                Console.WriteLine("3. Go to Burger Section");
                Console.WriteLine("4. Go to Drinks Section");
                Console.WriteLine("5. Exit");

                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        restaurant.ShowAllMenus();//خيار لعرض جيمع مينوهات الاقسام
                        break;
                    // ميثود RunSection تقوم بأخذ البارميتر ونحن هنا وضعنا كائن الخاص بكلاسMainRestaurant و اسم ال list
                    case "2":
                        RunSection(restaurant.Sections[0]);//نقوم بالدخول الى الكائن عن طريق ادخال رقم العنصر الموجود بال list

                        break;

                    case "3":
                        RunSection(restaurant.Sections[1]);//نقوم بالدخول الى الكائن عن طريق ادخال رقم العنصر الموجود بال list
                        break;

                    case "4":
                        RunSection(restaurant.Sections[2]);//نقوم بالدخول الى الكائن عن طريق ادخال رقم العنصر الموجود بال list
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        static void RunSection(RestaurantSection section)//هذه الميثود تقوم باخذ باراميتر من نوع كلاس و اوبجكت
        {
            while (true)
            {
                Console.WriteLine($"\n=== {section.SectionName} ===");
                Console.WriteLine("1. Show Menu");
                Console.WriteLine("2. Take Order");
                Console.WriteLine("3. Show Bill");
                Console.WriteLine("4. Back");

                Console.Write("Choose: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        section.ShowMenu();//لعرض المنيو الخاص بالقسم 
                        break;

                    case "2":
                        section.TakeOrder();//لاخذ الطلب من القسم 
                        break;

                    case "3":
                        section.ShowBill();//لعرض الفاتورة الخاصة بالقسم
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
    public interface IRestaurantSection//هذه الواجهة التي تحتوي على العمليات الاساسية
    {
        string SectionName { get; }//متغير يمكننا فقط القراءة منه , و يفيد في تحديد اسم القسم داخل المطعم

        void ShowMenu();//ميثود تقوم بعرض المينيو
        void TakeOrder();//ميثود تقوم بأخذ الطلب
        void ShowBill();//ميثود تقوم بطباعة الفاتورة
    }

    public abstract class RestaurantSection : IRestaurantSection//انشئنا كلاس مجرد يرث العمليات الاساسية من الواجهة
    {
        public string SectionName { get; private set; }
        protected RestaurantSection(string sectionName)//قمنا بأنشاء كونستراكتر نمرر من خلاله متغير اسم القسم ويجب ان يكون حصرا محمي للابناء 
        {
            SectionName = sectionName;
        }
        public abstract void ShowMenu();//جعلناها مجردة(بدون اقواس متعرجة)تفيد باجبار الابناء على استخدامها ووضع الاوامر بداخلها
        public abstract void TakeOrder();//جعلناها مجردة(بدون اقواس متعرجة)تفيد باجبار الابناء على استخدامها ووضع الاوامر بداخلها
        public abstract void ShowBill();//جعلناها مجردة(بدون اقواس متعرجة)تفيد باجبار الابناء على استخدامها ووضع الاوامر بداخلها
                                        ///////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////
        //شرح التفويض و الاحداث مشروع بدقة في تقرير ال pdf
        /////////////////////////////////////////////////////
        // 1) التفويض
        public delegate void OrderAddedHandler(string sectionName, string itemName);

        // 2) الحدث
        public event OrderAddedHandler OrderAdded;


        // 3) دالة إطلاق الحدث (الأب فقط يطلقه)
        protected void RaiseOrderAdded(string itemName)
        {
            OrderAdded?.Invoke(SectionName, itemName);
        }





    }

}