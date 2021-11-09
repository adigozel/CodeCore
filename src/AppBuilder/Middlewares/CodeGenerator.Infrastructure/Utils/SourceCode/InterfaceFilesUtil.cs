using System;
using System.Collections.Generic;
using CodeGenerator.Core;
using CodeGenerator.Builders;
using CodeGenerator.Infrastructure.Utils.Common;
using CodeGenerator.Langugage;

namespace CodeGenerator.Infrastructure.Utils.SourceCode
{
    public static class InterfaceFilesUtil
    {
        public static void CreateFiles(TInterface _interface,string path,ILungugageCode adabter)
        {
            string interfacePath = path + $"\\{_interface.Name}.cs";

            InterfaceBuilder builder = new InterfaceBuilder(adabter);

            string src = builder.Build(_interface);

            FileUtil.CreateFile(interfacePath, src);
        }
    }
}
