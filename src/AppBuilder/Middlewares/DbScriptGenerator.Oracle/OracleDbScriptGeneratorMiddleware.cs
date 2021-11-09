using System;
using MSL;
using CodeBuilder;
using CodeBuilder.Middlewares;
using DbScriptGenerator.Infrastructure;
using DbScriptGenerator.Oracle.Services;


namespace DbScriptGenerator.Oracle
{
    public class OracleDbScriptGeneratorMiddleware : BaseCodeMiddleware, IDbScriptGeneratorMiddleware
    {
        public override MiddlewareResult InternalInvoke(CodeContext context)
        {
            var projectName = context.GetValue(CodeConstants.PROJECT_NAME).ToString();
            var releaseNumber = context.GetValue(CodeConstants.RELEASE_NUMBER).ToString();
            var domain = context.GetValue(CodeConstants.DOMAIN) as TDomain;
            
            var providerType = "oracle";

            try
            {
                var environment = new SaveInPathEnvironment(
                    CodePathStructure.GetReleasePath(projectName, releaseNumber)
                    );

                var viewScriptGenerator = new OracleViewScriptGenerator();
                var isnertScriptGenerator = new OracleInsertScriptGenerator( );

                GeneratorScriptEngine engine =
                    new GeneratorScriptEngine(providerType, environment, viewScriptGenerator, isnertScriptGenerator );

                engine.Generate(domain);

                return new MiddlewareResult(true, "Oracle DbScript Generator Success");

            }
            catch (Exception exc)
            {
                return new MiddlewareResult(false, $"Oracle DbScript Generator {exc.Message}", exc);
            }

        }
    }
}
