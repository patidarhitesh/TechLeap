using System;
using System.Collections.Generic;
using System.Text;

namespace Customer
{
    [Serializable]
    struct Address
    {
        public int buildingNo;
        public string city;
        public string state;
        public string country;
    }
    [Serializable]
    class Customer
    {
        public int CustId;
        public string CustName;
        public Address address;
        int n = 0;
        bool flagID = false;
        bool flagb = false;

        public enum CustType
        {
            Premium, Gold, Exclusive
        }
        public CustType type;

        public virtual void GetDetails()
        {
            Console.WriteLine("Enter Customer ID : ");

            do
            {
                flagID = int.TryParse(Console.ReadLine(), out CustId);

                if (!flagID)
                {

                    Console.WriteLine("Please choose a number as ID.");
                }
            } while (!(flagID));

            Console.WriteLine("Enter Customer Name : ");

            do
            {
                Console.WriteLine("Customer Name should be atleat 3 character long.");
                CustName = Console.ReadLine();

            } while (CustName.Length < 3);
            Console.Write("Building No.: ");
            do
            {
                flagb = int.TryParse(Console.ReadLine(), out address.buildingNo);
                if (!flagb)
                {

                    Console.WriteLine("Please choose a number as  Building Number.");
                }
            } while (!(flagb));
            Console.Write("City: ");
            address.city = Console.ReadLine();
            Console.Write("State: ");
            address.state = Console.ReadLine();
            Console.Write("Country: ");
            address.country = Console.ReadLine();
            Console.Write("Customer Type : ");

            do
            {
                Console.WriteLine(" press 1 for Premium,  press 2 for Gold,  press 3 for Exclusive");
                string num = Console.ReadLine();
                n = Convert.ToInt32(num);
                n = n - 1;
                type = (CustType)(n);


            } while (n > 3 || !(n is int));


        }
        public void dispDetails()
        {

            Console.WriteLine("Details are as follows: ");
            Console.WriteLine($"Id: {this.CustId}, Name:{this.CustName}, Address:  Building No: {this.address.buildingNo},  City: {this.address.city},   State: {this.address.state},  Country: {this.address.country},  Customer Type :{this.type}");
        }
    }
}
