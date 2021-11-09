using System;
using SqlKata.Compilers;
using MSL;
using DbScriptGenerator.Infrastructure.Services;


namespace DbScriptGenerator.Oracle.Services
{
    public class OracleInsertScriptGenerator : IInsertScriptGenerator
    {
        
        IDbProvider _dbProvider;
        IInsertScriptGenerator _baseGenerator;
        public OracleInsertScriptGenerator( )
        {
            _dbProvider = new OracleDbProvider();
            _baseGenerator = new SqlKataInsertScriptGenerator(_dbProvider, new OracleCompiler());
        }

        public IDbProvider DbProvider => _dbProvider;

        public string Generate(TDomain domain)
        {
            return _baseGenerator.Generate(domain);
        }
    }
}
