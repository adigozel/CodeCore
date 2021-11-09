using System;
using System.Collections.Generic;

namespace CDOM
{
    public class ClassDataType : TDataType<ClassDataType>
    {
        public ClassDataType(string classType):base(DataTypes.Class)
        {
            this.ClassType = classType;
        }

        public string ClassType { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }

        public override string ToString()
        {
            return this.Type.ToString();
        }
    }
}
