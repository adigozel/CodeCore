using System;

namespace Pipline
{
    public interface IMiddleware
    {
        event EventHandler Invoked;
        void Invoke(AppContext context);
    }

}
