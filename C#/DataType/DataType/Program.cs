using System;

namespace DataType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var number = 10;
            Object str = "NIIT";
            string str2 = str.ToString();
            Console.WriteLine(str2.ToLower());
            Console.WriteLine(str is int);
            disp();
        }

        private static void disp()
        {
            string st = "hitesh";
            Console.WriteLine("HW");
        }
    }
}