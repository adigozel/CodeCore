using System;
using System.Collections.Generic;

namespace CDOM
{
    public abstract class TAccessor
    {
        public TAccessor(AccessModifier modifier, Code content=null)
        {
            Modifier = modifier;
            Content = content;
        }

        public AccessModifier Modifier { get; set; }

        public Code Content { get;  set; }
    }

    public class TGetAccessor : TAccessor
    {
        public TGetAccessor(AccessModifier modifier, Code content = null) 
            : base(modifier, content)
        {
        }
    }

    public class TSetAccessor : TAccessor
    {
        public TSetAccessor(AccessModifier modifier, Code content = null) 
            : base(modifier, content)
        {
        }
    }
}
