using System;
using System.Collections.Generic;

namespace CDOM
{
    public class ShortDataType : TDataType<ShortDataType>
    {
        public ShortDataType() : base(DataTypes.@short)
        {

        }
    }

    public class IntDataType : TDataType<IntDataType>
    {
        public IntDataType() :base(DataTypes.@int)
        {
        }
    }

    public class LongDataType : TDataType<LongDataType>
    {
        public LongDataType() : base(DataTypes.@long)
        {
        }
    }
}
