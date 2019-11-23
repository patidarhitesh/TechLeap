namespace DbEngine.Query
{
    public class Header
    {
        public string[] Headers { get; set; }

        //implement constructor and override tostring method
        public Header(string[] Headers)
        {
            this.Headers = Headers;
        }
    }
}