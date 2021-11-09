using System;
using System.Linq;
using System.Text;
using CDOM;
using CodeGenerator.Infrastructure.Utils.Common;
using CodeGenerator.Infrastructure.Utils.SourceCode;
using Pipline;
using Pipline.Middlewares;

namespace CodeGenerator.CSharp
{
    public class CSharpCompileMiddleware : BaseCodeMiddleware, ICompileMiddleware
    {
        public override MiddlewareResult InternalInvoke(CodeContext context)
        {

            var projectName = context.GetValue(CodeConstants.PROJECT_NAME).ToString();
            var releaseNumber = context.GetValue(CodeConstants.RELEASE_NUMBER).ToString();


            var sln = context.GetValue(CodeConstants.SOLUTION) as TSolution;
            var slnPath = CodePathStructure.GetProjectPath(projectName);
            var releasesPath = CodePathStructure.GetReleasesBasePath(projectName);
            var relasePath = CodePathStructure.GetReleasePath(projectName, releaseNumber);
            var releaseSrcPath = CodePathStructure.GetReleaseSourcePath(projectName, releaseNumber);
            var relaseLibsPath = CodePathStructure.GetReleaseLibsPath(projectName, releaseNumber);
            var referencesPath = CodePathStructure.GetDotNetCoreReferencesPath();

            try
            {
                Compile(sln, slnPath, releasesPath, relasePath, releaseSrcPath, relaseLibsPath, referencesPath);

                return new MiddlewareResult(true, "Compile Success");
            }
            catch(Exception exc)
            {
                return new MiddlewareResult(false, $"Compile {exc.Message}", exc);
            }
        }

        private void Compile(TSolution sln,
            string solutionPath,
            string releasesPath,
            string relasePath,
            string releaseSrcPath,
            string releaseLibsPath,
            string referencesPath)
        {
            var _adabter = new CSharpLangugageCode( );

            #region file actions
            Action createSlnFolder = () =>
            {
                FileUtil.CreateDirectory(solutionPath);
            };

            Action createReleaseFolders = () =>
            {
                FileUtil.CreateDirectory(releasesPath);
                FileUtil.CreateDirectory(releaseSrcPath);
                FileUtil.CreateDirectory(releaseLibsPath);
            };

            Action createSourceFiles = () =>
            {
                SolutionFilesUtil.CreateFiles(sln, releaseSrcPath, _adabter);
            };

            Func<string> copyReferences = () =>
            {
                StringBuilder builder = new StringBuilder()
                .AppendLine()
                .AppendLine("<ItemGroup>")
                .AppendLine(" <Reference Include=\"SetClapp.Commons\">")
                .AppendLine("   <HintPath>.\\libs\\SetClapp.Commons.dll</HintPath>")
                .AppendLine(" </Reference>");

                FileUtil.CopyFiles(referencesPath + "\\libs", releaseLibsPath, true);

                var references = sln.Projects.SelectMany(x => x.References);

                if (!sln.Name.ToLower().Equals("IdentityAccess".ToLower()) && references.Where(r => r.StartsWith("IdentityAccess")).Count() > 0)
                {
                    FileUtil.CopyFiles(referencesPath + "\\modules\\IdentityAccess", releaseLibsPath, true);

                    builder
                    .AppendLine(" <Reference Include=\"IdentityAccess\">")
                    .AppendLine("  <HintPath>.\\libs\\IdentityAccess.dll</HintPath>")
                    .AppendLine(" </Reference>")
                    .AppendLine()
                    .AppendLine(" <Reference Include=\"IdentityAccess.Providers\">")
                    .AppendLine("  <HintPath>.\\libs\\IdentityAccess.Providers.dll</HintPath>")
                    .AppendLine(" </Reference>");

                }

                if(!sln.Name.ToLower( ).Equals( "WorkFlow".ToLower( ) ) && references.Where( r => r.StartsWith( "WorkFlow" ) ).Count( ) > 0) {
                    FileUtil.CopyFiles( referencesPath + "\\modules\\WorkFlow", releaseLibsPath, true );

                    builder
                    .AppendLine( " <Reference Include=\"WorkFlow\">" )
                    .AppendLine( "  <HintPath>.\\libs\\WorkFlow.dll</HintPath>" )
                    .AppendLine( " </Reference>" )
                    .AppendLine( )
                    .AppendLine( " <Reference Include=\"WorkFlow.Actions\">" )
                    .AppendLine( "  <HintPath>.\\libs\\WorkFlow.Actions.dll</HintPath>" )
                    .AppendLine( " </Reference>" )
                    .AppendLine( )
                    .AppendLine( " <Reference Include=\"DynamicCode\">" )
                    .AppendLine( "  <HintPath>.\\libs\\DynamicCode.dll</HintPath>" )
                    .AppendLine( " </Reference>" );
                }

                builder.AppendLine("</ItemGroup>");
                return builder.ToString();

            };

            Action<string> copyProjectFile = (lC) =>
            {
                var projectFile = FileUtil.GetFileContent(referencesPath + "\\project.csproj");

                projectFile = projectFile.Replace("#libs#", lC);

                FileUtil.CreateFile($"{relasePath}\\{sln.Name}.csproj", projectFile);

                //FileUtil.CopyFile("project.csproj", referencesPath, $"{sln.Name}.csproj", relasePath, true);
            };

            Action build = () =>
            {
                FileUtil.CopyFile("build.bat", referencesPath, relasePath, true);

                FileUtil.SetCurrentDirectory(relasePath);

                ProcessUtil.Run(relasePath + "\\build.bat");
            };

            #endregion

            createSlnFolder();

            createReleaseFolders();

            createSourceFiles();

            var libsContent = copyReferences();

            copyProjectFile(libsContent);

            //build();

        }

        
    }
}
