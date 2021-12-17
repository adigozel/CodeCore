using System;
using System.Collections.Generic;
using System.Linq;
using Pipline.Exceptions;

namespace Pipline
{
    /*
     Builder her hansi Servici cagirmalidir yeqin bu service bir basha controllerde ola biler
     amma her hansi servicde ola biler her hansi servici olmagi daha meqsede uygundur
     buda 
     Biz builder-i cagiranda Contexti doldurub cagira bilerik
     Burda contexte biz ilkin olaraq domain-i veririk bir nov sorgudur
     requestdir ve sonra Contexte Template-i servici kimi birleshdirik
     daha sonra Contexti MiddleWare-e veririk CodeGenerator Domain-i ve Template-i
     goturur ve Sln-nu alir CodeGenerator sadece struktur yigir
     ve SyntaxAdapter-i cagirir ve o da kodlari duzeldir
     (amma burda bir problem var eslinde CodeGenerator umumi ola bilmez belkede)
    */
    public class AppBuilder : IAppBuilder
    {
        private IList<IMiddleware> _middlewares;

        public AppBuilder()
        {
            _middlewares = new List<IMiddleware>();
        }

        public AppContext Context { get; private set; }
  
        public IAppBuilder Use(IMiddleware middleware)
        {
            _middlewares.Add(middleware);
            return this;
        }

        public AppFolder Build(AppContext context)
        {
            Context = context;

            AppFolder appFolder = new AppFolder( );

            int i = 0;

            bool invokedResult = true;

            while(i < _middlewares.Count() && invokedResult)
            {
                var middleware = _middlewares[i];

                middleware.Invoked += (sender, args) =>
                {
                    var middlewareResult = (args as MiddlewareInvokedArgs).Result;
                    invokedResult = middlewareResult.IsSucceed;

                    if (!invokedResult)
                        throw new MiddlewareInnerException( middlewareResult .Message);

                    appFolder.Children.Add( middlewareResult.AppItem );
                };

                middleware.Invoke(context);

                i++;
            }

            return appFolder;

        }
    }
}
