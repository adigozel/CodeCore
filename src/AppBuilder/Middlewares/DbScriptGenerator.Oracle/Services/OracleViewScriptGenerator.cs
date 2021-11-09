using System;
using SqlKata.Compilers;
using MSL;
using DbScriptGenerator.Infrastructure.Services;

namespace DbScriptGenerator.Oracle.Services
{
    public class OracleViewScriptGenerator : IViewScriptGenerator
    {
        
        IDbProvider _dbProvider;
        IViewScriptGenerator _baseGenerator;
        public OracleViewScriptGenerator()
        {
            _dbProvider = new OracleDbProvider();
            _baseGenerator = new SqlKataViewScriptGenerator(_dbProvider, new OracleCompiler());
        }

        public IDbProvider DbProvider => _dbProvider;

        public string Generate(TDomain domain)
        {
            return _baseGenerator.Generate(domain);
        }
    }
}
