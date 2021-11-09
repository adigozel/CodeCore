using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class BlockClouse:ICodeDOM
    {
        //public TBlock( )
        //{
        //    Codes = new Queue<ICodeDOM>( );
        //}

        public BlockClouse( IEnumerable<ICodeDOM> codes )
        {
            Codes = codes;
        }

        public IEnumerable<ICodeDOM> Codes { get; set; }
    }
}
