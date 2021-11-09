using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDOM
{
    public class BoolDataType : TDataType<BoolDataType>
    {
        public BoolDataType():base(DataTypes.@bool)
        {

        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
