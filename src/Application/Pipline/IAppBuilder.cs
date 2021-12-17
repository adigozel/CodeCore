using System;

namespace Pipline
{
    public interface IBuild
    {
        AppFolder Build(AppContext context);
    }

    public interface IAppBuilder:IBuild
    {
        AppContext Context { get; }
        IAppBuilder Use(IMiddleware middleware);
    }

}
