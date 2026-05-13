using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_OOP
{
    public class MainRestaurant//كلاس خاص ب list 
    {
        public List<RestaurantSection> Sections { get; private set; }//انشئنا list من نوع كلاس RestaurantSection وعناصرها كائنات مشتقة

        public MainRestaurant()
        {
            Sections = new List<RestaurantSection>//العناصر هي كائنات مشتقة من كلاسات الابناء الخاصين بكلاسRestaurantSection
        {
            new PizzaSection(),
            new BurgerSection(),
            new DrinksSection()
        };
            // 5) الاشتراك بالحدث
            foreach (var section in Sections)
            {
                section.OrderAdded += OnOrderAdded;
            }
        }

        public void ShowAllMenus()//ميثود تقوم باظهار مينو جمبع الاقسام و تظهر فكرةPolymorphism
        {
            foreach (var section in Sections)//section يقوم بمكان احد الكيانات مثل PizzaSection وهنا يظهر تعدد الاشكال
            {
                section.ShowMenu();//سيقوم بجعل كل قسم يعرض المينيو الخاص به, لانه سيوضع (اسم القسم.عرض الميثود) 
                Console.WriteLine();
            }
        }
        private void OnOrderAdded(string sectionName, string itemName)
        {
            Console.WriteLine($"[EVENT] New order added in {sectionName}: {itemName}");
        }

    }


}
