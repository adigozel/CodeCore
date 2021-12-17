using System;
using System.Collections.Generic;
using System.Linq;

namespace MSL
{
    public class TEntity: TDSLDataType
    {

        public TEntity()
        {

        }

        public TEntity(string name):base(TDSLBaseTypes.Entity)
        {
            this.Name = name;

            this.Fields = new List<TField>();

            this.Commands = new List<TEntityCommand>();

            this.Compotencies = new List<TEntityCompetency>();

            this.Queries = new List<TQuery>();

        }

        public String Domain { get; set; }

        public string Name { get; set; }

        public string RepositoryName { get; set; }

        public ICollection<TField> Fields { get; set; }

        public TField Field(string fieldName)
        {
            foreach (var field in Fields)
                if (field.Name == fieldName)
                    return field;

            return null;
        }

        public bool IsStatic { get; set; }

        public bool IncludeAudit { get; set; }

        public bool IncludeCheckAccess { get; set; }

        public bool IsWorkFlowProduct { get; set; }

        public void AddFields(IEnumerable<TField> fields)
        {
            foreach (var field in fields)
                Fields.Add(field);
        }
             
        public ICollection<TEntityCommand> Commands { get; set; }

        public ICollection<TEntityCompetency> Compotencies { get; set; }

        public ICollection<TQuery> Queries { get; set; }

        public TQuery Query(string name)
        {
            foreach (var query in this.Queries)
                if (query.Name == name)
                    return query;

            return null;
        }

        public TEntityCompetency Compotency(string code)
        {
            foreach (var compotency in this.Compotencies)
                if (compotency.Name == code)
                    return compotency;

            return null;
        }

        public int CollectionFieldsCount
        {
            get
            {
                return this.Fields.Where(f => f.DataType.BaseType == TDSLBaseTypes.Collection).Count();
            }
        }

        public ICollection<TField> NoCollectionFields
        {
            get
            {
                return FieldsNoByType(TDSLBaseTypes.Collection);
            }
        }

        public ICollection<TField> CollectionFields
        {
            get
            {
                return FieldsByType(TDSLBaseTypes.Collection);
            }
        }

        public ICollection<TField> ReferenceFields
        {
            get
            {
                return FieldsByType(TDSLBaseTypes.Reference);
            }
        }

        public ICollection<TField> OptionFields
        {
            get
            {
                return FieldsByType(TDSLBaseTypes.Option);
            }
        }

        public ICollection<TField> FieldsByType(TDSLBaseTypes type)
        {
            if (this.Fields == null)
                return null;

            return this.Fields.Where(f => f.DataType.BaseType == type).ToList();
        }

        public ICollection<TField> FieldsNoByType(TDSLBaseTypes type)
        {
            if (this.Fields == null)
                return null;

            return this.Fields.Where(f => f.DataType.BaseType != type).ToList();
        }


    }
}
