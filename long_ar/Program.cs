using System;

namespace long_ar
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Number a = "10000";
            Number b = "-4455";
            Number c = "999";
            Number d = "-1000";
            Console.WriteLine($"a = {a}");
            Console.WriteLine("b = {0}",b);
            Console.WriteLine("c = {0}",c);
            Console.WriteLine("d = {0}",d);
            Console.WriteLine("a+c = {0}",a+c);
            Console.WriteLine("b+d = {0}",b+d);
            Console.WriteLine("a+b = {0}",a+b);
            Console.WriteLine("c+d = {0}",c+d);
        }
    }
}