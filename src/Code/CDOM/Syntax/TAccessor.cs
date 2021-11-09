using System;
using System.Collections.Generic;

namespace CDOM
{
    public abstract class TAccessor
    {
        public TAccessor(AccessModifier modifier, string content=null)
        {
            Modifier = modifier;
            Content = content;
        }

        public AccessModifier Modifier { get; set; }

        public string Content { get;  set; }
    }

    public class TGetAccessor : TAccessor
    {
        public TGetAccessor(AccessModifier modifier, string content = null) 
            : base(modifier, content)
        {
        }
    }

    public class TSetAccessor : TAccessor
    {
        public TSetAccessor(AccessModifier modifier, string content = null) 
            : base(modifier, content)
        {
        }
    }
}
