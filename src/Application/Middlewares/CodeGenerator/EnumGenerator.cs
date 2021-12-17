using System;
using CDOM;
using Pipline;

namespace CodeGenerator
{
    public class EnumGenerator
    {
        public static AppItem Create(TEnum enm,ISyntaxAdapter adabter)
        {
            var code = enm.GenerateCode( adabter );
                //adabter.EnumAsCode( enm );

            return new AppFile( ) {
                Content = code,
                Name = enm.Name
            };
        }
    }
}
