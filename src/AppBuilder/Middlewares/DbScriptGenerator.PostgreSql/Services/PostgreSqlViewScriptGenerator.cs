using System;
using SqlKata.Compilers;
using MSL;
using DbScriptGenerator.Infrastructure.Services;


namespace DbScriptGenerator.PostgreSql.Services
{
    public class PostgreSqlViewScriptGenerator : IViewScriptGenerator
    {
        
        IDbProvider _dbProvider;
        IViewScriptGenerator _baseGenerator;
        public PostgreSqlViewScriptGenerator()
        {
            _dbProvider = new PostgreSqlDbProvider();
            _baseGenerator = new SqlKataViewScriptGenerator(_dbProvider, new PostgresCompiler());
        }

        public IDbProvider DbProvider => _dbProvider;

        public string Generate(TDomain domain)
        {
            return _baseGenerator.Generate(domain);
        }
    }
}
