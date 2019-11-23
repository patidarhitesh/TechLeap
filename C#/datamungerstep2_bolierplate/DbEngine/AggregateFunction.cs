namespace DbEngine
{
    /* This class is used for storing name of field, aggregate function for 
 * each aggregate function
 * generate properties for this class,
 * Also override toString method
 * */
    public class AggregateFunction
    {
        public string field { get; set; }

        private string function { get; set; }
        // Write logic for constructor
        public AggregateFunction(string field, string function)
        {
            this.field = field;
            this.function = function;



        }
        // override
        // public string ToString()
        // {
        //   return  "1. type of aggregate function(min/max/count/sum/avg) 2. field on which the aggregate function is being applied"
        // }
    }
}
