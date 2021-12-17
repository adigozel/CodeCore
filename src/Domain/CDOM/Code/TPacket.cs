using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TPacket: TContainer
    {
        public TPacket(string name):base(name)
        {
            this.Name = name;
        }    
    }
}
