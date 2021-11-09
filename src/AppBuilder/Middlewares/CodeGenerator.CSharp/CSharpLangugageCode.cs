using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenerator.Langugage;
using CodeGenerator.Core;
using CodeGenerator.Core.Types;

namespace CodeGenerator.CSharp
{

    public  class CSharpLangugageCode : ILungugageCode
    {
        private readonly ILangugageKeys keys;

        public CSharpLangugageCode()
        {
            keys = new CSharpLangugageKeys();
        }

        public string AccessModiferAsCode(AccessModifier accessorModifer)
        {
            if (accessorModifer != AccessModifier.none)
                return accessorModifer.ToString();
            else
                return string.Empty;
        }

        public string AttributeAsCode(TAttribute attribute)
        {
            if (attribute == null)
                return string.Empty;

            if (string.IsNullOrEmpty(attribute.Content))
                return $"[{attribute.Name}]";
            else
                return $"[{attribute.Name}({attribute.Content})]";
        }

        private string AttributesAsCode(IEnumerable<TAttribute> attributes)
        {
            if (attributes == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            foreach (var attribute in attributes)
                source.AppendLine(AttributeAsCode(attribute));

            return source.ToString();
        }

        public string ClassDescriptionAsCode(TClassDescription description)
        {
            if (description == null)
                return string.Empty;

            StringBuilder code = new StringBuilder();

            if (description.IsAbstract && (description.IsSealed || description.IsStatic))
                throw new Exception("an abstract class cannot be sealed or static");

            if (description.IsStatic && description.IsSealed)
                throw new Exception("a class cannot be both static and sealed");

            code.Append(" ");

            if (description.IsAbstract)
                code.Append(Keys().Abstract);

            if (description.IsSealed)
                code.Append(" ").Append(Keys().Sealed);

            if (description.IsStatic)
                code.Append(" ").Append(Keys().Static);

            if (description.IsPartial)
                code.Append(" ").Append(Keys().Partial);

            if (code.Length == 1)
                return "";
            else
                return code.ToString();
        }

        public string InterfaceDescriptionAsCode(TInterfaceDescription description)
        {
            if (description == null)
                return string.Empty;

            StringBuilder code = new StringBuilder();

            if (description.IsPartial)
                code.Append(" ").Append(Keys().Partial);

            return code.ToString();
        }

        //public string ClassInheritanceAsCode(string baseClass, IEnumerable<string> baseInterfaces)
        //{
        //    StringBuilder code = new StringBuilder();

        //    if (!string.IsNullOrEmpty(baseClass))
        //        code.Append(baseClass);

        //    foreach (var baseInterface in baseInterfaces)
        //        code.Append(code.Append(baseInterface)).Append(",");

        //    var result = code.ToString();

        //    if (baseInterfaces.Count() > 0)
        //        result = result.Substring(0, result.Length - 1);

        //    return result;
        //}

        public string ConstructorAsCode(string className, TConstructor constructor)
        {
            if (constructor == null)
                return string.Empty;

            StringBuilder code = new StringBuilder();

            code.Append(AccessModiferAsCode(constructor.AccessModifier))
                .Append(" ").Append(className).Append("(").Append(ParametersAsCode(constructor.Parametrs)).Append(")")
                .Append(BaseConstructorAsCode(constructor.ReferenceMethod))
                .AppendLine()
                .Append(Keys().BeginBlock)
                .AppendLine()
                .Append(constructor.Content.Trim('\n', '\r'))
                .AppendLine()
                .Append(Keys().EndBlock);

            return code.ToString();
        }

        private String BaseConstructorAsCode(TReferenceMethod referenceMethod)
        {
            StringBuilder code = new StringBuilder();

            if (referenceMethod != null)
            {
                code.Append(":")
                    .Append(referenceMethod.Type.ToString())
                    .Append("(")
                    .Append(BaseParametersAsCode(referenceMethod.Parametrs))
                    .Append(")");
            }

            return code.ToString();
        }

        public string DataTypeAsContent(TDataType dataType)
        {
            
            //if (dataType == null)
            //    return string.Empty;

            StringBuilder source = new StringBuilder();

            if (dataType.Type == DataTypes.Class)
            {
                source.Append((dataType as ClassDataType).ClassType);
            }
            else if (dataType.Type == DataTypes.Enum)
            {
                source.Append((dataType as EnumDataType).EnumType);
            }
            else if (dataType.Type == DataTypes.Binary)
            {
                source.Append((dataType as BinaryDataType).BinaryType);
            }
            else
            {
                source.Append(dataType.Type.ToString());
            }

            if (dataType.IsNullable)
            {
                if (dataType.Type == DataTypes.Guid
                    || dataType.Type == DataTypes.@bool
                    || dataType.Type == DataTypes.DateTime
                    || dataType.Type == DataTypes.@decimal
                    || dataType.Type==DataTypes.@short
                    || dataType.Type == DataTypes.@int
                    || dataType.Type==DataTypes.@long)
                {
                    source.Append("?");
                }
            }

            return source.ToString();
        }

        public ILangugageKeys Keys()
        {
            return keys;
        }

        public string MethodDescriptionAsCode(TMehodDescription description)
        {
            if (description == null)
                return string.Empty;

            StringBuilder code = new StringBuilder();

            if (description.IsStatic && (description.IsOverride || description.IsVirtual ))
                throw new Exception("a static memeber cannot be marked as override,virtual or abstract");

            if (description.IsVirtual)
                code.Append(" ").Append(Keys().Virtual);

            if (description.IsStatic)
                code.Append(" ").Append(Keys().Static);

            if (description.IsOverride)
                code.Append(" ").Append(Keys().Override);

            return code.ToString();
        }

        public string AbstractMethodAsCode(TAbstractMethod method)
        {
            if (method == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            var accessCode = AccessModiferAsCode(method.AccessModifier);
            var returnTypeCode = method.ReturnType != null ? DataTypeAsContent(method.ReturnType) : "void";
            var parametersCode = ParametersAsCode(method.Parametrs);

            source
                .Append(accessCode)
                .Append(" ").Append(returnTypeCode)
                .Append(" ").Append(method.Name)
                .Append("(").Append(parametersCode).Append(")")
                .Append(";");

            return source.ToString();
        }

        public string MethodAsCode(TMethod method)
        {
            if (method == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            var attributesCode = AttributesAsCode(method.Attributes);
            var accessCode = AccessModiferAsCode(method.AccessModifier);
            var returnTypeCode = method.ReturnType != null ? DataTypeAsContent(method.ReturnType) : "void";
            var descriptionCode = MethodDescriptionAsCode(method.Description);
            var parametersCode = ParametersAsCode(method.Parametrs);

            source
                .Append(attributesCode)
                .AppendLine()
                .Append(accessCode)
                .Append(" ").Append(descriptionCode)
                .Append(" ").Append(returnTypeCode)
                .Append(" ").Append(method.Name)
                .Append("(").Append(parametersCode).Append(")")
                .AppendLine()
                .Append(Keys().BeginBlock)
                .AppendLine()
                .Append(method.Content.Trim('\n', '\r'))
                .AppendLine()
                .Append(Keys().EndBlock);

            return source.ToString();

        }

        public string NameSpaceAsCode(string namesapce)
        {
            return $"namespace {namesapce}";
        }

        public string ParametersAsCode(IEnumerable<TParameter> parameters)
        {
            if (parameters == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            int i = 0;
            foreach(var parm in parameters)
            {
                if (i > 0) source.Append(",");

                source.Append(DataTypeAsContent(parm.DataType)).Append(" ").Append(parm.Name);

                i++;
            }

            return source.ToString();
        }


        public string BaseParametersAsCode(IEnumerable<TParameter> parameters)
        {
            if (parameters == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            int i = 0;
            foreach (var parm in parameters)
            {
                if (i > 0) source.Append(",");

                source.Append(parm.Name);

                i++;
            }

            return source.ToString();
        }



        public string PropertyAsCode(TProperty property)
        {
            if (property == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            source.Append(AccessModiferAsCode(property.AccessModifier))
                  .Append(" ").Append(DataTypeAsContent(property.DataType))
                  .Append(" ").Append(property.Name)
                  .Append(" ").Append(Keys().BeginBlock)
                  .Append(" ").Append(AccessorAsCode(property.GetMethod))
                  .Append(" ").Append(AccessorAsCode(property.SetMethod))
                  .Append(" ").Append(Keys().EndBlock);
  
 
            return source.ToString();
        }

        public string ReferencesAsCode(IEnumerable<string> references)
        {
            if (references == null)
                return string.Empty;

            StringBuilder sources = new StringBuilder();

            foreach (var item in references)
                sources
                    .AppendLine()
                    .Append("using")
                    .Append(" ")
                    .Append(item)
                    .Append(";");

            return sources.ToString();
        }

        public string VariableAsCode(TVariable varibale)
        {
            if (varibale == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            source
                .Append(AccessModiferAsCode(varibale.AccessModifier))
                .Append(" ")
                .Append(varibale.IsConstant ? Keys().Constant : "")
                .Append(varibale.IsStatic ? Keys().Static : "")
                .Append(" ")
                .Append(DataTypeAsContent(varibale.DataType))
                .Append(" ")
                .Append(varibale.Name);

            if (!string.IsNullOrEmpty(varibale.Value))
                source.Append("=").Append(varibale.Value);

            source.Append(";");

            return source.ToString();
        }

        public string AccessorAsCode(TAccessor accessor)
        {
            if (accessor == null)
                return string.Empty;

            StringBuilder source = new StringBuilder();

            if (accessor != null)
            {
                var key = accessor is TGetAccessor ? "get" : "set";

                source
                    .Append(AccessModiferAsCode(accessor.Modifier))
                    .Append(" ").Append(key);

                if (!String.IsNullOrEmpty(accessor.Content))
                    source
                        .Append(" ").Append(Keys().BeginBlock)
                        .Append(accessor.Content)
                        .Append(" ").Append(Keys().EndBlock);
                else
                    source.Append(";");
                
            }

            return source.ToString();
        }
    }
}
