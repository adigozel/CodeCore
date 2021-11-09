using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CDOM;
using MSL;
using Template.Helpers;

namespace Template1.Domain
{
    public class EntityClass : TClass
    {
        TEntity _entity;
        public EntityClass( TDomain domain,TEntity entity) : base( entity.Name )
        {
            _entity = entity;

            Properties.AddRange (
                    _entity.Fields.Select( CodeConverter.ToEntityProperty ).Where( x => x.Name != "Id" ).ToList()
                );

            Methods.Add( GetEditMethod( ) );

            Methods.Add( GetCloneMethod( ) );
        }

        private TMethod GetEditMethod( )
        {
            
            return new TMethod( ) {
                Name = "Edit",
                AccessModifier = AccessModifier.@public,
                ReturnType = null,
                Parametrs = new List<TParameter>( ) {
                    new TParameter(new ClassDataType(_entity.Name),"newEntity")
                },
                Content = new BlockClouse( 
                       _entity.Fields.Select( x => new EqualsClause( x.Name, $"newEntity.{x.Name}" ) )
                    ),
            };
        }

        private TMethod GetCloneMethod( )
        {
            return new TMethod( ) {
                Name = "Clone",
                AccessModifier = AccessModifier.@public,
                ReturnType = new ClassDataType(_entity.Name),
                Parametrs = new List<TParameter>(),
                Content = new ReturnClause( new NewClause(_entity.Name,
                       _entity.Fields.Select( x => new EqualsClause( $"{x.Name}", $"{x.Name}" ) ).ToList()
                    )),
            };
        }

    }
}
