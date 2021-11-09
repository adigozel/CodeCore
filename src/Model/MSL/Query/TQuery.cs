using System;
using System.Collections.Generic;
using System.Linq;

namespace MSL
{
    public class TQuery:TDSLDataType
    {
        public TQuery()
        {

        }
        public TQuery(string name):base(TDSLBaseTypes.Query)
        {
            this.Name = name;
            this.Fields = new List<TQueryField>();
            this.Competencies = new List<TQueryCompotency>();
        }
  
        public string Name { get; set; }
        public string RepositoryName { get; set; }
        public bool IsRaw { get; set; }
        public bool IsWorkFlowView { get; set; }

        public ICollection<TQueryField> Fields { get; set; }
     
        public ICollection<TQueryCompotency> Competencies { get; set; }

        public void AddFieldRange(IEnumerable<TQueryField> fields)
        {
            foreach (var field in fields)
                this.Fields.Add(field);
        }

        //protected override void InitParameters( ) {
        //    Parameters.Add( "isRaw", false );
        //}

    }

}
