using System.Text;
using System;

namespace square
{
    class Program
    {
        static void Main(string[] args)
        {
            // int num, square;

            // for (; ; )
            // {
            //     ConsoleKeyInfo input = Console.ReadKey();
            //     if (string.Equals(input.Key.ToString(), "RightArrow") && string.Equals(input.Modifiers.ToString(), "Control"))
            //     {
            //         break;
            //     }
            //     num = int.Parse(input.KeyChar.ToString());
            //     Console.WriteLine();
            //     Console.WriteLine($"square:{num * num}");
            // }
   
           
//   string queryString = "select city,winner,player_match from ipl.csv where season > 2014 and city ='Bangalore'";
       string queryString = "select city,winner,player_match from ipl.csv where season > 2014 and city ='Bangalore'";
           queryString = queryString.ToLower();
            StringBuilder str = new StringBuilder();
            if (queryString.Contains(" and "))
            {
                str.Append("and");
            }
            if (queryString.Contains(" or "))
            {
                str.Append(" or");
            }
            if (queryString.Contains(" not "))
            {
                str.Append(" not");
            }
            string[] basequery = str.ToString().Split(" ");
           
          foreach (string item in basequery)
          {
              System.Console.WriteLine(item);
          }
          
        }
    }
}
