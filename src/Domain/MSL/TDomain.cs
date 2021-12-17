using System;
using System.Collections.Generic;
using System.Linq;

namespace MSL
{
    public class TDomain
    {
  
        public TDomain()
        {

        }

        public TDomain(string name)
        {
            this.Name = name;
            this.Entities = new List<TEntity>();
            this.Options = new List<TOption>();
        }

        public string Name { get; set; }

        public ICollection<TEntity> Entities { get; set; }

        public ICollection<TOption> Options { get; set; }

        public IEnumerable<TEntity> NoStaticEntities { get
            {
                return this.Entities.Where(e => !e.IsStatic);
            }
        }

        public IEnumerable<TEntity> StaticEntities
        {
            get
            {
                return this.Entities.Where(e => e.IsStatic);
            }
        }

        public bool IsCollectionEntity(TEntity entity)
        {
            foreach(var e in Entities.Where(x=>x.Name != entity.Name))
            {
                var count = 
                    e.Fields
                    .Where(
                        x => x.DataType.BaseType == TDSLBaseTypes.Collection
                        && x.DataType.Parameters["collection_entity"].ToString() == entity.Name)
                        .Count();

                if (count > 0)
                    return true;
            }

            return false;
        }

        public TEntity Entity(string name)
        {
            foreach (var entity in Entities)
            {
                if (entity.Name == name)
                    return entity;
            }

            return null;
        }
        public TOption Option(string name)
        {
            foreach (var option in Options)
            {
                if (option.Name == name)
                    return option;
            }

            return null;
        }

        public bool IncludeIdentityAccess { get; set; }

        public bool IncludeWorkFlow { get; set; }
    }
}
