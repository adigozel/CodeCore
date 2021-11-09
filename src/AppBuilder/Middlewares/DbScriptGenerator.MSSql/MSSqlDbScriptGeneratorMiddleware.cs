using System;
using CodeBuilder;
using CodeBuilder.Middlewares;
using DbScriptGenerator.Infrastructure;
using MSL;
using DbScriptGenerator.MSSql.Services;

namespace DbScriptGenerator.MSSql
{
    public class MSSqlDbScriptGeneratorMiddleware : BaseCodeMiddleware, IDbScriptGeneratorMiddleware
    {
        public override MiddlewareResult InternalInvoke(CodeContext context)
        {
            var projectName = context.GetValue(CodeConstants.PROJECT_NAME).ToString();
            var releaseNumber = context.GetValue(CodeConstants.RELEASE_NUMBER).ToString();
            var domain = context.GetValue(CodeConstants.DOMAIN) as TDomain;
            
            var providerType = "mssql";

            try
            {
                var environment = new SaveInPathEnvironment(
                    CodePathStructure.GetReleasePath(projectName, releaseNumber)
                    );

                var viewScriptGenerator = new MSSqlViewScriptGenerator();
                var insertScriptGenerator = new MSSqlInsertScriptGenerator( );

                GeneratorScriptEngine engine =
                    new GeneratorScriptEngine(providerType, environment, viewScriptGenerator, insertScriptGenerator );

                engine.Generate(domain);

                return new MiddlewareResult(true, "MSSql DbScript Generator Success");

            }
            catch (Exception exc)
            {
                return new MiddlewareResult(false, $"MSSql DbScript Generator {exc.Message}", exc);
            }

        }
    }
}
