using System;

namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            int c;
            bool flag = false;
            Customer cust = new Customer();

            CustomerRepository repo = new CustomerRepository();

            Console.WriteLine("Press 1 to add a customer, Press 2 to retrieve a customer, Press 3 to retrieve all customers");
            do
            {

                //int.TryParse(Console.ReadLine(), out CustId);
                flag = int.TryParse(Console.ReadLine(), out c);

                if (!flag || c > 3)
                {

                    Console.WriteLine("Incorrect Choice. Press 1 to add a customer, Press 2 to retrieve a customer, Press 3 to retrieve all customers");
                }



            } while (!(flag) || c > 3);

            switch (c)
            {
                case 1:
                    cust.GetDetails();
                    cust.dispDetails();
                    repo.AddCust(cust); break;
                case 2: repo.RetrieveCust(); break;
                case 3: repo.RetrieveAll(); break;
                default: break;
            }

        }
    }
}
