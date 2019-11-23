using System;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;
using DbEngine.Query;
using DbEngine.Query.Parser;
using System.Collections.Generic;

namespace DbEngine.Reader
{
    public class CsvQueryProcessor : QueryProcessingEngine
    {
        private readonly string _fileName;

        /*
	    parameterized constructor to initialize filename. As you are trying to perform file reading, hence you need to be ready to handle the IO Exceptions.
	   */
        public CsvQueryProcessor(string fileName)
        {
            this._fileName = fileName;
        }

        /*
          read the first line which contains the header. Please note that the headers can contain spaces in between them. For eg: city, winner
          */
        public override Header GetHeader()
        {
            Header header;

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
                                header = new Header(sr.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries));
                                return header;
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

            return null;
        }

        /*
	     implementation of getColumnType() method. To find out the data types, we will
	     read the first line after the header row from the file and extract the field values from it. In
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
            DataTypeDefinitions data;

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
                                int num;
                                string[] str, str1;
                                string str2;

                                str2 = sr.ReadLine();
                                str = (sr.ReadLine()).Split(",");
                                str1 = new string[str.Length];

                                for (int i = 0; i < str.Length; i++)
                                {
                                    Match match = Regex.Match(str[i], @"\d{1,2}/\d{2,4}/\d{2,4}|\d{1,2}-\d{2,4}-\d{2,4}|\d{1,2}-\w*-\d{2,4}");

                                    if (int.TryParse(str[i], out num))
                                    {
                                        str1[i] = "System.Int32";
                                    }
                                    else if (match.Index != 0)
                                    {
                                        str1[i] = "System.DateTime";
                                    }
                                    else if (str[i] == "")
                                    {
                                        str1[i] = "System.Object";
                                    }
                                    else
                                    {
                                        str1[i] = "System.String";
                                    }
                                }

                                data = new DataTypeDefinitions(str1);
                                return data;
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

            return null;
        }

        /*
	    This method will take QueryParameter object as a parameter which contains the parsed query and will process and populate the DataSet
	    */
        public override DataSet GetDataRow(QueryParameter queryParameter)
        {
            DataSet data;
            Row row;
            List<Row> rows = new List<Row>();
            Header header = GetHeader();
            Filter filter = new Filter();

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
                                string str1 = sr.ReadLine();

                                while (!sr.EndOfStream)
                                {
                                    row = filter.evaluate((sr.ReadLine()).Split(","), queryParameter, header.Headers);

                                    if(row != null)
                                    {
                                        rows.Add(row);
                                    }
                                }
                            
                                data = new DataSet(rows);
                                return data;
                            }
                            catch (Exception)
                            {
                                throw new FileNotFoundException("System.IO.FileNotFoundException");
                            }
                            finally
                            {
                                sr.Close();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        throw new FileNotFoundException("System.IO.FileNotFoundException");
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw new FileNotFoundException("System.IO.FileNotFoundException");
            }

           // return null;
        }

    }
}