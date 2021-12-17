using CDOM;
using Pipline;

namespace CodeGenerator
{
    public static class ClassGenerator
    {

        public static AppItem Create(TClass cls, ISyntaxAdapter adabter)
        {
            var code = cls.GenerateCode( adabter );
                //adabter.ClassAsCode( cls );

            return new AppFile( ) {
                Content = code,
                Name = cls.Name
            };

        }
    }
}
