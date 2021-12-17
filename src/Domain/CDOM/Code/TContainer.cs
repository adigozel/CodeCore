using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDOM
{
    public abstract class TContainer
    {
        public TContainer(string name)
        {
            this.Name = name;
            Packets = new List<TPacket>();
            Classes = new List<TClass>();
            Interfaces = new List<TInterface>();
            Enums = new List<TEnum>();
        }

        public string Name { get; set; }
        public ICollection<TPacket> Packets { get; set; }
        public ICollection<TClass> Classes { get; set; }
        public ICollection<TInterface> Interfaces { get; set; }
        public ICollection<TEnum> Enums { get; set; }
        public TPacket GetPacket(string name)
        {
            foreach (var p in this.Packets)
            {
                if (p.Name == name)
                    return p;
            }

            return null;
        }

    }
}
