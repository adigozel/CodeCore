using System;
using System.Collections.Generic;

namespace MSL
{
    public class TField
    {
        public TField()
        {

        }
        public TField(TDSLDataType dataType,string name)
        {
            this.DataType = dataType;
            this.Name = name;
        }

        public TDSLDataType DataType { get; set; }

        public string Name { get; set; }
    }

}
