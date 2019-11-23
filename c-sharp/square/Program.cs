using System;

namespace square
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, square;

            for (; ; )
            {
                ConsoleKeyInfo input = Console.ReadKey();
                if (string.Equals(input.Key.ToString(), "RightArrow") && string.Equals(input.Modifiers.ToString(), "Control"))
                {
                    break;
                }
                num = int.Parse(input.KeyChar.ToString());
                Console.WriteLine();
                Console.WriteLine($"square:{num * num}");
            }


        }
    }
}
