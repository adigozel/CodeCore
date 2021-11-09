using System;
using System.Collections.Generic;
using CodeGenerator.Langugage;
using CodeGenerator.Core;
using CodeGenerator.Infrastructure.Utils.Common;

namespace CodeGenerator.Infrastructure.Utils.SourceCode
{
    public static  class ProjectFilesUtil
    {
        public static void CreateFiles(TProject prj,string srcPath, ILungugageCode adabter)
        {
            string prjPath = srcPath + $"\\{prj.Name}";

            FileUtil.CreateDirectory(prjPath);

            foreach(var pkt in prj.Packets)
            {
                PacketFilesUtil.CreateFiles(pkt, prjPath, adabter);
            }

            foreach(var cls in prj.Classes)
            {
                if (prj.Name == "Filters")
                {
                    int i = 0;
                }
                ClassFilesUtil.CreateFiles(cls, prjPath, adabter);
            }

            foreach(var intr in prj.Interfaces)
            {
                InterfaceFilesUtil.CreateFiles(intr, prjPath, adabter);
            }

            foreach (var enm in prj.Enums)
            {
                EnumFilesUtil.CreateFiles(enm, prjPath, adabter);
            }
        }
    }
}
