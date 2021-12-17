using System;
using System.Linq;
using System.Collections.Generic;

namespace CDOM
{
    public class TClass: Code
    {
        public TClass(string name)
        {
            Name = name;

            //By defualt Filename is same to name
            FileName = name;

            Variables = new List<TVariable>();

            Constructors = new List<TConstructor>();

            Properties = new List<TProperty>();

            Methods = new List<TMethod>();

            //Attributes = new List<TAttribute>();
        }
        public IList<string> References { get; set; }
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
        public AccessModifier AccessModifier { get; set; }
        public string BaseClass { get; set; }
        public bool IsAbstract { get; set; }
        public bool IsSealed { get; set; }
        public bool IsStatic { get; set; }
        public bool IsPartial { get; set; }
        public IList<TVariable> Variables { get; set; }
        //public List<TAttribute> Attributes { get; set; }
        public IList<TProperty> Properties { get; set; }
        public IList<TMethod> Methods { get; set; }
        public IList<TConstructor> Constructors { get; set; }
        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            return adabter.GenerateCode( this );
        }
    }
}
