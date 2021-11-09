using System;
using System.Collections.Generic;
using CodeGenerator.Core;
using CodeGenerator.Builders;
using CodeGenerator.Infrastructure.Utils.Common;
using CodeGenerator.Langugage;

namespace CodeGenerator.Infrastructure.Utils.SourceCode
{
    public static class ClassFilesUtil
    {

        public static void CreateFiles(TClass _class,string path, ILungugageCode adabter)
        {
            string classPath = path + $"\\{_class.FileName}.cs";

            //var adabter = new CShaperSyntaxAdapter();

            ClassBuilder builder = new ClassBuilder(adabter);

            string src = builder.Build(_class);

           //src = src.Format( );

            FileUtil.CreateFile(classPath, src);
        }
    }
}
