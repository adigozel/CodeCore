using System;
using System.Collections.Generic;
using System.Text;

namespace Pipline.Exceptions
{
    public class MiddlewareInnerException:Exception
    {
        public MiddlewareInnerException( string message):base(message)
        {

        }

    }
}
