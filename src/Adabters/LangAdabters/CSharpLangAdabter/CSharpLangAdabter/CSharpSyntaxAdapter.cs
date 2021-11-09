using CDOM;
using System;

namespace CSharpLangAdabter
{
    public class CSharpSyntaxAdapter : ISyntaxAdapter
    {
       
        public string GenerateCode( TVariable varilable )
        {
            return $"{varilable.AccessModifier} {(varilable.IsStatic ? "static":"")} {(varilable.IsConstant ? "const" : "")} {GenerateCode(varilable.DataType)} {varilable.Name}";
        }

        private object GenerateCode( TDataType dataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( TProperty property )
        {
            return $"{property.AccessModifier} {GenerateCode( property.DataType )} {property.Name} {{ get; set; }}";
        }

        public string GenerateCode( TMethod method )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( ShortDataType shortDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( NameClouse nameClouse )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( ReturnClause returnClause )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( TConstructor constructor )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( EqualsClause equalsClause )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( BlockClouse blockClouse )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( EnumDataType enumDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( GuidDataType guidDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( TAbstractMethod abstractMethod )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( IntDataType intDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( TEnum @enum )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( DateTimeDataType dateTimeDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( ClassDataType classDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( TInterface @interface )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( BoolDataType boolDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( LongDataType longDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( BinaryDataType binaryDataType )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( NewClause newClause )
        {
            throw new NotImplementedException( );
        }

        public string GenerateCode( TClass @class )
        {
            throw new NotImplementedException( );
        }

        public string GetHashCode( TParameter parameter )
        {
            throw new NotImplementedException( );
        }

        public string GetHashCode( DecimalDataType decimalDataType )
        {
            throw new NotImplementedException( );
        }
    }
}
