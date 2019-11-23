using System;

namespace exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1, num2, num3, counter1 = 0, counter2 = 0, counter3 = 0, i;
            Console.WriteLine("Enter Number1 : ");
            bool status1 = int.TryParse(Console.ReadLine(), out num1);
            if (!status1)
            {
                do
                {
                    Console.WriteLine("Enter Number1 again: ");
                    status1 = int.TryParse(Console.ReadLine(), out num1);
                    counter1++;

                } while (!status1 || counter1 == 3);


            }
            Console.WriteLine("Enter Number2 : ");
            bool status2 = int.TryParse(Console.ReadLine(), out num2);
            if (!status2)
            {
                do
                {

                    Console.WriteLine("Enter Number2 again: ");
                    status2 = int.TryParse(Console.ReadLine(), out num2);
                    counter2++;

                } while (!status2 || counter2 == 3);

            }
            Console.WriteLine("Enter Number3 : ");
            bool status3 = int.TryParse(Console.ReadLine(), out num3);
            if (!status3)
            {
                do
                {
                    Console.WriteLine("Enter Number3 again: ");
                    status3 = int.TryParse(Console.ReadLine(), out num3);
                    counter3++;

                } while (!status3 || counter3 == 3);

            }

            if (num1 >= num2 && num1 >= num3)
                 Console.WriteLine($"{num1} is the largest number.");
            if (num2 >= num1 && num2 >= num3)
                 Console.WriteLine($"{num2} is the largest number.");
            if (num3 >= num1 && num3 >= num2)
                 Console.WriteLine($"{num3} is the largest number.");


        }
    }
}
