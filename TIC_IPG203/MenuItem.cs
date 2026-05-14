using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_OOP
{
    public abstract class MenuItem//كلاس اب مجرد لكلاسات ابناء تفيد بتحديد عناصر المينو واسماء الطلبات و السعر
    {
        //الابناء موجوين بكلاس food  وهم : Pizza,Burger,Drink
        public string Name { get; private set; }
        public decimal BasePrice { get; private set; }

        protected MenuItem(string name, decimal basePrice)//كونستراكتر نمرر من خلاله اسم الصنف و سعره
        {
            Name = name;//وهنا نقوم بالاسناد 
            BasePrice = basePrice;//وهنا نقوم بالاسناد 
        }

        public abstract decimal CalculatePrice();//انشئنا ميثود مجردة لاجبار الابناء على استخدامها, تفيد بحساب قيمة الفاتوتورة و طريقة عمل override بشكل محتلف في كل كلاس من كلاسات الابناء

        public virtual string GetInfo()//ميثود لجلب معلومات اسم و سعر الصنف
        {
            return $"{Name} - {CalculatePrice()}";
        }
    }

}
