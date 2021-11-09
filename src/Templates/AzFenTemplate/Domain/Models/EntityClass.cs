using CDOM;
using MSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Template.Helpers;

namespace AzFenTemplate.Domain.Models
{
    public class EntityClass : TClass
    {
        TEntity _entity;
        public EntityClass( TDomain domain, TEntity entity ) : base( entity.Name )
        {
            _entity = entity;

            Properties.AddRange(
                    _entity.Fields.Select( CodeConverter.ToEntityProperty ).ToList( )
                );

             NewConstructor( AccessModifier.@public )
                .AddParameter( "DataRow", "row" )
                .AddContentCode( 
                            new EqualsClause(
                                    new TVariable( AccessModifier.none, new ClassDataType( "DataColumnCollection" ), "columns" ),
                                    new NameClouse( "row.Table.Columns" ) 
                            )
                )
                .AddContentCodeRange( _entity.Fields.Select( 
                        x => new EqualsClause( x.Name, $"row[\"{x.Name.ToRepositoryName()}\"].ToString()" )
                    ));

        }
    }
}
