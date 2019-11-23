using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Customer
{

    class CustomerRepository
    {
         public void AddCust(Customer customer)
        {
            string path = "./customer.txt";
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            try
                            {
                       
                                IFormatter bf = new BinaryFormatter();
                                bf.Serialize(fs, customer);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            finally
                            {
                                sw.Close();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RetrieveCust()
        {
            string path = "./customer.txt";
            int id;

            Console.WriteLine("Enter ID of customer to retrieve: ");
            id = Convert.ToInt32(Console.ReadLine());
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            try
                            {
                                IFormatter f = new BinaryFormatter();
                                bool flag = false;

                                while (fs.Position != fs.Length)
                                {
                                    Customer customer = (Customer)f.Deserialize(fs);

                                    if (customer.CustId == id)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("CustId: {0}", customer.CustId);
                                        Console.WriteLine("CustName: {0}", customer.CustName);
                                        Console.WriteLine("Address: {0}, {1}, {2}, {3}", customer.address.buildingNo, customer.address.city, customer.address.state, customer.address.country);
                                        Console.WriteLine("CustType: {0}", customer.type);
                                        flag = true;
                                        break;
                                    }
                                }
                                if (!flag)
                                {
                                    Console.WriteLine("Customer not found.");
                                }
                            }

                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            finally
                            {
                                sr.Close();
                                sr.Dispose();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        fs.Close();

                        fs.Dispose();
                    }
                }

            }
            catch (FileNotFoundException fx)
            {
                Console.WriteLine("File does not exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured.");
                Console.WriteLine("Error:", ex.Message);
            }
            finally
            {


            }
        }

        public void RetrieveAll()
        {
            string path = "./customer.txt";

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            try
                            {
                                IFormatter bf = new BinaryFormatter();
                                while (fs.Position != fs.Length)
                                {
                                    Console.WriteLine();
                                    Customer customer = (Customer)bf.Deserialize(fs);
                                    Console.WriteLine("CustId: {0}", customer.CustId);
                                    Console.WriteLine("CustName: {0}", customer.CustName);
                                    Console.WriteLine("Address: {0}, {1}, {2}, {3}", customer.address.buildingNo, customer.address.city, customer.address.state, customer.address.country);
                                    Console.WriteLine("CustType: {0}", customer.type);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            finally
                            {
                                sr.Close();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

    
