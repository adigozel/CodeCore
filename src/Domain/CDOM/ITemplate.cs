using System;
using System.Collections.Generic;
using System.Text;
using CDOM;
using MSL;

namespace CDOM
{
    public interface ITemplate
    {
        ISyntaxAdapter SyntaxAdapter { get; }
        TSolution Create( TDomain domain );
    }
}
