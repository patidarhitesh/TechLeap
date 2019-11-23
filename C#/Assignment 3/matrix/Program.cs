using System;

namespace matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[3, 2];
            System.Console.WriteLine("Enter a 3x2 Matrix: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    matrix[i, j] = Int32.Parse(Console.ReadLine());
                }
            }

            for (int i = 0; i < 3; i++)
            {
                System.Console.WriteLine();
                for (int j = 0; j < 2; j++)
                {
                    Console.Write($"{matrix[i, j]}  ");

                }
            }

        }
    }
}
