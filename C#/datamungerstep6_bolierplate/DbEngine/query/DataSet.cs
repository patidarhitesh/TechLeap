using System.Collections.Generic;

namespace DbEngine.Query
{
    //This class will be acting as the DataSet containing multiple rows in a property named Rows
    public class DataSet
    {
        public List<Row> Rows { get; set; }

        public DataSet(List<Row> Rows)
        {
            this.Rows = Rows;
        }

        public DataSet() { }

        /*
	    This method will sort the dataSet based on the columnIndex
	    */
        public List<Row> SortData(string dataType, int columnIndex)
        {
           return null;
        }
    }
    
}
