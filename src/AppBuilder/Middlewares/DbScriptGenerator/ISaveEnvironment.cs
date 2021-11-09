using System;

namespace DbScriptGenerator
{
    public interface ISaveEnvironment
    {
        void Save(string providerType,string name,string content);
    }
}
