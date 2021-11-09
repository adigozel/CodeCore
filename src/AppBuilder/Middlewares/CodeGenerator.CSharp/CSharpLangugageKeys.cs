using System;
using System.Collections.Generic;
using CodeGenerator.Langugage;

namespace CodeGenerator.CSharp
{
    public class CSharpLangugageKeys : ILangugageKeys
    {
        public string Inherited => ":";

        public string Class => "class";

        public string Interface => "interface";

        public string BeginBlock => "{";

        public string EndBlock => "}";

        public string Serializable => "[Serializable]";

        public string Enum => "enum";

        public string Abstract => "abstract";

        public string Sealed => "sealed";

        public string Static => "static";

        public string Virtual => "virtual";

        public string Override => "override";

        public string Partial => "partial";

        public string Constant => "const";
    }
}
