using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSL
{
    public class TQueryCompotency
    {
        public TQueryCompotency()
        {

        }
        public TQueryCompotency(string queryFieldName,string entitycompetencyName)
        {

            this.QueryFieldName = queryFieldName;

            this.EntityCompetencyName = entitycompetencyName;

        }

        public string QueryFieldName { get; set; }

        public string EntityCompetencyName { get; set; }
    }
}
