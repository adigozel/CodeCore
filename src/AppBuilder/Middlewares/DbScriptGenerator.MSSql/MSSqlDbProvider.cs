using System;

namespace DbScriptGenerator.MSSql
{
    public class MSSqlDbProvider : IDbProvider
    {
        public string QuerySeparator => "GO";

        public string CodeEnd => ";";

        public string CreateViewScript(string viewName, string query)
        {
            var schemaName = "#schemaName#";

            var command =
$@"IF EXISTS(SELECT * FROM sys.views WHERE schema_id = (select schema_id from sys.schemas  where name = '{schemaName}') and name = '{viewName}')
DROP VIEW [{schemaName}].[{viewName}];
GO 
CREATE VIEW [{schemaName}].[{viewName}]
AS
{query};";

            return command;
        }
    }
}
