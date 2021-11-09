using System;
using System.Collections.Generic;

namespace CDOM
{
    public class TEnum:TCodeFile
    {

        public TEnum(string _name, Dictionary<string, int> items)
        {
            Name = _name;
            Items = items;
        }

        public TEnum(string _name)
        {
            Name = _name;
            Items = new Dictionary<string, int>();
        }

        public AccessModifier AccessModifier { get; private set; }

        public Dictionary<string,int> Items { get; set; }

        public TEnum AddItems(Dictionary<string, int> items)
        {
            foreach (var item in items)
                this.Items.Add(item.Key, item.Value);

            return this;
        }


    }
}
