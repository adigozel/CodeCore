using System;
using System.Collections.Generic;
using MSL;

namespace DbScriptGenerator
{
    public interface IInsertScriptGenerator
    {
        IDbProvider DbProvider { get; }
        string Generate( TDomain domain );
    }
}
