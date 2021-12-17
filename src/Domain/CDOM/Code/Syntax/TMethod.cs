using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TMethod:Code
    {
        public TMethod( )
        {
        }

        public TMethod( Code content)
        {
            Content = content;
        }

        public string Name { get; set; }
        public AccessModifier AccessModifier { get;  set; }
        public bool IsOverride { get; set; }
        public bool IsStatic { get; set; }
        public bool IsVirtual { get; set; }
        public TDataType ReturnType { get;  set; }
        public IList<TParameter> Parametrs { get;  set; }
        public Code Content { get; set; }
        public string RawContent { get;  set; }
        //public ICollection<TAttribute> Attributes { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
