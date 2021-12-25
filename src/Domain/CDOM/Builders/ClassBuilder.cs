using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM.Builders
{
    public class ClassBuilder
    {
        protected TClass _class;

        public ClassBuilder(TClass @class)
        {
            _class = @class;
        }

        public ClassBuilder()
        {

        }

        public ClassBuilder(string name, string packet, string fileName)
        {
            _class = new TClass(name, packet, fileName);
        }

        public ClassBuilder AddReference(string refrence)
        {
            _class.References.Add(refrence);
            return this;
        }

        public ClassBuilder AccessModifier(AccessModifier accessModifier)
        {
            _class.AccessModifier = accessModifier;
            return this;
        }

        public ClassBuilder BaseClass(string baseClass)
        {
            _class.BaseClass = baseClass;
            return this;
        }

        public ClassBuilder IsAbstract(bool isAbstract)
        {
            _class.IsAbstract = isAbstract;
            return this;
        }

        public ClassBuilder IsSealed(bool isSealed)
        {
            _class.IsSealed = isSealed;
            return this;
        }

        public ClassBuilder IsStatic(bool isStatic)
        {
            _class.IsStatic = isStatic;
            return this;
        }

        public ClassBuilder IsPartial(bool isPartial)
        {
            _class.IsPartial = isPartial;
            return this;
        }

        public ClassVariableBuilder AddVariable(string name)
        {
            return new ClassVariableBuilder(_class,name);
        }


        

    }
}
