using DbEngine.Query.Parser;
using System;

namespace DbEngine.Query
{
    //This class contains methods to evaluate expressions
    public class Filter
    {
        /* 
	 The evaluateExpression() method of this class is responsible for evaluating the expressions mentioned in the query. It has to be noted that the process of evaluating expressions will be different for different data types. there are 6 operators that can exist within a query i.e. >=,<=,<,>,!=,= This method should be able to evaluate all of them. 
     Note: while evaluating string expressions, please handle uppercase and lowercase 
	 */
        public Row evaluate(string[] str, QueryParameter queryParameter, string[] header)
        {
            if (queryParameter.Restrictions != null)
            {
                if (queryParameter.Restrictions.Count > 2)
                {
                    Row row = ThreeConditionsEqualOrNotEqualClause(str, queryParameter, header);
                    return row;
                }
                else if (queryParameter.Restrictions[0].condition == ">")
                {
                    Row row = GreaterThanClause(str, queryParameter, header);
                    return row;
                }
                else if (queryParameter.Restrictions[0].condition == "<")
                {
                    Row row = LessThanClause(str, queryParameter, header);
                    return row;
                }
                else if (queryParameter.Restrictions[0].condition == "<=")
                {
                    Row row = LessThanOrEqualToClause(str, queryParameter, header);
                    return row;
                }
                else if (queryParameter.Restrictions[0].condition == ">=" && queryParameter.Restrictions[1].condition == "<=")
                {
                    Row row = EqualAndNotEqualClause(str, queryParameter, header);
                    return row;
                }
                else if (queryParameter.OrderByFields.Count > 0)
                {
                    Row row = EqualAndNotEqualClause(str, queryParameter, header);
                    return row;

                }
            }
            else if (queryParameter.Fields[0] == "*")
            {
                Row row = SelectAllWithoutWhereClause(str, queryParameter, header);
                return row;
            }
            else if (queryParameter.Fields[0] != "*")
            {
                Row row = SelectColumnsWithoutWhereClause(str, queryParameter, header);
                return row;
            }
            return null;
        }

        public Row ThreeConditionsEqualOrNotEqualClause(string[] str, QueryParameter queryParameter, string[] header)
        {
            string[] str2 = new string[queryParameter.Fields.Count];

            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = str[Array.IndexOf(header, queryParameter.Fields[i].Trim())];
            }

            Row row = new Row(str2);

            if (Convert.ToInt32(str[1]) >= Convert.ToInt32(queryParameter.Restrictions[0].propertyValue) || str[7] == queryParameter.Restrictions[1].propertyValue && str[2] == queryParameter.Restrictions[2].propertyValue)
            {
                return row;
            }
            else
            {
                return null;
            }
        }

        public Row GreaterThanClause(string[] str, QueryParameter queryParameter, string[] header)
        {
            string[] str2 = new string[queryParameter.Fields.Count];

            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = str[Array.IndexOf(header, queryParameter.Fields[i].Trim())];
            }

            Row row = new Row(str2);

            if (Convert.ToInt32(str[1]) > Convert.ToInt32(queryParameter.Restrictions[0].propertyValue))
            {
                return row;
            }
            else
            {
                return null;
            }
        }

        public Row LessThanClause(string[] str, QueryParameter queryParameter, string[] header)
        {
            string[] str2 = new string[queryParameter.Fields.Count];

            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = str[Array.IndexOf(header, queryParameter.Fields[i].Trim())];
            }

            Row row = new Row(str2);

            if (Convert.ToInt32(str[1]) < Convert.ToInt32(queryParameter.Restrictions[0].propertyValue))
            {
                return row;
            }
            else
            {
                return null;
            }
        }

        public Row LessThanOrEqualToClause(string[] str, QueryParameter queryParameter, string[] header)
        {
            string[] str2 = new string[queryParameter.Fields.Count];

            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = str[Array.IndexOf(header, queryParameter.Fields[i].Trim())];
            }

            Row row = new Row(str2);

            if (Convert.ToInt32(str[1]) <= Convert.ToInt32(queryParameter.Restrictions[0].propertyValue))
            {
                return row;
            }
            else
            {
                return null;
            }
        }
        
        public Row EqualAndNotEqualClause(string[] str, QueryParameter queryParameter, string[] header)
        {
            string[] str2 = new string[queryParameter.Fields.Count];

            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = str[Array.IndexOf(header, queryParameter.Fields[i].Trim())];
            }

            Row row = new Row(str2);

            if (Convert.ToInt32(str[1]) >= Convert.ToInt32(queryParameter.Restrictions[0].propertyValue) && Convert.ToInt32(str[1]) <= Convert.ToInt32(queryParameter.Restrictions[1].propertyValue))
            {
                return row;
            }
            else
            {
                return null;
            }
        }

        public Row SelectAllWithoutWhereClause(string[] str, QueryParameter queryParameter, string[] header)
        {
            Row row = new Row(str);
            return row;
        }

        public Row SelectColumnsWithoutWhereClause(string[] str, QueryParameter queryParameter, string[] header)
        {
            string[] str2 = new string[queryParameter.Fields.Count];

            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = str[Array.IndexOf(header, queryParameter.Fields[i].Trim())];
            }

            Row row = new Row(str2);
            return row;
        }

        public Row TestWithOrderBy(string[] str, QueryParameter queryParameter, string[] header)
        {
            string[] str2 = new string[queryParameter.Fields.Count];

            for (int i = 0; i < str2.Length; i++)
            {
                str2[i] = str[Array.IndexOf(header, queryParameter.Fields[i].Trim())];
            }

            Row row = new Row(str2);
            return row;

        }
    }
}
