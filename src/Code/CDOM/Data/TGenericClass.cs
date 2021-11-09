using System;
using System.Collections.Generic;
using CDOM;

namespace CDOM
{
    public class TGenericClass : TClass
    {
        public TGenericClass(string name,TGeneric generic) : base(name)
        {
            this.Generic = generic;
        }

        public TGeneric Generic { get; set; }
    }
}
