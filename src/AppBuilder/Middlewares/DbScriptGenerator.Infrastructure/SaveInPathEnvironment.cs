using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbScriptGenerator.Infrastructure
{
    public class SaveInPathEnvironment : ISaveEnvironment
    {
        string _path;
        public SaveInPathEnvironment(string path)
        {
            _path = path+"\\db";
        }

        public void Save( string providerType, string name, string content)
        {
            var path = $"{_path}\\{providerType}";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var file = path + $"\\{name}.sql";

            if (File.Exists(file))
                File.Delete(file);

            using (FileStream fs = File.Create(file))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }
    }
}
