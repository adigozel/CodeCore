using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CodeGenerator.Infrastructure.Utils.Common
{
    public static class ProcessUtil
    {
        public static string Run(string fileName,string parameters="",bool waitForExit = true)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.Arguments = parameters;
            processInfo.Verb = "runas";
            processInfo.FileName = fileName;

            var process = Process.Start(processInfo);

            if (waitForExit)
                process.WaitForExit();


            var errorList = GetProcessErrors(process);

            if (errorList.Count > 0)
            {
                throw new Exception(errorList[0]);
            }

            var result = process.StandardOutput.ReadToEnd();

            return result;
        }

        private static List<string> GetProcessErrors(Process process)
        {
            var reader = process.StandardError;
            var errorList = new List<string>();

            var error = reader.ReadLine();

            while (!string.IsNullOrEmpty(error))
            {
                errorList.Add(error);
                error = reader.ReadLine();
            }

            return errorList;
        }

        public static void InvokeMethod(string assemblyPath, string assemblyName, string className, string methodName, params object[] parameters)
        {
            var assembly = CreateAssemblyFrom(assemblyPath, assemblyName);
            Type type = assembly.GetType(className);

            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod(methodName);
                if (methodInfo != null)
                {
                    object classInstance = Activator.CreateInstance(type, null);

                    var result = methodInfo.Invoke(classInstance, parameters);
                }
            }
        }

        public static string FindImplementationClassPath(string assemblyPath, string assemblyName, Type interfaceType)
        {
            var assembly = CreateAssemblyFrom(assemblyPath, assemblyName);
            var types=assembly.GetTypes();
            var type = assembly.GetTypes()
                .FirstOrDefault(p => interfaceType.IsAssignableFrom(p));

            if (type == null)
                return null;
            else
                return type.FullName;
        }

        private static Assembly CreateAssemblyFrom(string assemblyPath, string assemblyName)
        {
            return Assembly.LoadFile(assemblyPath + "//" + assemblyName + ".dll");
        }
    }
}
