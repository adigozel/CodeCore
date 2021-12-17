using System;
using System.Collections.Generic;

namespace CDOM
{
    public class StringDataType: TDataType<StringDataType>
    {

        public StringDataType(int length): base(DataTypes.String)
        {
            this.Length = length;
        }

        public int Length { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            throw new NotImplementedException( );
        }
    }
}
