using System;

namespace DbScriptGenerator.Oracle
{
    public class OracleDbProvider : IDbProvider
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
