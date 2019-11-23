using System;
using System.IO;

using DbEngine.query;

namespace DbEngine.reader
{
    public class CsvQueryProcessor : QueryProcessingEngine
    {
        private readonly string _fileName;
        private StreamReader _reader;

        // Parameterized constructor to initialize filename
        public CsvQueryProcessor(string fileName)
        {

            this._fileName = fileName;

        }

        /*
	    Implementation of getHeader() method. We will have to extract the headers
	    from the first line of the file.
	    Note: Return type of the method will be Header
	    */
        public override Header GetHeader()
        {
            // read the first line
            // populate the header object with the String array containing the header names
            //            return null;


            Header h;
            try
            {
                using (FileStream fs = new FileStream(this._fileName, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            try
                            {
                                while (!sr.EndOfStream)
                                {
                                    h = new Header(sr.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries));
                                    return h;
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("some eror occured.");
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File does not exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured.");
                Console.WriteLine("Error:", ex.Message);
            }
            finally
            {


            }
            return null;

        }

        /*
	    Implementation of getColumnType() method. To find out the data types, we will
	    read the first line from the file and extract the field values from it. If a
	    specific field value can be converted to Integer, the data type of that field
	    will contain "System.Int32", otherwise if it can be converted to Double,
	    then the data type of that field will contain "System.Double", otherwise,
	    the field is to be treated as String. 
	     Note: Return Type of the method will be DataTypeDefinitions
	 */
        public override DataTypeDefinitions GetColumnType()
        {
            int num;
            double d;
            string[] arr;

            DataTypeDefinitions h;
            try
            {
                using (FileStream fs = new FileStream(this._fileName, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            try
                            {
                                while (!sr.EndOfStream)
                                {
                                     string a = sr.ReadLine();
                                    arr = sr.ReadLine().Split(",");

                                    // h = new DataTypeDefinitions(sr.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries));

                                    string[] res = new string[arr.Length];
                                    for (int i = 0; i < arr.Length; i++)
                                    {
                                        try
                                        {
                                            if (int.TryParse(arr[i], out num))
                                            {
                                                res[i] = "System.Int32";
                                            }
                                         
                                        
                                            else
                                            {
                                                res[i] = "System.String";
                                            }

                                        }
                                        catch (Exception) { }



                                    }
                                    h = new DataTypeDefinitions(res);
                                    return h;

                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception("some eror occured.");
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
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("File does not exist");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured.");
                Console.WriteLine("Error:", ex.Message);
            }
            finally
            {


            }
            return null;
        }

        //getDataRow() method will be used in the upcoming assignments
        public override void GetDataRow()
        {

        }
    }
}