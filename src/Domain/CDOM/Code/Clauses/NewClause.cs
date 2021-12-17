using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class NewClause : Code
    {
        //public NewClause( )
        //{
        //    Parametrs = new List<TParameter>( );
        //    BlockEquals = new List<EqualsClause>( );
        //}

        public NewClause( string className )
        {
            ClassName = className;
        }

        public NewClause( string className, ICollection<EqualsClause> blockEquals ) : this( className )
        {
            BlockEquals = blockEquals;
        }

        public NewClause( string className, ICollection<TParameter> parametrs, ICollection<EqualsClause> blockEquals ) : this( className )
        {
            Parametrs = parametrs;
            BlockEquals = blockEquals;
        }

        public string ClassName { get; set; }
        public ICollection<TParameter> Parametrs { get; set; }
        public ICollection<EqualsClause> BlockEquals { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
