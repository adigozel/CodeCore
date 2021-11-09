using System;
using System.Collections.Generic;
using System.Text;

namespace MSL
{
    public class TQueryFilter
    {
        public TQueryFilter( string name, ICollection<TField> fields )
        {
            Name = name;
            Fields = fields;
        }

        public TQueryFilter( )
        {
            this.Fields = new List<TField>( );
        }

        public string Name { get; set; }
        public ICollection<TField> Fields { get; set; }
    }
}
