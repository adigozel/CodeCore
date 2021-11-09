using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class CodeBuilder
    {
        private List<Code> _codes;

        public CodeBuilder( )
        {
            _codes = new List<Code>( );
        }

        public CodeBuilder Add(Code code )
        {
            _codes.Add( code );
            return this;
        }

        public CodeBuilder Add(IEnumerable<Code> codes )
        {
            _codes.AddRange( codes );
            return this;
        }



        public static CodeBuilder Instance => new CodeBuilder( );



    }
}
