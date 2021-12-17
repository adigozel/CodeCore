using System;
using CDOM;
using Pipline;

namespace CodeGenerator
{
    public static class InterfaceGenerator
    {
        public static AppItem Create(TInterface infs,ISyntaxAdapter adabter)
        {
            string code = infs.GenerateCode( adabter );
                //adabter.InterfaceAsCode( infs );

            return new AppFile( ) {
                Content = code,
                Name = infs.Name
            };

        }
    }
}
