using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TSolution
    {

        public TSolution(string name)
        {
            this.Name = name;
            this.Projects = new List<TProject>();
        }

        public string Name { get; set; }
        public ICollection<TProject> Projects { get; set; }
        public TProject GetProject(string name)
        {
            foreach (var p in this.Projects)
            {
                if (p.Name == name)
                    return p;
            }

            return null;
        }
    }
}
