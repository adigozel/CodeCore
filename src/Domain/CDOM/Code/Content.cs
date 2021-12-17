using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public  class Content:Code
    {
        public Content()
        {
            Codes = new List<Code>();
        }

        public IList<Code> Codes { get; set; }

        public override string GenerateCode( ISyntaxAdapter adabter )
        {
            if (Codes == null || Codes.Count == 0)
                return "";

            var codeBuilder = new StringBuilder();
            
            foreach (var code in Codes)
                codeBuilder.AppendLine(code.GenerateCode(adabter));

            return codeBuilder.ToString();

        }
    }
}
