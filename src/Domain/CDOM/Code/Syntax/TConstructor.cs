using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDOM
{

    public class TConstructor:Code
    {
        public class TReferenceMethod
        {
            public enum MethodType { @base, @this }

            public TReferenceMethod(
                TReferenceMethod.MethodType type,
                IList<TParameter> parametrs )
            {
                this.Type = type;
                this.Parametrs = parametrs;
            }

            public MethodType Type { get; set; }
            public IList<TParameter> Parametrs { get; set; }

        }

        public TConstructor( )
        {
            Parametrs = new List<TParameter>( );
        }

        public TConstructor(
            AccessModifier accessModifier,
            IList<TParameter> parametrs,
            Content content,
            TReferenceMethod referenceMethod = null)
        {
            AccessModifier = accessModifier;
            Content = content;
            Parametrs = parametrs;
            ReferenceMethod = referenceMethod;
        }

        public AccessModifier AccessModifier { get; set; }
        public Code Content { get; set; }
        public TReferenceMethod ReferenceMethod { get; set; }
        public IList<TParameter> Parametrs { get; set; }
        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
