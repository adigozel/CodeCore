using System;

namespace DbScriptGenerator
{
    public interface IDbProvider
    {
        string CreateViewScript(string viewName, string query);
        string QuerySeparator { get; }
        string CodeEnd { get; }
    }
}
