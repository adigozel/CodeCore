using System;
using System.Collections.Generic;

namespace MSL
{
    public class TOption:TDSLDataType
    {
        public TOption()
        {

        }

        public TOption(string name, Dictionary<string, int> items) : base(TDSLBaseTypes.Option)
        {
            this.Name = name;

            this.Items = items;
        }

        public TOption(string name) : this(name, new Dictionary<string, int>())
        {
        }

        public String Domain { get; set; }

        public string Name { get; set; }

        public Dictionary<string, int> Items { get; set; }
    }
}
