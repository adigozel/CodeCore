using System;
using System.Collections.Generic;

namespace CDOM
{
   
    public interface ISyntaxAdapter
    {
        string ClassAsCode( TClass cls );
        string InterfaceAsCode( TInterface infs );
        string EnumAsCode( TEnum enm );

    }
}
