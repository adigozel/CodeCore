using System;

namespace DbScriptGenerator.PostgreSql
{
    public class PostgreSqlDbProvider : IDbProvider
    {
        public string QuerySeparator => "";

        public string CodeEnd => ";";

        public string CreateViewScript(string viewName, string query)
        {
            var schemaName = "#schemaName#";

            var command =
$"CREATE OR REPLACE VIEW  \"{schemaName}\".\"{viewName}\" AS"
+ Environment.NewLine
+ query+";";

            return command;
        }
    }
}
