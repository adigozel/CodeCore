using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TProperty:Code
    {
        public TProperty(AccessModifier accessModifier, TDataType dataType,string name)
        {
            this.AccessModifier = accessModifier;
            this.DataType = dataType;
            this.Name = name;
            this.GetMethod = new TGetAccessor(AccessModifier.none);
            this.SetMethod = new TSetAccessor(AccessModifier.none);
        }

        public AccessModifier AccessModifier { get; set; }
        public TDataType DataType { get; set; }
        public String Name { get; set; }

        public TGetAccessor GetMethod
        {
           get; set;
        }

        public TSetAccessor SetMethod
        {
            get; set;
        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
