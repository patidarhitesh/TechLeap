using System;
using System.IO;
using DbEngine.Query;
using System.Text.RegularExpressions;


namespace DbEngine.Reader

{
    public class CsvQueryProcessor : QueryProcessingEngine
    {

        private readonly string _fileName;
        //private StreamReader _reader;
        /*
	    parameterized constructor to initialize filename. As you are trying to
	    perform file reading, hence you need to be ready to handle the IO Exceptions.
	   */
        public CsvQueryProcessor(string fileName)
        {
            this._fileName = fileName;

        }

        /*
	    implementation of getHeader() method. We will have to extract the headers
	    from the first line of the file.
	    */
        public override Header GetHeader()
        {
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
	     implementation of getColumnType() method. To find out the data types, we will
	     read the first line from the file and extract the field values from it. In
	     the previous assignment, we have tried to convert a specific field value to
	     Integer or Double. However, in this assignment, we are going to use Regular
	     Expression to find the appropriate data type of a field. Integers: should
	     contain only digits without decimal point Double: should contain digits as
	     well as decimal point Date: Dates can be written in many formats in the CSV
	     file. However, in this assignment,we will test for the following date
	     formats('dd/mm/yyyy','mm/dd/yyyy','dd-mon-yy','dd-mon-yyyy','dd-month-yy','dd-month-yyyy','yyyy-mm-dd')
	    */
        public override DataTypeDefinitions GetColumnType()
        {
            // checking for Integer

            // checking for floating point numbers

            // checking for date format dd/mm/yyyy

            // checking for date format mm/dd/yyyy

            // checking for date format dd-mon-yy

            // checking for date format dd-mon-yyyy

            // checking for date format dd-month-yy

            // checking for date format dd-month-yyyy

            // checking for date format yyyy-mm-dd

            string[] arr;
            int num;
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
                                    string b = sr.ReadLine();
                                    arr = b.Split(",");

                                    // h = new DataTypeDefinitions(sr.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries));

                                    string[] res = new string[arr.Length];

                                    try
                                    {

                                        // MatchCollection Integers = Regex.Matches(b, @"^\d$");
                                        //MatchCollection Dates = Regex.Matches(b, @"^\d{4}-((0\d)|(1[012]))-(([012]\d)|3[01])$");

                                        for (int i = 0; i < arr.Length; i++)
                                        {

                                           Match Integer = Regex.Match(arr[i], @"\d+");
                                            Match Date = Regex.Match(arr[i], @"\d{1,2}/\d{2,4}/\d{2,4}|\d{1,2}-\d{2,4}-\d{2,4}|\d{1,2}-\w*-\d{2,4}");

                                            if (Date.Index != 0)
                                            {
                                                res[i] = "System.DateTime";
                                            }
                                            
                                            else if (int.TryParse(arr[i], out num))
                                            {
                                                res[i] = "System.Int32";
                                            }
                                            else if (arr[i] == "")
                                            {
                                                res[i] = "System.Object";
                                            }
                                            else
                                            {
                                                res[i] = "System.String";
                                            }
                                        }


                                        h = new DataTypeDefinitions(res);
                                        return h;


                                    }
                                    catch (Exception) { }




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

        //This method will be used in the upcoming assignments
        public override void GetDataRow()
        {

        }
    }
}