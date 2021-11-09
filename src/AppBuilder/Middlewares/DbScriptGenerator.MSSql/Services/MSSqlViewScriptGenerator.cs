using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbScriptGenerator.Infrastructure;
using DbScriptGenerator.Infrastructure.Services;
using MSL;
using SqlKata.Compilers;

namespace DbScriptGenerator.MSSql.Services
{
    public class MSSqlViewScriptGenerator : IViewScriptGenerator
    {
        
        IDbProvider _dbProvider;
        IViewScriptGenerator _baseGenerator;
        public MSSqlViewScriptGenerator()
        {
            _dbProvider = new MSSqlDbProvider();
            _baseGenerator = new SqlKataViewScriptGenerator(_dbProvider, new SqlServerCompiler());
        }

        public IDbProvider DbProvider => _dbProvider;

        public string Generate(TDomain domain)
        {
            return _baseGenerator.Generate(domain);
        }
    }
}
