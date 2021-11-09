using System;
using System.Linq;
using System.Collections.Generic;

namespace CDOM
{
    public class TClass: TCodeFile
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

            Attributes = new List<TAttribute>();
        }

        public AccessModifier AccessModifier { get; set; }

        public string BaseClass { get; set; }

        public bool IsAbstract { get; set; }

        public bool IsSealed { get; set; }

        public bool IsStatic { get; set; }

        public bool IsPartial { get; set; }

        public bool IsInherited
        {
            get
            {
                if (!string.IsNullOrEmpty(this.BaseClass) )
                    return true;
                else
                    return false;
            }
        }
        public List<TVariable> Variables { get; set; }
        public List<TAttribute> Attributes { get; set; }
        public List<TProperty> Properties { get; set; }
        public List<TMethod> Methods { get; set; }
        public List<TConstructor> Constructors { get; set; }
        public TClass AddVariables(IEnumerable<TVariable> variables)
        {

            foreach (var variable in variables)
                this.Variables.Add(variable);

            return this;
        }
        public TClass AddAttributes(IEnumerable<TAttribute> attributes)
        {
            foreach (var attribute in attributes)
                this.Attributes.Add(attribute);

            return this;
        }
        public TClass AddConstructors(IEnumerable<TConstructor> constructors)
        {
            foreach (var constructor in constructors)
                Constructors.Add(constructor);

            return this;
        }
        public TClass AddProperties(IEnumerable<TProperty> properties)
        {
            foreach (var property in properties)
                Properties.Add(property);

            return this;
        }
        public TClass AddMethods(IEnumerable<TMethod> methods)
        {
            //if (methods == null)
            //    return this;

            foreach (var method in methods)
                this.Methods.Add(method);

            return this;
        }

    }
}
