using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class BlockClouse:Code
    {
        //public TBlock( )
        //{
        //    Codes = new Queue<ICodeDOM>( );
        //}

        public BlockClouse( IEnumerable<Code> codes )
        {
            Codes = codes;
        }

        public IEnumerable<Code> Codes { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
