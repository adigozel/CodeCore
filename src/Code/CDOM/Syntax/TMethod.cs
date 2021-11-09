using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TMethod
    {
        public TMethod( )
        {
            //Content = new TBlock( );
        }

        public string Name { get; set; }
        public AccessModifier AccessModifier { get;  set; }
        public bool IsOverride { get; set; }
        public bool IsStatic { get; set; }
        public bool IsVirtual { get; set; }
        public TDataType ReturnType { get;  set; }
        public ICollection<TParameter> Parametrs { get;  set; }
        public ICodeDOM Content { get; set; }
        public string RawContent { get;  set; }
        public ICollection<TAttribute> Attributes { get; set; }

    }
}
