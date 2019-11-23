using System;
using System.Collections.Generic;
using DbEngine.Query;
using System.Text.RegularExpressions;
using System.IO;
using System.Globalization;
using DbEngine.Query.Parser;

namespace DbEngine.Reader
{
    /* This class is used for evaluating queries without aggregate functions but with group by clause*/
    class CsvGroupByQueryProcessor : QueryProcessingEngine
    {
        /*
	    parameterized constructor to initialize filename. As you are trying to
	    perform file reading, hence you need to be ready to handle the IO Exceptions.
	   */
        private readonly string _fileName;

        /*
	    parameterized constructor to initialize filename. As you are trying to perform file reading, hence you need to be ready to handle the IO Exceptions.
	   */

        public CsvGroupByQueryProcessor(string fileName)
        {
            this._fileName = fileName;
        }

        /*
	    implementation of getHeader() method. We will have to extract the headers
	    from the first line of the file.
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
	 This method will take QueryParameter object as a parameter which contains the
	 parsed query and will process and populate the ResultSet
	 */
        public override DataSet GetDataRow(QueryParameter queryParameter)
        {
            /*
            * from QueryParameter object, read one condition at a time and evaluate the
            * same. For evaluating the conditions, we will use evaluateExpressions() method
            * of Filter class. Please note that evaluation of expression will be done
            * differently based on the data type of the field. In case the query is having
            * multiple conditions, you need to evaluate the overall expression i.e. if we
            * have OR operator between two conditions, then the row will be selected if any
            * of the condition is satisfied. However, in case of AND operator, the row will
            * be selected only if both of them are satisfied.
            */

            /*
		 * if the overall condition expression evaluates to true, then we need to check
		 * for the existence for group by clause in the Query Parameter. The dataSet
		 * generated after processing a group by clause is completely different from a
		 * dataSet structure(which contains multiple rows of data). In case of queries
		 * containing group by clause, the resultSet will contain multiple dataSets,
		 * each of which will be assigned to the group by column value i.e. for all
		 * unique values of the group by column, there can be multiple rows associated
		 * with it. Hence, we will use GroupedDataSet to store the same
		 * and not DataSet. Please note we will process queries containing one
		 * group by column only for this example.
		 */

            return null;

        }

    }
}
