using System;
using System.Collections.Generic;

namespace MSL
{
    public class TEntityCommand
    {
        public TEntityCommand()
        {
            Inputs = new Dictionary<string, TDSLDataType>();
        }

        public TEntityCommand(string name):this()
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public IDictionary<string,TDSLDataType> Inputs { get; set; }

        public void AddInputsRange(IDictionary<string, TDSLDataType> inputs)
        {
            foreach (var input in inputs)
                this.Inputs.Add(input);
        }
    }
}
