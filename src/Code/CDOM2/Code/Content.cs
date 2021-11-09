using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public  class Content:Code
    {
        private List<Code> _codes;
        public Content( )
        {
            _codes = new List<Code>( );
        }

        public Content AddCode(Code code)
        {
            _codes.Add( code );
            return this;
        }

        public Content AddCodeRange(IEnumerable<Code> codes )
        {
            _codes.AddRange( codes );
            return this;
        }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            throw new NotImplementedException( );
        }
    }
}
