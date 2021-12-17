using System;
using System.Collections.Generic;
using System.Text;

namespace Pipline
{
    public class AppFolder:AppItem
    {
        public AppFolder( )
        {
            Children = new List<AppItem>( );
        }

        public AppFolder( List<AppItem> children )
        {
            Children = children;
        }

        public List<AppItem> Children { get; set; }

        public AppItem AddItem( AppItem item )
        {
            Children.Add( item );
            return this;
        }
    }
}
