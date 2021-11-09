using System;
using SqlKata.Compilers;
using MSL;
using DbScriptGenerator.Infrastructure.Services;

namespace DbScriptGenerator.MSSql.Services
{
    public class MSSqlInsertScriptGenerator : IInsertScriptGenerator
    {
        IDbProvider _dbProvider;
        IInsertScriptGenerator _baseGenerator;
        public MSSqlInsertScriptGenerator( ) {
            _dbProvider = new MSSqlDbProvider( );
            _baseGenerator = new SqlKataInsertScriptGenerator( _dbProvider, new SqlServerCompiler( ) );
        }

        public IDbProvider DbProvider => _dbProvider;

        public string Generate( TDomain domain ) {
            return _baseGenerator.Generate( domain );
        }
    }
}
