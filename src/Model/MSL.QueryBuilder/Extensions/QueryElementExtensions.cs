using SqlKata;

namespace MSL.QueryBuilder.Extensions
{
    public static class QueryElementExtensions
    {
        public static Query ToQuery(this QueryElement queryElement)
        {
            var aliansName = queryElement.Join.ReferenceEntity.Name;

            var query = new Query($"{queryElement.Join.ReferenceEntity.RepositoryName} as {aliansName}");

            foreach (var childElement in queryElement.Join.Children)
                if (!childElement.ReferenceField.DataType.IsNullable)
                    IncludeJoins(childElement, query, aliansName,false);

            foreach (var childElement in queryElement.Join.Children)
                if (childElement.ReferenceField.DataType.IsNullable)
                    IncludeJoins(childElement, query, aliansName, false);

            return query;
        }

        private static void IncludeJoins(this JoinElement joinElement
            ,Query query,string aliansName,bool isParentNullable)
        {
            var newAliansName = aliansName + joinElement.FieldName;

            var join = $"{joinElement.ReferenceEntity.RepositoryName} as {newAliansName}";

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
                IncludeJoins(childElement, query, newAliansName, isNullable);
            }
        }
    }
}
