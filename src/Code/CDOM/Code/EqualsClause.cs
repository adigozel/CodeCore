using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class EqualsClause:ICodeDOM
    {
        public EqualsClause( string variable1, string variable2 )
        {
            Variable1 = variable1;
            Variable2 = variable2;
        }

        public string Variable1 { get; set; }
        public string Variable2 { get; set; }

    }
}
