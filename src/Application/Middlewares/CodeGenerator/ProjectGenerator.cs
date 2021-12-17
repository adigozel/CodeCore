using System;
using System.Linq;
using CDOM;
using Pipline;

namespace CodeGenerator
{
    public static  class ProjectGenerator
    {
        public static AppItem Create(TProject prj, ISyntaxAdapter adabter)
        {
            var item = new AppFolder( );

            item.Children.AddRange(
                    prj.Classes.Select(
                        x => ClassGenerator.Create( x, adabter )
                       )
                );

            item.Children.AddRange(
                    prj.Interfaces.Select(
                        x => InterfaceGenerator.Create( x, adabter )
                       )
                );

            item.Children.AddRange(
                    prj.Enums.Select(
                        x => EnumGenerator.Create( x, adabter )
                       )
                );


            item.Children.AddRange(
                    prj.Packets.Select(
                        x => PacketGenerator.Create( x, adabter )
                       )
                );

            return item;
        }
    }
}
