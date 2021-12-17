using System;
using System.Collections.Generic;

namespace Pipline.Middlewares
{
    public abstract class BaseMiddleware : IMiddleware
    {
        public event EventHandler Invoked;

        public void Invoke(AppContext context)
        {

            var result = InternalInvoke(context);

            Invoked(this, new MiddlewareInvokedArgs(result));
        }

        public abstract MiddlewareResult InternalInvoke(AppContext context);

    }
}
