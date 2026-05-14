using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_OOP
{
    public class Pizza : MenuItem//الابن الاول 
    {
        public string Size { get; private set; }//متغير خاص لتحديد حجم البيتزا

        public Pizza(string name, decimal basePrice, string size)//كوانستراكتر نقوم بتمرير من خلاله اسم و سعر و حجم الصنف
            : base(name, basePrice)//نقوم بارسال الاسم و السعر لكلاس الاب ليقوم تخزينها في متغير
        {
            Size = size;
        }
        
        public override decimal CalculatePrice()//قمنا بعمل override للوصول الى هذه الميثود ونرى ان هنا كل فئة تعيد ال override بطريقتها
        {
            return BasePrice + (Size == "Large" ? 3 : 0);//نقوم بارجعا السعر + اذا كانت حجم كبير ام لا 
        }

        public override string GetInfo()//قمنا بعمل override للوصل الى ميثود virtual وقمنا باستخدام مفهوم Polymorphism
        {
            return $"{Name} ({Size}) - {CalculatePrice()}";
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class Burger : MenuItem// الابن الثاني
    {
        public bool ExtraCheese { get; private set; }//متغير لتحديد اذا كان يوجد جبنة ام لا

        public Burger(string name, decimal basePrice, bool extraCheese)//كوانستراكتر نقوم بتمرير من خلاله اسم و سعر و هل يوجد جبنة ام لا للصنف
            : base(name, basePrice)//نقوم بارسال الاسم و السعر لكلاس الاب ليقوم تخزينها في متغير
        {
            ExtraCheese = extraCheese;
        }

        public override decimal CalculatePrice()//طريقة حساب مختلفة و نفس الشرح التي في الاعلى
        {
            return BasePrice + (ExtraCheese ? 2 : 0);
        }
    }
    ///////////////////////////////////////////////////////////////////
    public class Drink : MenuItem//الابن الثالث
    {
        public bool IsCold { get; private set; }//متغير لتحديد اذا كان المشروب من النوع الساخن ام البارد

        public Drink(string name, decimal basePrice, bool isCold)//كوانستراكتر نقوم بتمرير من خلاله اسم و سعر و تحديد اذا بارد ام ساخن 
            : base(name, basePrice)//نقوم بارسال الاسم و السعر لكلاس الاب ليقوم تخزينها في متغير
        {
            IsCold = isCold;
        }

        public override decimal CalculatePrice()
        {
            return BasePrice;
        }
    }

}
