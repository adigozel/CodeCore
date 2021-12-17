using System;
using System.Linq;

namespace MSL.QueryBuilder.Extensions
{
    public static class EntityQueryExtensions
    {
        public static QueryElement ToQueryElement(this TQuery query,TEntity entity,TDomain domain)
        {
            var rootElement = new JoinElement(null,null,entity);

            var columns = query.Fields.Select( x =>
                $"{x.Formula.Substring( 0, x.Formula.LastIndexOf( "." ) ).Replace( ".", "" )}.{x.Formula.SubStringFromLastChar( '.' )} as {x.Name}"
            ).ToList( );

            if (domain.IsCollectionEntity(entity))
                columns.Add( $"{entity.Name}.CollectionId as CollectionId" );

            var fields = query.Fields.Where( x => x.Formula.StartsWith( $"{entity.Name}.") );
            foreach (var field in fields)
            {
                var lastEntity = entity;

                var element = rootElement;

                var formula = field.Formula
                    .Remove(0, entity.Name.Length + 1)
                    .SubStringToLastChar('.');

                if (string.IsNullOrEmpty(formula))
                    continue;

                var fieldNames = formula
                    .Split('.');
                
                for (int i = 0; i < fieldNames.Length; i++)
                {
      
                    var entityField = lastEntity.Field(fieldNames[i]);

                    lastEntity = domain.Entity(
                            entityField.DataType.Parameters["reference_entity"].ToString()
                        );

                    var existsElement = element.FindChildElement(fieldNames[i]);

                    if (existsElement != null)
                        element = existsElement;
                    else
                        element = element.AddChild(fieldNames[i],entityField, lastEntity);
                }
            }

            return new QueryElement( columns.ToArray(), rootElement);
        }

        //private static IEnumerable<String> GetColumns( TQuery query ) {
            
        //    var fields = new List<TQueryField>( query.Fields );

        //    foreach(var field in fields.Where(x=>!x.IsCustom)) {
                
        //        string forumala = field.Formula;
                
        //        string fieldName = forumala.SubStringFromLastChar( '.' );
                
        //        if(string.IsNullOrEmpty( fieldName ))
        //             continue;

        //        var structure = forumala.Substring( 0, forumala.LastIndexOf( "." ) ).Replace( ".", "" );

        //        var column = $"{structure}.{fieldName}";

        //        yield return $"{column} as {field.Name}";
        //    }
        //}

        
    }
}
