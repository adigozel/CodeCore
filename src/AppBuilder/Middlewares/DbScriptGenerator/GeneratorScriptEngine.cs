using System;
using MSL;

namespace DbScriptGenerator
{
    public class GeneratorScriptEngine
    {
        public GeneratorScriptEngine(
            string providerType,
            ISaveEnvironment environment,
            IViewScriptGenerator viewScriptGenerator,
            IInsertScriptGenerator insertScriptGenerator
            )
        {
            ProviderType = providerType;
            Environment = environment;
            ViewScriptGenerator = viewScriptGenerator;
            InsertScriptGenerator = insertScriptGenerator;
        }

        public IViewScriptGenerator ViewScriptGenerator { get; private set; }
        public IInsertScriptGenerator InsertScriptGenerator { get; private set; }
        public ISaveEnvironment Environment { get; private set; }
        public string ProviderType { get; private set; }

        public void Generate(TDomain domain)
        {
            var views = ViewScriptGenerator.Generate(domain);
            Environment.Save( ProviderType.ToLower( ),"views", views );

            var inserts = InsertScriptGenerator.Generate( domain );
            Environment.Save( ProviderType.ToLower( ),"inserts", inserts );
        }
    }
}
