using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM
{
    public class TCodeFile
    {
        public ICollection<string> References { get; set; }
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }
    }
}
