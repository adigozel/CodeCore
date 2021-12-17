using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TProject : TContainer
    {

        public TProject(string name) : base(name)
        {
            this.Name = name;
            References = new List<String>();
        }

        public ICollection<String> References { get; set; }


    }
}
