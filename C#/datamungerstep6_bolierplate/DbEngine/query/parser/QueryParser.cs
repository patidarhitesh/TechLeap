using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DbEngine.Query.Parser
{
    public class QueryParser
    {
        private QueryParameter queryParameter;

        public QueryParser()
        {
            queryParameter = new QueryParameter();
        }

        public QueryParameter parseQuery(string queryString)
        {
            int index1, index2;
            index1 = queryString.IndexOf(" group by ");
            index2 = queryString.IndexOf(" order by ");

            if (index1 != -1 && index2 != -1)
            {
                string[] str = GetGroupByOrderByFields(queryString);

                string[] arr1 = new string[1];
                string[] arr2 = new string[1];

                arr1[0] = str[1];
                arr2[0] = str[2];

                queryParameter.GroupByFields = arr1.ToList<String>();
                queryParameter.OrderByFields = arr2.ToList<String>();
            }
            else
            {
                queryParameter.GroupByFields = GetGroupByFields(queryString);
                queryParameter.OrderByFields = GetOrderByFields(queryString);
            }

            queryParameter.File = GetFileName(queryString);
            queryParameter.QueryString = queryString;
            queryParameter.LogicalOperators = GetLogicalOperators(queryString);
            queryParameter.Fields = GetFields(queryString);
            queryParameter.Restrictions = GetRestrictions(queryString);
            queryParameter.AggregateFunctions = GetAggregateFunctions(queryString);
            queryParameter.BaseQuery = GetBaseQuery(queryString);

            return queryParameter;
        }

        /*
	 * extract the selected fields from the query string. Please note that we will
	 * need to extract the field(s) after "select" clause followed by a space from
	 * the query string. For eg: select city,win_by_runs from data/ipl.csv from the
	 * query mentioned above, we need to extract "city" and "win_by_runs". Please
	 * note that we might have a field containing name "from_date" or "from_hrs".
	 * Hence, consider this while parsing.
	 */

        private string GetFileName(string query)
        {
            query = query.ToLower();
            string[] seperator = { " from ", " where " };
            string[] arr = query.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length >= 1)
            {
                return arr[1];
            }
            else
            {
                return "";
            }

        }

        public string GetBaseQuery(string query)
        {
            query = query.ToLower();
            string[] seperator = { " where " };
            string[] arr = query.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return arr[0];
        }

        private List<String> GetFields(string queryString)
        {
            queryString = queryString.ToLower();
            string[] seperator = { "select ", " where ", " from " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string[] arr1 = arr[0].Split(",");
            return arr1.ToList<String>();
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

        private List<Restriction> GetRestrictions(string queryString)
        {
            queryString = queryString.ToLower();
            string[] seperator = { " where ", " order ", " group " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string[] seperator1 = { " and ", " or ", " not " };

            if (arr.Length >= 2)
            {
                string[] arr1 = arr[1].Split(seperator1, StringSplitOptions.RemoveEmptyEntries);
                List<Restriction> condition = new List<Restriction>();

                foreach (var item in arr1)
                {
                    string[] arr2 = item.Split(" ");
                    Restriction res = new Restriction(arr2[0], arr2[2], arr2[1]);

                    if (arr2.Length >= 3)
                    {
                        condition.Add(res);
                    }
                }
                return condition;
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

        private List<String> GetLogicalOperators(string queryString)
        {
            queryString = queryString.ToLower();
            string[] seperator = { " and ", " or ", " not " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string[] arr1 = new string[arr.Length - 1];
            string[] arr2 = queryString.Split(" ");
            int count = 0;

            foreach (var item in arr2)
            {
                if (item == "and" || item == "or" || item == "not")
                {
                    arr1[count] = item;
                    count++;
                }
            }
            return arr1.ToList<String>();
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
        private List<AggregateFunction> GetAggregateFunctions(string queryString)
        {
            queryString = queryString.ToLower();
            string[] seperator = { "select ", " from " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            string[] seperator1 = { "(", "),", ")" };
            string[] arr1 = arr[0].Split(seperator1, StringSplitOptions.RemoveEmptyEntries);

            if (arr1.Length >= 8)
            {
                List<AggregateFunction> condition = new List<AggregateFunction> { new AggregateFunction(arr1[1], arr1[0]), new AggregateFunction(arr1[3], arr1[2]), new AggregateFunction(arr1[5], arr1[4]), new AggregateFunction(arr1[7], arr1[6]) };
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
        private List<String> GetOrderByFields(string queryString)
        {
            queryString = queryString.ToLower();
            string[] seperator = { " order by " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length >= 2)
            {
                string[] arr1 = arr[1].Split(",");
                return arr1.ToList<String>();
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
        private List<String> GetGroupByFields(string queryString)
        {
            queryString = queryString.ToLower();
            string[] seperator = { " group by " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);

            if (arr.Length >= 2)
            {
                string[] arr1 = arr[1].Split(",");
                return arr1.ToList<String>();
            }
            return null;
        }

        private string[] GetGroupByOrderByFields(string queryString)
        {
            queryString = queryString.ToLower();
            string[] seperator = { " order by ", " group by " };
            string[] arr = queryString.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
            return arr;
        }
    }
}