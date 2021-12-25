using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TVariable: Code
    {
        public TVariable(string name)
        {
            this.Name = name;
        }

        public TVariable(
            AccessModifier accessModifier,
            TDataType dataType,
            string name):this(name)
        {
            this.AccessModifier = accessModifier;
            this.DataType = dataType;
        }

        public TVariable(
            AccessModifier accessModifier,
            TDataType dataType,
            string name,
            String value,
            bool isConstant = false,bool isStatic=false):this(accessModifier, dataType, name)
        {
            this.Value = value;
            this.IsConstant = isConstant;
            this.IsStatic = isStatic;
        }

        public AccessModifier AccessModifier { get; set; }
        public TDataType DataType { get; set; }
        public String Name { get; set; }
        public String Value { get; set; }
        public bool IsConstant { get; set; }
        public bool IsStatic { get; set; }

        public override bool Equals(object obj)
        {
            
            var other = obj as TVariable;

            if (other == null)
                return false;

            return other.DataType == DataType
                && other.Name == Name;
        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
