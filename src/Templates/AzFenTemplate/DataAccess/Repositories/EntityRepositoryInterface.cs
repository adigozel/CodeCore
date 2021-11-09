using CDOM;
using MSL;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzFenTemplate.DataAccess.Repositories
{
    public class EntityRepositoryInterface:TInterface
    {
        private readonly TEntity _entity;
        public EntityRepositoryInterface( TDomain domain, TEntity entity ):base( entity.Name)
        {
            _entity = entity;

        }
    }
}
