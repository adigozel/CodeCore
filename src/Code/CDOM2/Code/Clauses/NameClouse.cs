using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class NameClouse : Code
    {
        public NameClouse( string value )
        {
            Value = value;
        }

        public string Value { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
