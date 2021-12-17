using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class EqualsClause:Code
    {
        public EqualsClause( Code variable1, Code variable2 )
        {
            Variable1 = variable1;
            Variable2 = variable2;
        }

        public EqualsClause(string variableName1,string variableName2 )
        {
            Variable1 = new NameClouse( variableName1 );
            Variable2 = new NameClouse( variableName2 );
        }

        public Code Variable1 { get; set; }
        public Code Variable2 { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }

    }
}
