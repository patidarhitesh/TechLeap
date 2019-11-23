using System;

namespace Array
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //int[] rollnumbers = new int[5];
            //rollnumbers[0] = 121;
            //for (int i = 1; i < rollnumbers.Length; i++)
            //{
            //    rollnumbers[i] = 121 + i;
            //}
            //Console.WriteLine($"Value at index at 1 is {rollnumbers[0]}");
            //foreach (int roll in rollnumbers)
            //{
            //    Console.WriteLine($"Value is {roll}");
            //}
            //string[,] names = new string[5, 2];
            //names[0, 0] = "Shreya";
            //names[0, 1] = "Bajpai";
            //names[1, 0] = "Hitesh";
            //names[1, 1] = "Patidar";
            //names[2, 0] = "Kamles";
            //names[2, 1] = "Bhopal";
            //foreach (string item in names)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(names[0, 1]);
            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 2; j++)
            //    {
            //        Console.WriteLine(names[i, j]);
            //    }
            //}

            // JAGGED ARRAY
            //string[][] names = new string[3][];

            //names[0] = new string[] { "Shreya", "Hitesh", "Kamles" };
            //names[1] = new string[] { "Maliha", "Palash" };
            //names[2] = new string[] { "Hriday" };
            //for (int i = 0; i < names.Length; i++)
            //{
            //    foreach (string name in names[i])
            //    {
            //        Console.Write($"{name}");
            //    }
            //    Console.WriteLine();
            //}

            //int[] numbers = new int[] { 10, 20, 30 };
            //int[] numbers2 = new int[numbers.Length];
            //numbers.CopyTo(numbers, 0);//0 is starting index number from where we start pasting
            //numbers2[2] = 40;
            //Console.WriteLine(numbers2[2]);
            //Console.WriteLine(Addition(12, 10));
            //Console.WriteLine(Addition(12, 10, 14));
            //Console.WriteLine(Addition(12.5f, 10.4f));
            //Console.WriteLine(Sum(12, 10, 17, 14, 12));

            Welcome("Shreya");
            Welcome("Sandhya", "Hi");
            Welcome("Sandhya", tech: "JAVA");
            int sum, multi;
            Calculate(12, 5, out sum, out multi);
            Console.WriteLine($"Total : {sum}, product {multi}");
        }

        private static int Addition(int num1, int num2)
        {
            return num1 + num2;
        }

        private static int Addition(int num1, int num2, int num3)
        {
            return num1 + num2 + num3;
        }

        private static float Addition(float num1, float num2)
        {
            return num1 + num2;
        }

        private static int Sum(params int[] numbers)
        {
            int result = 0;
            foreach (int number in numbers)
            {
                result += number;
            }
            return result;
        }

        private static void Welcome(string name, string title = "Hello", string tech = ".NET")//optional parameters must be last
        {
            Console.WriteLine($"{title} {name} working in {tech}");
        }

        private static void Calculate(int num1, int num2, out int total, out int product)
        {
            total = num1 + num2;
            product = num1 * num2;
        }
    }
}