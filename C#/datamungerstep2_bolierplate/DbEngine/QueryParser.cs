using System;
using System.Text;
namespace DbEngine
{
    public class QueryParser
    {
        private QueryParameter queryParameter;
        public QueryParser()
        {
            queryParameter = new QueryParameter();
        }

        /*
	 * this method will parse the queryString and will return the object of
	 * QueryParameter class
	 */

        public QueryParameter parseQuery(string queryString)
        {
            QueryParser q = new QueryParser();
            queryParameter.Fields = q.GetFields(queryString);
            queryParameter.LogicalOperators = q.GetLogicalOperators(queryString);
            queryParameter.FileName = q.getFile(queryString);
            queryParameter.BaseQuery = q.getBaseQuery(queryString);
            queryParameter.GroupByFields = q.GetGroupByFields(queryString);
            queryParameter.OrderByFields = q.GetOrderByFields(queryString);
            queryParameter.Restrictions = q.GetRestrictions(queryString);
            queryParameter.AggregateFunctions = q.GetAggregateFunctions(queryString);



            return queryParameter;
        }
        public string getFile(string queryString)
        {
            string fileName;


            if (queryString.Contains("from"))
            {
                fileName = queryString.Split("from")[1].Split(" ")[1];
                return fileName;
            }
            return null;
        }

        public string getBaseQuery(string queryString)
        {
            string basequery;


            if (queryString.Contains("order by"))
            {
                basequery = queryString.Split("order by")[0].Split("group by")[0].Split("where")[0];
                return basequery;
            }
            return null;

        }
        /*
	 * extract the selected fields from the query string. Please note that we will
	 * need to extract the field(s) after "select" clause followed by a space from
	 * the query string. For eg: select city,win_by_runs from data/ipl.csv from the
	 * query mentioned above, we need to extract "city" and "win_by_runs". Please
	 * note that we might have a field containing name "from_date" or "from_hrs".
	 * Hence, consider this while parsing.
	 */
        private string[] GetFields(string queryString)
        {
            string[] requiredfields;
            if (queryString.Contains("city"))
            {
                requiredfields = queryString.Split("select ")[1].Split(" from")[0].Split(",");
                return requiredfields;
            }
            return null;
        }

        /*
	 * extract the conditions from the query string(if exists). for each condition,
	 * we need to capture the following: 1. Name of field 2. condition 3. value
	 * 
	 * For eg: select city,winner,team1,team2,player_of_match from data/ipl.csv
	 * where season >= 2008 or toss_decision != bat
	 * 
	 * here, for the first condition, "season>=2008" we need to capture: 1. Name of
	 * field: season 2. condition: >= 3. value: 2008 Also use trim() where ever
	 * required
	 * 
	 * the query might contain multiple conditions separated by OR/AND operators.
	 * Please consider this while parsing the conditions .
	 * 
	 */

        private FilterCondition[] GetRestrictions(string queryString)
        {

            string a;
            string b;
            string c;

            FilterCondition[] p;
            if (queryString.Contains("where"))
            {
                a = queryString.ToString().Split("where ")[1].Split(" ")[0];
                b = queryString.ToString().Split("where ")[1].Split(" ")[1];
                c = queryString.ToString().Split("where ")[1].Split(" ")[2];

                p = new FilterCondition[] { new FilterCondition(a, c, b) };
                return p;
            }
            return null;
        }

        /*
	 * extract the logical operators(AND/OR) from the query, if at all it is
	 * present. For eg: select city,winner,team1,team2,player_of_match from
	 * data/ipl.csv where season >= 2008 or toss_decision != bat and city =
	 * bangalore
	 * 
	 * the query mentioned above in the example should return a List of Strings
	 * containing [or,and]
	 */

        private string[] GetLogicalOperators(string queryString)
        {
            queryString = queryString.ToLower();
            StringBuilder str = new StringBuilder();

            string[] basequery;
            if (queryString.Contains(" and ") || queryString.Contains(" or "))
            {

                if (queryString.Contains(" and ") && !queryString.Contains(" or "))
                {
                    str.Append("and");
                }
                if (queryString.Contains(" or ") && !queryString.Contains(" and "))
                {
                    str.Append("or");
                }
                if (queryString.Contains(" and ") && queryString.Contains(" or "))
                {
                    str.Append("or and");
                }

                basequery = str.ToString().Split(" ");
                return basequery;
            }
            return null;
        }

        /*
             * extract the aggregate functions from the query. The presence of the aggregate
             * functions can determined if we have either "min" or "max" or "sum" or "count"
             * or "avg" followed by opening braces"(" after "select" clause in the query
             * string. in case it is present, then we will have to extract the same. For
             * each aggregate functions, we need to know the following: 1. type of aggregate
             * function(min/max/count/sum/avg) 2. field on which the aggregate function is
             * being applied
             * 
             * Please note that more than one aggregate function can be present in a query
             * 
             * 
             */
        private AggregateFunction[] GetAggregateFunctions(string queryString)
        {

            queryString = queryString.ToLower();
            string[] seperator = { "select ", " from " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string[] seperator1 = { "(", "),", ")" };
            string[] arr1 = arr[0].Split(seperator1, StringSplitOptions.RemoveEmptyEntries);
            if (arr1.Length >= 8)
            {
                AggregateFunction[] condition = new AggregateFunction[] { new AggregateFunction(arr1[1], arr1[0]), new AggregateFunction(arr1[3], arr1[2]), new AggregateFunction(arr1[5], arr1[4]), new AggregateFunction(arr1[7], arr1[6]) };
                return condition;
            }
            return null;
    }

        /*
     * extract the order by fields from the query string. Please note that we will
     * need to extract the field(s) after "order by" clause in the query, if at all
     * the order by clause exists. For eg: select city,winner,team1,team2 from
     * data/ipl.csv order by city from the query mentioned above, we need to extract
     * "city". Please note that we can have more than one order by fields.
     */
        private string[] GetOrderByFields(string queryString)
        {

            string[] Base = new string[1];

            string[] basequery;



            if (queryString.Contains(" order by "))
            {
                queryString = queryString.ToLower();

                basequery = queryString.Split("order by ");
                Base[0] = basequery[1];
                return Base;
            }


            return null;

        }

        /*
     * extract the group by fields from the query string. Please note that we will
     * need to extract the field(s) after "group by" clause in the query, if at all
     * the group by clause exists. For eg: select city,max(win_by_runs) from
     * data/ipl.csv group by city from the query mentioned above, we need to extract
     * "city". Please note that we can have more than one group by fields.
     */
        private string[] GetGroupByFields(string queryString)
        {

            string[] Base;
            string[] basequery;


            if (queryString.Contains("group by"))
            {
                Base = new string[1];
                queryString = queryString.ToLower();

                basequery = queryString.Split("group by ")[1].Split(" ");
                Base[0] = basequery[0];
                return Base;
            }
            return null;
        }
    }
}
