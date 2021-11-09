using System;
using System.Collections.Generic;

namespace MSL
{
    public class TQueryField:TField
    {
        public TQueryField()
        {

        }

        public TQueryField(TDSLDataType dataType, string name)
        {
            DataType = dataType;
            Name = name;
           // Compotencies = new List<TQueryFieldCompotency>();
        }

        public TQueryField(TDSLBaseTypes baseType, string name)
        {
            this.DataType = new TDSLDataType(baseType);
            Name = name;
            //Compotencies = new List<TQueryFieldCompotency>();
        }

        public TDSLBaseTypes BaseType { get
            {
                return this.DataType.BaseType;
            } }

        public bool IsCustom { get; set; }

        public string Formula { get; set; }

        //public ICollection<TQueryFieldCompotency> Compotencies { get; set; }

        public static TQueryField CreateFrom(TField entityField)
        {
            var queryField = new TQueryField(entityField.DataType, entityField.Name);

            return queryField;
        }

        public static TQueryField CreateFrom(TField entityField,string name,string formula)
        {
            var queryField = new TQueryField(entityField.DataType, name) { Formula = formula};

            return queryField;
        }
    }
}
