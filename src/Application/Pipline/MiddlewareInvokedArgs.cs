using System;

namespace Pipline
{
    public class MiddlewareInvokedArgs : EventArgs
    {
        public MiddlewareInvokedArgs(MiddlewareResult result)
        {
            this.Result = result;
        }
        public MiddlewareResult Result { get; set; }
    }
}
