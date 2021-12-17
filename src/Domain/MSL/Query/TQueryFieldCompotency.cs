using System;
using System.Collections.Generic;

namespace MSL
{
    public class TQueryFieldCompotency
    {
        public TQueryFieldCompotency(TEntityCompetency entityCompetency)
        {
            this.EntityCompetency = entityCompetency;
        }

        public TEntityCompetency EntityCompetency { get; set; }
    }
}
