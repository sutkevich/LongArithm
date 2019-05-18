using System;

namespace long_ar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = new Number();
            var b = new Number();
            var c = new Number();
            var d = new Number();
            a.Insert("111111111111111111111");
            b.Insert("-2222222222222222222222");
            c.Insert("333333333333333333333333333333333");
            d.Insert("-444444444444444444444444444444444444444444");
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
        }
    }
}