namespace DbEngine.Query
{
    public class DataTypeDefinitions
    {
        public string[] DataTypes { get; set; }

        //implement constructor and override tostring method
        public DataTypeDefinitions(string[] Datatypes)
        {
            this.DataTypes = Datatypes;
        }
    }
}