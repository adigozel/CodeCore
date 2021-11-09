using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSL;

namespace DbScriptGenerator
{
    public interface IViewScriptGenerator
    {
        IDbProvider DbProvider { get; }
        string Generate(TDomain domain);
    }
}
