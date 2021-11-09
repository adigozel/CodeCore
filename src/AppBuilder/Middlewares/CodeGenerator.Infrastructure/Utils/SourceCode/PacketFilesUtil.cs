using System;
using System.Collections.Generic;
using CodeGenerator.Langugage;
using CodeGenerator.Core;
using CodeGenerator.Infrastructure.Utils.Common;

namespace CodeGenerator.Infrastructure.Utils.SourceCode
{
    public static class PacketFilesUtil
    {
        public static void CreateFiles(TPacket packet,string projectPath,ILungugageCode adabter)
        {
            string packetPath = projectPath + $"\\{packet.Name}";
            FileUtil.CreateDirectory(packetPath);


            foreach (var child in packet.Packets)
            {
                PacketFilesUtil.CreateFiles(child, packetPath, adabter);
            }

            foreach (var cls in packet.Classes)
            {
                ClassFilesUtil.CreateFiles(cls, packetPath, adabter);
            }

            foreach (var intr in packet.Interfaces)
            {
                InterfaceFilesUtil.CreateFiles(intr, packetPath, adabter);
            }

            foreach (var intr in packet.Enums)
            {
                EnumFilesUtil.CreateFiles(intr, packetPath, adabter);
            }
        }
    }
}
