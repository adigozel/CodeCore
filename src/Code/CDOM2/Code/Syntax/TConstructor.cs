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
                ICollection<TParameter> parametrs )
            {
                this.Type = type;
                this.Parametrs = parametrs;
            }


            public MethodType Type { get; set; }
            public ICollection<TParameter> Parametrs { get; set; }

        }

        public TConstructor( )
        {
            Parametrs = new List<TParameter>( );
        }

        public TConstructor(
            AccessModifier accessModifier,
            ICollection<TParameter> parametrs,
            Content content,
            TReferenceMethod referenceMethod = null)
        {
            AccessModifier = accessModifier;
            Content = content;
            Parametrs = parametrs;
            ReferenceMethod = referenceMethod;
        }

        public AccessModifier AccessModifier { get; set; }
        public Content Content { get; set; }
        public TReferenceMethod ReferenceMethod { get; set; }
        public ICollection<TParameter> Parametrs { get; set; }

        public TConstructor AddParameter(TParameter parameter )
        {
            Parametrs.Add( parameter );
            return this;
        }

        public TConstructor AddParameter( TDataType dataType,string name )
        {
            return this.AddParameter( new TParameter(dataType,name) );
        }

        public TConstructor AddParameter( string  classDataTypeName, string name )
        {
            return this.AddParameter( new ClassDataType( classDataTypeName ),name);
        }

        public TConstructor AddContentCode(Code code )
        {
            this.Content.AddCode( code );
            return this;
        }

        public TConstructor AddContentCodeRange(IEnumerable<Code> codes )
        {
            this.Content.AddCodeRange( codes );
            return this;
        }

        public  static TConstructor Insance => new TConstructor( );

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
