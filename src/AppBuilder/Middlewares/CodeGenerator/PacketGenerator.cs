using System;
using System.Linq;
using CDOM;
using Pipline;

namespace CodeGenerator
{
    public static class PacketGenerator
    {
        public static AppItem Create(TPacket packet,ISyntaxAdapter adabter)
        {
            var item = new AppFolder( );

            item.Children.AddRange(
                    packet.Classes.Select(
                        x => ClassGenerator.Create( x, adabter )
                       )
                );

            item.Children.AddRange(
                    packet.Interfaces.Select(
                        x => InterfaceGenerator.Create( x, adabter )
                       )
                );

            item.Children.AddRange(
                    packet.Enums.Select(
                        x => EnumGenerator.Create( x, adabter )
                       )
                );


            item.Children.AddRange(
                    packet.Packets.Select(
                        x => Create( x, adabter )
                       )
                );
            return item;
        }
    }
}
