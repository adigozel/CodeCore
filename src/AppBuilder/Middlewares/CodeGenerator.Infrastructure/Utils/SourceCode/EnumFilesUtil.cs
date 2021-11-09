using System;
using CodeGenerator.Builders;
using CodeGenerator.Core;
using CodeGenerator.Infrastructure.Utils.Common;
using CodeGenerator.Langugage;

namespace CodeGenerator.Infrastructure.Utils.SourceCode
{
    public class EnumFilesUtil
    {
        public static void CreateFiles(TEnum _enum, string path,ILungugageCode adabter)
        {
            string enumPath = path + $"\\{_enum.Name}.cs";

            EnumBuilder builder = new EnumBuilder(adabter);

            string src = builder.Build(_enum);

            FileUtil.CreateFile(enumPath, src);
        }
    }
}
