using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_OOP
{
    public static class DataValidator
    {
        public static bool IsValidIndex(int index, int length)// للتحقق من ان هل الرقم اللي أدخله المستخدم يقع ضمن حدود المصفوفة 
        {
            return index >= 0 && index < length;
        }

       

        public static bool IsPositive(decimal value)//للتحقق ما اذا كان الرقم موجب ام لا
        {
            return value > 0;
        }
    }

}
