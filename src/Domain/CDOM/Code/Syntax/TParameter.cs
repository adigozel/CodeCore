using CDOM;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CDOM
{
    public class TParameter:Code
    {
        public TParameter(TDataType type,string name)
        {
            this.DataType = type;
            this.Name = name;
            //this.Attributes = new List<TAttribute>();
        }

        //public TParameter(TDataType type, string name,IEnumerable<TAttribute> attributes)
        //{
        //    this.Type = type;
        //    this.Name = name;
        //    this.Attributes = attributes.ToList();
        //}

        public TDataType DataType { get; set; }
        public String Name { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
        //public ICollection<TAttribute> Attributes { get; set; }
    }
}
