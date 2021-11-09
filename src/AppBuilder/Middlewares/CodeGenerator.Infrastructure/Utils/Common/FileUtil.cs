using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CodeGenerator.Infrastructure.Utils.Common
{
    public static class FileUtil
    {
        public static void CreateDirectory(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static void DeleteDirectory(string path)
        {
            Directory.Delete(path);
        }

        public static string GetCurrentDirectory()
        {
            return Directory.GetCurrentDirectory();
        }
        public static void SetCurrentDirectory(string path)
        {
            Directory.SetCurrentDirectory(path);
        }

        public static void CreateFile(string path, string content)
        {
            if ( File.Exists(path))
            {
                File.Delete(path);
            }

            // Create the file.
            using (FileStream fs = File.Create(path))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(content);
                fs.Write(info, 0, info.Length);
            }
        }

        public static void CreateFile(string path, byte[] content)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Create the file.
            using (FileStream fs = File.Create(path))
            {
                fs.Write(content, 0, content.Length);
            }
        }

        public static void CopyFiles(string fromPath, string toPath,bool overwide)
        {
            CreateDirectory(toPath);

            string[] fileNames = Directory.GetFiles(fromPath, "*.*");

            foreach (var fileName in fileNames)
            {
                System.IO.File.Copy(fileName, fileName.Replace($"{fromPath}", $"{toPath}"), overwide);
            }

        }

        public static void CopyFile(string fileName, string fromPath,string toPath,bool overwide)
        {
            CopyFile(fileName, fromPath, fileName, toPath, overwide);
            //string filePath = fromPath + $"\\{fileName}";

            //System.IO.File.Copy(filePath, filePath.Replace($"{fromPath}", $"{toPath}"), overwide);
        }

        public static void CopyFile(string fromfileName, string fromPath,string toFileName, string toPath, bool overwide)
        {
            string srcFile = fromPath + $"\\{fromfileName}";
            string destFile = toPath + $"\\{toFileName}";

            System.IO.File.Copy(srcFile, destFile, overwide);
        }

        public static void DeleteAllFiles(string path)
        {
            System.IO.DirectoryInfo _directory =
                new DirectoryInfo(path);

            foreach (FileInfo file in _directory.GetFiles("*.*", SearchOption.AllDirectories))
            {
                file.Delete();
            }
        }

        public static string CreateTempDirectory(string basePath)
        {
            Guid tempId = Guid.NewGuid();
            string tempPath = $"{basePath}\\temp\\{tempId}\\";
            Directory.CreateDirectory(tempPath);
            return tempPath;
        }

        public static IEnumerable<string> GetFileNames(string basePath, string filter)
        {
            var directoryInfo = new DirectoryInfo(basePath);
            var files = directoryInfo.GetFiles();

            return files.Where(x => x.Extension == filter).Select(x => x.Name.Replace(x.Extension,""));
        }

        public static string GetFileContent(string fileName)
        {
            using(var reader = File.OpenText(fileName))
            {
                return reader.ReadToEnd();
            }
        }

        public static byte[] GetFileContentAsByte(string filePath)
        {
            if (File.Exists(filePath))
            {
                return File.ReadAllBytes(filePath);
            }
            else
                throw new Exception("File cannot found");
        }

        //public static void ZipFolder(string folderPath,string zipFileName)
        //{
        //    if (Directory.Exists(folderPath))
        //    {
        //        using (var zip = new Ionic.Zip.ZipFile(zipFileName))
        //        {
        //            zip.AddDirectory(folderPath);
        //            zip.Save(folderPath + "\\" + zipFileName + ".zip");
        //        }
        //    }
        //    else
        //        throw new Exception("Folder cannot found");
        //}
    }
}
