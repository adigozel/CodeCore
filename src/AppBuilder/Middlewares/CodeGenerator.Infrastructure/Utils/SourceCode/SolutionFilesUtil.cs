using System;
using System.Collections.Generic;
using CodeGenerator.Langugage;
using CodeGenerator.Core;
using CodeGenerator.Infrastructure.Utils.Common;

namespace CodeGenerator.Infrastructure.Utils.SourceCode
{
    public static class SolutionFilesUtil
    {
       
        public static void CreateFiles(TSolution sln,string srcPath,ILungugageCode adabter)
        {
            FileUtil.DeleteAllFiles(srcPath);

            foreach (var prj in sln.Projects)
            {
                ProjectFilesUtil.CreateFiles(prj, srcPath, adabter);
            }
        }

    }
}
