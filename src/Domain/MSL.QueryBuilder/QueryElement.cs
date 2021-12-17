using System;

namespace MSL.QueryBuilder
{
    public class QueryElement
    {
        public QueryElement(string[] columns, JoinElement join)
        {
            Columns = columns;
            Join = join;
        }

        public string[] Columns { get; set; }
        public JoinElement Join { get; set; }
    }
}
