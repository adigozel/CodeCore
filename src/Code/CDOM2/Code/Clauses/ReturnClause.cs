using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class ReturnClause: Code
    {
        public ReturnClause( Code clause )
        {
            Clause = clause;
        }

        public Code Clause { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
