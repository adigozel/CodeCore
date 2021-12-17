using System;
using CDOM;
using MSL;
using Pipline;
using Pipline.Middlewares;

namespace CodeGenerator
{
    public class CodeGeneratorMiddleware : BaseMiddleware, ICodeGeneratorMiddleware
    {
        public override MiddlewareResult InternalInvoke( Pipline.AppContext context )
        {
            try {
                var domain = (TDomain)context.GetValue( AppConstants.DOMAIN );
                var template = (ITemplate)context.GetValue( AppConstants.TEMPLATE );
                var sln = template.Create( domain );
                var code = SolutionGenerator.Create( sln, template.SyntaxAdapter );
                return MiddlewareResult.Succeed( code );
            }
            catch(Exception exc) {
                return MiddlewareResult.Failure( exc );
            }
        }
    }
}
