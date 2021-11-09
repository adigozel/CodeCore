using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TAbstractMethod
    {
        public TAbstractMethod(string _name,
            AccessModifier accessModifier,
            TDataType returnType,
            ICollection<TParameter> parametrs)
        {
            this.Name = _name;
            this.AccessModifier = accessModifier;
            this.ReturnType = returnType;
            this.Parametrs = parametrs;
  

        }

        public string Name { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public TDataType ReturnType { get; set; }
        public ICollection<TParameter> Parametrs { get; set; }
    }
}
