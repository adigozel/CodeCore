using CDOM;
using Pipline;
using System;
using System.Linq;

namespace CodeGenerator
{
    public static class SolutionGenerator
    {
        public static AppItem Create(TSolution sln,ISyntaxAdapter adabter)
        {
            var item = new AppFolder( );

            item.Children.AddRange(
                    sln.Projects.Select(
                        x => ProjectGenerator.Create( x, adabter )
                       )
                );

            return item;
        }

    }
}
