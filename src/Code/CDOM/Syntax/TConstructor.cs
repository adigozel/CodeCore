﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDOM
{

    public class TReferenceMethod
    {
        public enum MethodType { @base, @this }

        public TReferenceMethod(
            TReferenceMethod.MethodType type,
            ICollection<TParameter> parametrs)
        {
            this.Type = type;
            this.Parametrs = parametrs;
        }


        public MethodType Type { get; set; }
        public ICollection<TParameter> Parametrs { get; set; }

    }

    public class TConstructor
    {
        public TConstructor(
            AccessModifier accessModifier,
            ICollection<TParameter> parametrs,
            string content,
            TReferenceMethod referenceMethod = null)
        {
            AccessModifier = accessModifier;
            Content = content;
            Parametrs = parametrs;
            ReferenceMethod = referenceMethod;
        }

        public AccessModifier AccessModifier { get; set; }
        public string Content { get; set; }
        public TReferenceMethod ReferenceMethod { get; set; }
        public ICollection<TParameter> Parametrs { get; set; }

    }
}
