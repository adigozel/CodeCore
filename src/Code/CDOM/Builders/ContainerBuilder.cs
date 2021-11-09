using System;
using System.Collections.Generic;
using System.Text;

namespace CDOM.Builders
{
    public class ContainerBuilder
    {
        private readonly TContainer _container;

        public ContainerBuilder( TContainer container )
        {
            _container = container;
        }

        public ContainerBuilder AddClass(TClass cls )
        {
            _container.Classes.Add( cls );
            return this;
        }

        public TContainer Container => _container;

        public static ContainerBuilder Create( TContainer container )
        {
            return new ContainerBuilder( container );
        }
    }
}
