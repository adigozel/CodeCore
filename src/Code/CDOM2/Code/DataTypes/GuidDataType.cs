using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDOM
{
    public class GuidDataType : TDataType<GuidDataType>
    {
        public GuidDataType() :base(DataTypes.Guid)
        {
        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
