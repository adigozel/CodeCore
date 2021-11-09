using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDOM
{
    public class DecimalDataType : TDataType<DecimalDataType>
    {

        public DecimalDataType(int precision,int scale): base(DataTypes.@decimal)
        {
            Precision = precision;
            Scale = scale;
        }

        public int Precision { get; set; }
        public int Scale { get; set; }
    }


}
