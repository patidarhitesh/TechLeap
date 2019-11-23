namespace DbEngine.Query
{
    public class DataTypeDefinitions
    {
        /*
	   This class should contain a property named as DataTypes which is a String array, to hold
	   the data type for all columns for all data types and should override
	   toString() method as well.
	 */
     //Define constructor to initialize this property
     public string[] DataTypes { get; set; }

        //implement constructor and override tostring method
        public DataTypeDefinitions(string[] DataTypes){
            this.DataTypes = DataTypes;
        }

    }
}