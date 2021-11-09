using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class ReturnClause: ICodeDOM
    {
        public ReturnClause( ICodeDOM clause )
        {
            Clause = clause;
        }

        public ICodeDOM Clause { get; set; }
    }
}
