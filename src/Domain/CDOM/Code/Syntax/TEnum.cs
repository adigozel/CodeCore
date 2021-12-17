using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TEnum:Code
    {

        public TEnum(string _name, Dictionary<string, int> items)
        {
            Name = _name;
            Items = items;
        }

        public TEnum(string _name)
        {
            Name = _name;
            Items = new Dictionary<string, int>();
        }

        public IList<string> References { get; set; }
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public Dictionary<string,int> Items { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
