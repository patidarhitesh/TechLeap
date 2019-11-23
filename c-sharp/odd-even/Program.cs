using System.Linq;
using System;

namespace odd_even
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = new int[10];
            int[] even = new int[10];
            int[] odd = new int[10];
            int e = 0, o = 0;
            System.Console.WriteLine("Enter 10 numbers : ");
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }
            foreach (int num in numbers)
            {
               if (num % 2 == 0)
                {
                    even[e] = num;
                    e++;
                }
                else
                {
                    odd[o] = num;
                    o++;
                }
            }
            System.Console.WriteLine($"There are {e} even numbers:");
            for (int i = 0; i < e; i++)
            {
                System.Console.WriteLine(even[i]);
            }
            System.Console.WriteLine($"There are {o} odd numbers:");
            for (int i = 0; i < o; i++)
            {
                System.Console.WriteLine(odd[i]);
            }
        }
    }
}
