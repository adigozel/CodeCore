using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbScriptGenerator.Infrastructure.Extensions;
using MSL;
using MSL.QueryBuilder.Extensions;
using SqlKata;
using SqlKata.Compilers;

namespace DbScriptGenerator.Infrastructure.Services
{
    public class SqlKataInsertScriptGenerator : IInsertScriptGenerator
    {
        IDbProvider _dbprovider;
        Compiler _compiler;
        public SqlKataInsertScriptGenerator( IDbProvider dbprovider, Compiler compiler ) {
            _dbprovider = dbprovider;
            _compiler = compiler;
        }

        public IDbProvider DbProvider => _dbprovider;

        public string Generate( TDomain domain ) {

            Func<TEntity, TEntityCompetency, object> map = (e,c ) => {
                return new {
                    Id = Guid.NewGuid( ),
                    Code = c.Name,
                    Description = c.Name,
                    ContextName = e.Name,
                    RepositoryName = !string.IsNullOrEmpty( c.RepositoryName )? c.RepositoryName : null,
                    DescriptionField = c.DescriptionField,
                    Version = 1
                };
            };

           
            StringBuilder builder = new StringBuilder( );

            foreach(var entity in domain.NoStaticEntities) {

                foreach(var competency in entity.Compotencies) {

                    var query = new Query( "Competency" )
                        .AsInsert( map( entity, competency ) );

                    var result = _compiler.Compile( query );

                    string query_sql = result.ToString( );

                    builder.Append( query_sql )
                        .AppendLine( DbProvider.CodeEnd );
                }

            }

            return builder.ToString( );
        }
    }
}
