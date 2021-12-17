using System;
using System.Collections.Generic;

namespace CDOM
{

    public class TInterface:Code
    {
        public TInterface(string name)
        {
            Name = name;
            Methods = new List<TAbstractMethod>();
        }

        public IList<string> References { get; set; }
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public string BaseClass { get; set; }
        public bool IsPartial { get; set; }
        public IList<TAbstractMethod> Methods { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
