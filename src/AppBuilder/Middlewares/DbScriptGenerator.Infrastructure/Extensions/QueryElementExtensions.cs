using MSL.QueryBuilder;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScriptGenerator.Infrastructure.Extensions
{
    public static class QueryElementExtensions
    {
        public static Query ToQuery(this QueryElement queryElement, string schemaName = "#schemaName#")
        {
            var aliansName = queryElement.Join.ReferenceEntity.Name;

            var query = new Query( $"{schemaName}.{queryElement.Join.ReferenceEntity.RepositoryName} as {aliansName}" )
                .Select( queryElement.Columns);
           
            foreach (var childElement in queryElement.Join.Children)
                if (!childElement.ReferenceField.DataType.IsNullable)
                    IncludeJoins(childElement, query, aliansName,false, schemaName );

            foreach (var childElement in queryElement.Join.Children)
                if (childElement.ReferenceField.DataType.IsNullable)
                    IncludeJoins(childElement, query, aliansName, false, schemaName );

            return query;
        }

        private static void IncludeJoins(this JoinElement joinElement
            ,Query query,string aliansName,bool isParentNullable, string schemaName )
        {
            var newAliansName = aliansName + joinElement.FieldName;

            var join = $"{schemaName}.{joinElement.ReferenceEntity.RepositoryName} as {newAliansName}";

            var first = $"{aliansName}.{joinElement.FieldName}Id";

            var second = $"{newAliansName}.Id";

            var isNullable = joinElement.ReferenceField.DataType.IsNullable;
           
            if (!isParentNullable && !isNullable)
                query.Join(join, first, second);
            else
            {
                query.LeftJoin(join, first, second);
                isNullable = true;
            }

            foreach (var childElement in joinElement.Children)
            {
                IncludeJoins(childElement, query, newAliansName, isNullable,schemaName);
            }
        }
    }
}
