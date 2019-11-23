using System.Text;
using System.Linq;
using System;

namespace rna_dna
{
    class Program
    {
        static void Main(string[] args)
        {
            int flag = 0;
            Console.WriteLine("Enter DNA Strand : ");
            string a = Console.ReadLine();
            StringBuilder str = new StringBuilder();
            foreach (char i in a)
            {
                switch (i)
                {
                    case 'G':
                        str.Append('C');
                        break;
                    case 'C':
                        str.Append('G');
                        break;
                    case 'T':
                        str.Append('A');
                        break;
                    case 'A':
                        str.Append('U');
                        break;
                    default:
                        // System.Console.WriteLine($"{i} is an Invalid Strand.");
                        flag = 1;
                        break;
                }
            }
            if (flag == 0)
            {
                System.Console.WriteLine("Transcribed RNA strand is : ");
              
                System.Console.WriteLine(str);
            } else {
                System.Console.WriteLine("Invalid Strand.");

            }
        }
    }
}
