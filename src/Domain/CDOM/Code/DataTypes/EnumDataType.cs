using System;
using System.Collections.Generic;

namespace CDOM
{
    public class EnumDataType : TDataType<EnumDataType>
    {
        public EnumDataType(): base(DataTypes.Enum)
        {
        }

        public string EnumType { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
