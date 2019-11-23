using System.Linq;
using System.Text;
using System;

namespace DbEngine
{
    public class QueryTransform
    {
        /*
    * This method will split the query string based on space into an array of words
    * and display it on console.
    */
        public string[] GetSplitString(string query)
        {
            String[] separator = { " " };

            String[] strlist = query.Split(separator,
               StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strlist.Length; i++)
            {
                strlist[i] = strlist[i].ToLower();
            }
            return strlist;


        }

        /*
   * Extract the name of the file from the query. File name can be found after a
   * space after "from" clause. Note: CSV file can contain a field that contains
   * from as a part of the column name. For eg: from_date,from_hrs etc.
   * 
   * Please consider this while extracting the file name in this method.
   */
        public string GetFileName(string query)
        {
            string f = "from";
            string str = query.Substring(query.IndexOf(f));
            String[] separator = { " " };

            String[] strlist = str.Split(separator,
               StringSplitOptions.RemoveEmptyEntries);

            return strlist[1];
        }

        /*
	 * This method is used to extract the baseQuery from the query string. BaseQuery
	 * contains from the beginning of the query till the where clause.
	 * 
	 * Note: 1. The query might not contain where clause but contain order by or
	 * group by clause 2. The query might not contain where, order by or group by
	 * clause 3. The query might not contain where, but can contain both group by
	 * and order by clause.
	 */
        public string GetBaseQuery(string query)
        {
            String Base;
            query = query.ToLower();
            if (query.Contains("where"))
            {
                String[] basequery = query.Split(" where");
                Base = basequery[0];
            }
            else if (query.Contains("group by"))
            {
                String[] basequery = query.Split(" group by");
                Base = basequery[0];
            }
            else if (query.Contains("order by"))
            {
                String[] basequery = query.Split(" order by");
                Base = basequery[0];
            }
            else
            {
                Base = "";
            }
            return Base;
        }


        //Step II

        /*
	     * This method will extract the fields to be selected from the query string. The
	     * query string can have multiple fields separated by comma. The extracted
	     * fields will be stored in a String array which is to be printed in console as
	     * well as to be returned by the method
	     * 
	     * Note: 1. The field name or value in the condition can contain keywords as a
	     * substring. For eg: from_city,job_order_no,group_no etc. 2. The field name can
	     * contain '*'
	     * 
	     */

        public string[] GetFieldsNames(string queryString)
        {
            String[] separator = { " " };

            String[] strlist = queryString.Split(separator,
               StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < strlist.Length; i++)
            {
                strlist[i] = strlist[i].ToLower();
            }
            String[] separator2 = { "," };
            String[] strlist2 = strlist[1].Split(separator2,
           StringSplitOptions.RemoveEmptyEntries);
            return strlist2;
        }

        /*
	     * This method is used to extract the conditions part from the query string. The
	     * conditions part contains starting from where keyword till the next keyword,
	     * which is either group by or order by clause. In case of absence of both group
	     * by and order by clause, it will contain till the end of the query string.
	     * Note: 1. The field name or value in the condition can contain keywords as a
	     * substring. For eg: from_city,job_order_no,group_no etc. 2. The query might
	     * not contain where clause at all.
	     */
        public string GetConditionsPartQuery(string queryString)
        {
            String Base;
            queryString = queryString.ToLower();
            if (queryString.Contains("where"))
            {
                String[] basequery = queryString.Split("where ");
                Base = basequery[1];
            }

            else if (queryString.Contains("order by"))
            {
                String[] basequery = queryString.Split(" order by");
                String[] basequery2 = basequery[1].Split("where ");
                Base = basequery2[0];
            }
            else
            {
                Base = "";
            }
            return Base;
        }

        /*
	     * This method will extract condition(s) from the query string. The query can
	     * contain one or multiple conditions. In case of multiple conditions, the
	     * conditions will be separated by AND/OR keywords. for eg: Input: select
	     * city,winner,player_match from ipl.csv where season > 2014 and city
	     * ='Bangalore'
	     * 
	     * This method will return a string array ["season > 2014","city ='Bangalore'"]
	     * and print the array
	     * 
	     * Note: 1. The field name or value in the condition can contain keywords as a
	     * substring. For eg: from_city,job_order_no,group_no etc. 2. The query might
	     * not contain where clause at all.
	     */
        public string[] GetConditions(string queryString)
        {
            string[] Base = new string[2];
            queryString = queryString.ToLower();
            if (queryString.Contains(" and"))
            {
                String[] basequery = queryString.Split("where ");
                String[] basequery2 = basequery[1].Split(" and ");
                Base = basequery2;
            }
            else if (queryString.Contains(" or"))
            {
                String[] basequery = queryString.Split("where ");
                String[] basequery3 = basequery[1].Split(" or ");
                Base = basequery3;
            }

            else
            {
                Base = null;
            }
            return Base;
        }

        //Step III

        /*
	     * This method will extract logical operators(AND/OR) from the query string. The
	     * extracted logical operators will be stored in a String array which will be
	     * returned by the method and the same will be printed Note: ------- 1. AND/OR
	     * keyword will exist in the query only if where conditions exists and and it
	     * contains multiple conditions. 2. AND/OR can exist as a substring in the
	     * conditions as well. For eg: name='Alexander',color='Red' etc. Please consider
	     * these as well when extracting the logical operators.
	     * 
	     */

        public string[] GetLogicalOperators(string queryString)
        {
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
            String[] basequery = str.ToString().Split(" ");
            return basequery;
        }

        /*
	     * This method extracts the order by fields from the query string. Note: 1. The
	     * query string can contain more than one order by fields. 2. The query string
	     * might not contain order by clause at all. 3. The field names, condition
	     * values might contain "order" as a substring. For eg: order_number,job_order
	     * Consider this while extracting the order by fields
	    */
        public string[] GetOrderByFields(string queryString)
        {

            if (queryString.Contains("order by"))
            {
                string[] Base = new string[1];
                queryString = queryString.ToLower();

                String[] basequery = queryString.Split("order by ");
                Base[0] = basequery[1];


                return Base;
            }
            else
            {
                return null;
            }
        }

        //Step IV

        /*
	     * This method extracts the group by fields from the query string. Note: ------
	     * 1. The query string can contain more than one group by fields. 2. The query
	     * string might not contain group by clause at all. 3. The field names,
	     * condition values might contain "group" as a substring. For eg: newsgroup_name
	     * Consider this while extracting the group by fields
	    */
        public string[] GetGroupByFields(string queryString)
        {
            if (queryString.Contains("group by"))
            {
                string[] Base = new string[1];
                queryString = queryString.ToLower();

                String[] basequery = queryString.Split("group by ");
                Base[0] = basequery[1];


                return Base;
            }
            else
            {
                return null;
            }
        }

        /*
	 * This method extracts the aggregate functions from the query string. Note: 1.
	 * aggregate functions will start with "sum"/"count"/"min"/"max"/"avg" followed
	 * by "(" 2. The field names might contain "sum"/"count"/"min"/"max"/"avg" as a
	 * substring. For eg: account_number,consumed_qty,nominee_name
	 * 
	 * Consider this while extracting the aggregate functions
	 */
        public string[] GetAggregateFunctions(string queryString)
        {


            queryString = queryString.ToLower();

            String[] basequery = queryString.Split(" ");
            String[] basequery2 = basequery[1].Split(",");
            int l = basequery.Length;
            string[] Base = new string[l];
            Base = basequery2;


            return Base;

        }
    }
}
