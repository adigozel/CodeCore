using System;
using System.Collections.Generic;

namespace CDOM
{

    public class TInterface:TCodeFile
    {
        public TInterface(string name)
        {
            Name = name;
            Methods = new List<TAbstractMethod>();
        }

        public AccessModifier AccessModifier { get; set; }
        public string BaseClass { get; set; }
        public bool IsPartial { get; set; }
        public bool IsInherited
        {
            get
            {
                if (!string.IsNullOrEmpty(this.BaseClass))
                    return true;
                else
                    return false;
            }
        }
        public ICollection<TAbstractMethod> Methods { get; set; }
        public TInterface AddMethods(IEnumerable<TAbstractMethod> methods)
        {
            foreach (var method in methods)
                this.Methods.Add(method);

            return this;
        }

    }
}
