using System;
using System.Collections.Generic;

namespace MSL
{
    public class TDSLDataType
    {
        public TDSLDataType()
        {

        }

        public TDSLDataType(TDSLBaseTypes baseType)
        {
            this.BaseType = baseType;

            InitParameters();

        }

        public TDSLDataType(TDSLBaseTypes baseType,bool isNullable):this(baseType)
        {
            IsNullable = isNullable;
        }

        public TDSLDataType(TDSLBaseTypes baseType, bool isNullable,params KeyValuePair<string,object>[] parameters ) : this(baseType,isNullable)
        {
            foreach(var param in parameters)
                Parameters[param.Key] = param.Value;
        }

        public TDSLBaseTypes BaseType { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public bool IsNullable { get; set; }

        public TDSLDataType SetParameter(string key, object value)
        {
            this.Parameters[key] = value;

            return this;
        }

        protected virtual void InitParameters()
        {
            Parameters = new Dictionary<string, object>();

            if (this.BaseType == TDSLBaseTypes.Text)
            {
                Parameters.Add("length", 100);
            }
            else if (BaseType == TDSLBaseTypes.Number)
            {
                Parameters.Add("scale", 0);
                Parameters.Add("precision", 0);
            }
            else if (BaseType == TDSLBaseTypes.Integer)
            {
                Parameters.Add("storage", 32);
            }
            else if (BaseType == TDSLBaseTypes.Reference)
            {
                Parameters.Add("reference_entity", null);
                Parameters.Add("is_cascade", false);
            }
            else if (BaseType == TDSLBaseTypes.Collection)
            {
                Parameters.Add("collection_entity", null);
            }
            else if (BaseType == TDSLBaseTypes.Option)
            {
                Parameters.Add("option", null);
            }
            else if (BaseType == TDSLBaseTypes.Custom)
            {
                Parameters.Add("custom_type", null);
            }
        }

    }

    //public class TNUllabelDataType : TDSLDataType
    //{
    //    public TNUllabelDataType(TDSLTypes type, bool nullable = false) : base(type)
    //    {
    //        this.Nullable = nullable;
    //    }

    //    public bool Nullable { get; set; }
    //}
}
