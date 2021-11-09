using System;
using System.Collections.Generic;

namespace CDOM
{
    public class ShortDataType : TDataType<ShortDataType>
    {
        public ShortDataType() : base(DataTypes.@short)
        {

        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }

    public class IntDataType : TDataType<IntDataType>
    {
        public IntDataType() :base(DataTypes.@int)
        {
        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }

    public class LongDataType : TDataType<LongDataType>
    {
        public LongDataType() : base(DataTypes.@long)
        {
        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
