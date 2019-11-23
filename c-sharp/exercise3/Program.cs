
using System;

namespace exercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
           
            
            Console.WriteLine("Enter full name : ");
            string a = Console.ReadLine().ToString();
            int b = a.Length;
            for (i = 0; i < b; i++)
            {
               if(a[i] != ' '){
                   Console.Write(a[i]);
               } else {
                   Environment.Exit(b);
               }
            }

        }
    }
}
