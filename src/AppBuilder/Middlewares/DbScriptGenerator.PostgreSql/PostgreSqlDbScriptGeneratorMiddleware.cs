using System;
using MSL;
using CodeBuilder;
using CodeBuilder.Middlewares;
using DbScriptGenerator.Infrastructure;
using DbScriptGenerator.PostgreSql.Services;


namespace DbScriptGenerator.PostgreSql
{
    public class PostgreSqlDbScriptGeneratorMiddleware : BaseCodeMiddleware, IDbScriptGeneratorMiddleware
    {
        public override MiddlewareResult InternalInvoke(CodeContext context)
        {
            var projectName = context.GetValue(CodeConstants.PROJECT_NAME).ToString();
            var releaseNumber = context.GetValue(CodeConstants.RELEASE_NUMBER).ToString();
            var domain = context.GetValue(CodeConstants.DOMAIN) as TDomain;
            
            var providerType = "postgresql";

            try
            {
                var environment = new SaveInPathEnvironment(
                    CodePathStructure.GetReleasePath(projectName, releaseNumber)
                    );

                var viewScriptGenerator = new PostgreSqlViewScriptGenerator();
                var isnertScriptGenerator = new PostgreSqlInsertScriptGenerator( );

                GeneratorScriptEngine engine =
                    new GeneratorScriptEngine(providerType, environment, viewScriptGenerator, isnertScriptGenerator );

                engine.Generate(domain);

                return new MiddlewareResult(true, "PostgreSql DbScript Generator Success");

            }
            catch (Exception exc)
            {
                return new MiddlewareResult(false, $"PostgreSql DbScript Generator {exc.Message}", exc);
            }

        }
    }
}
