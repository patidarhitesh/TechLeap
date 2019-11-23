namespace DbEngine.Query.Parser
{
    /* This class is used for storing name of field, aggregate function for 
    each aggregate function generate properties for this class, Also override toString method
   */
    public class AggregateFunction
    {
        public string field { get; set; }
        public string function { get; set; }

        public AggregateFunction(string field, string function)
        {
            this.field = field;
            this.function = function;
        }
    }
}