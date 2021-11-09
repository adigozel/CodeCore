using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public abstract class Code
    {

        protected Code(  )
        {
        }

        public abstract string GenerateCode( ISyntaxAdapter adabter );
    }
}
