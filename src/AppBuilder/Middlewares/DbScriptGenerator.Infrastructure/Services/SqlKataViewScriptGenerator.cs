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
    public class SqlKataViewScriptGenerator : IViewScriptGenerator
    {
        IDbProvider _dbprovider;
        Compiler _compiler;
        public SqlKataViewScriptGenerator(IDbProvider dbprovider,Compiler compiler)
        {
            _dbprovider = dbprovider;
            _compiler = compiler;
        }

        public IDbProvider DbProvider => _dbprovider;

        public string Generate(TDomain domain)
        {
            StringBuilder builder = new StringBuilder();
            
            foreach (var entity in domain.NoStaticEntities)
            {
                foreach(var entityQuery in entity.Queries.Where( x => !x.IsRaw )) {
                    
                    
                    var query = entityQuery.ToQueryElement( entity, domain ).ToQuery( );
                    
                    if (entity.IsWorkFlowProduct && entityQuery.IsWorkFlowView) {
                        query = query.Join( "#schemaName#.VW_WF_AssignedWorkAllActive as Assignes", $"{entity.Name}.Id", "Assignes.ProductId" );
                    }
                    //if(entity.IsWorkFlowProduct && entityQuery.IsWorkFlowView) {
                    //    query = new Query( "#schemaName#.VW_WF_AssignedWorkAllActive as Assignes" )
                    //        .Join( nativeQuery, x => x.On( "Assignes.ProductId", $"{entity.Name}.Id" ).Where( "Assignes.ProductTypeName",entity.Name ) );
                    //}
                    //else {
                    //    query = nativeQuery;
                    //}
                     

                    var result = _compiler.Compile(query);

                    string query_sql = result.Sql;

                    string view_name = string.IsNullOrEmpty( entityQuery.RepositoryName ) ? $"{entity.Name}{entityQuery.Name}" : entityQuery.RepositoryName;

                    string view_sql = DbProvider.CreateViewScript(view_name, query_sql);

                    builder.AppendLine(view_sql)
                        .AppendLine(DbProvider.QuerySeparator);
                }
            }

            return builder.ToString();
        }
    }
}
