using System;
using System.Collections.Generic;


namespace Pipline
{

    public class AppContext
    {
        private IDictionary<string, object> properties;

        public AppContext()
        {
            properties = new Dictionary<string, object>();
        }

 
        public object GetValue(string key)
        {
            if (!properties.ContainsKey(key))
                return null;

            var value = properties[key];

            if (value is Func<object>)
                return (value as Func<object>).Invoke();
            else
                return value;
        }

        public bool ContainsKey(string key)
        {
            return properties.ContainsKey(key);
        }

        public AppContext AddProperty(string key, object value)
        {
            properties.Add(key, value);
            return this;
        }

        public AppContext AddProperty(string key, Func<object> value)
        {
            properties.Add(key, value);
            return this;
        }


        public AppContext SetProperty(string key, object newValue)
        {
            properties[key] = newValue;
            return this;
        }
    }
}
