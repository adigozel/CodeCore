using System;
using System.Collections.Generic;
using System.Linq;
using CDOM;

namespace CDOM
{
    public class TGeneric
    {
        public TGeneric(IEnumerable<TGenericParameter> parameters)
        {
            Parameters = parameters.ToList();
        }

        public ICollection<TGenericParameter> Parameters { get; set; }
    }

    public class TGenericParameter
    {
        public string Name { get; set; }

        public bool IsConstrainted { get; set; }

        public DataTypes ConstraintType { get; set; }
    }
}
