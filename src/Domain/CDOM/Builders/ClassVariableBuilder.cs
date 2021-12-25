using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM.Builders
{
    public class ClassVariableBuilder:ClassBuilder
    {
        TVariable _variable;
        public ClassVariableBuilder(TClass @class,string name):base(@class)
        {
            _variable = new TVariable(name);
        }


        public new ClassVariableBuilder AccessModifier(AccessModifier accessModifier)
        {
            _variable.AccessModifier = accessModifier;
            return this;
        }

        public ClassVariableBuilder DataType(TDataType dataType)
        {
            _variable.DataType = dataType;
            return this;
        }

        public ClassVariableBuilder Value(string value)
        {
            _variable.Value = value;
            return this;
        }

        public ClassVariableBuilder IsConstant(bool isConstant)
        {
            _variable.IsConstant = isConstant;
            return this;
        }

        public new ClassVariableBuilder IsStatic(bool isStatic)
        {
            _variable.IsStatic = isStatic;
            return this;
        }
    }
}
