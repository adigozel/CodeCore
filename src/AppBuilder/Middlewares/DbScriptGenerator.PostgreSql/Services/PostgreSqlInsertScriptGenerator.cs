using System;
using SqlKata.Compilers;
using MSL;
using DbScriptGenerator.Infrastructure.Services;


namespace DbScriptGenerator.PostgreSql.Services
{
    public class PostgreSqlInsertScriptGenerator : IInsertScriptGenerator
    {
        
        IDbProvider _dbProvider;
        IInsertScriptGenerator _baseGenerator;
        public PostgreSqlInsertScriptGenerator( )
        {
            _dbProvider = new PostgreSqlDbProvider();
            _baseGenerator = new SqlKataInsertScriptGenerator(_dbProvider, new PostgresCompiler());
        }

        public IDbProvider DbProvider => _dbProvider;

        public string Generate(TDomain domain)
        {
            return _baseGenerator.Generate(domain);
        }
    }
}
