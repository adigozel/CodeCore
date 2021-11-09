using System;
using System.Collections.Generic;

namespace CDOM
{
   
    public interface ISyntaxAdapter
    {
        string GenerateCode( TVariable varilable );
        string GenerateCode( TProperty property );
        string GetHashCode( TParameter parameter );
        string GenerateCode( TMethod method );
        string GenerateCode( ShortDataType shortDataType );
        string GenerateCode( NameClouse nameClouse );
        string GenerateCode( ReturnClause returnClause );
        string GenerateCode( TConstructor constructor );
        string GenerateCode( EqualsClause equalsClause );
        string GenerateCode( BlockClouse blockClouse );
        string GenerateCode( EnumDataType enumDataType );
        string GenerateCode( GuidDataType guidDataType );
        string GenerateCode( TAbstractMethod abstractMethod );
        string GenerateCode( IntDataType intDataType );
        string GenerateCode( TEnum @enum );
        string GenerateCode( DateTimeDataType dateTimeDataType );
        string GenerateCode( ClassDataType classDataType );
        string GetHashCode( DecimalDataType decimalDataType );
        string GenerateCode( TInterface @interface );
        string GenerateCode( BoolDataType boolDataType );
        string GenerateCode( LongDataType longDataType );
        string GenerateCode( BinaryDataType binaryDataType );
        string GenerateCode( NewClause newClause );
        string GenerateCode( TClass @class );
        //string ClassAsCode( TClass cls );
        //string InterfaceAsCode( TInterface infs );
        //string EnumAsCode( TEnum enm );

    }
}
