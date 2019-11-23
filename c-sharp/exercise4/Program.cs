using System;

namespace exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0,i=0,j, sum=0;


            for (count = 0; count < 10; i++)
            {
             
                for (j = 2; j < i; j++)
                {
                    if (i % j == 0)
                        break;
                }

                if (j == i) 
                {
                   sum += i;
                    count++;   
                }

            }
            Console.WriteLine($"{sum}");

          
        }
    }
}
