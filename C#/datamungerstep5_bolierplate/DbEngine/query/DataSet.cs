﻿using System.Collections.Generic;

namespace DbEngine.Query
{

    //This class will be acting as the DataSet containing multiple rows. Iit should contain a property named as Rows and initialize the same in constructor
    public class DataSet
    {
        public List<Row> Rows { get; set; }

        public DataSet(List<Row> Rows)
        {
            this.Rows = Rows;
        }
    }
}
