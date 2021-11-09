using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDOM
{
    public class DateTimeDataType : TDataType<DateTimeDataType>
    {
        public DateTimeDataType(): base(DataTypes.DateTime)
        {

        }

    }
}
