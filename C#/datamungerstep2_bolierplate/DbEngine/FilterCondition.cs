namespace DbEngine
{
    /*
 * This class is used for storing name of field, condition and value for 
 * each conditions
 * generate properties for this class,
 * Also override tostring method
 * */
    public class FilterCondition
    {

        public string propertyName { get; set; }
        public string propertyValue { get; set; }
        public string condition { get; set; }
        // Write logic for constructor
        public FilterCondition(string propertyName, string propertyValue, string condition)
        {

            this.propertyName = propertyName;

            this.propertyValue = propertyValue;

            this.condition = condition;

        }

        override
        public string ToString()
        {
            return "1. Name of field: " + propertyName + "season 2. " + condition + "3. value: " + propertyValue;
        }
    }
}


