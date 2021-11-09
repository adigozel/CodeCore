using System;
using System.Collections.Generic;

namespace CodeGenerator.Infrastructure
{
    public static class CommonPathes
    {
        public static string GetToolsPath(string basePath)
        {
            return basePath + "\\tools";
        }
     
        public static string GetTemplateReferencesPath(string templateName, string basePath)
        {
            return basePath + $"\\templates\\{templateName.ToLower()}\\references";
        }

        public static string GetSolutionPath(String solutionName, string basePath)
        {
            return basePath + $"\\projects\\{solutionName.ToLower()}";
        }

        //public static string GetSolutionConnectionPath(String solutionName, string basePath)
        //{
        //    return GetSolutionPath(solutionName, basePath) + $"\\connections";
        //}

        //public static string GetDbScriptsPath(String solutionName, string basePath)
        //{
        //    return GetSolutionPath(solutionName, basePath) + $"\\dbscripts";
        //}

        //public static string GetPublishBasePath(String solutionName, string basePath)
        //{
        //    return GetSolutionPath(solutionName, basePath) + $"\\publishes";
        //}

        //public static string GetPublishConnectionPath(String solutionName, string connectionName, string basePath)
        //{
        //    return GetPublishBasePath(solutionName, basePath) + $"\\{connectionName}";
        //}

        //public static string GetViewScriptFileName(string releaseNumber)
        //{
        //    return $"{releaseNumber}_views.sql";
        //}

        //public static string GetFunctionScriptFileName(string releaseNumber)
        //{
        //    return $"{releaseNumber}_functions.sql";
        //}

        //public static string GetPublisViewsScriptiFilePath(String solutionName, string releaseNumber, string connectionName, string basePath)
        //{
        //    return GetPublishConnectionPath(solutionName, connectionName, basePath) + $"\\{GetViewScriptFileName(releaseNumber)}";
        //}

        //public static string GetPublishTablesScriptFileName(String solutionName,string releaseNumber)
        //{
        //    return $"{solutionName}_{releaseNumber}_tables.sql";
        //}

        //public static string GetPublishTablesScripFilePath(String solutionName, string releaseNumber, string connectionName, string basePath)
        //{
        //    return GetPublishConnectionPath(solutionName, connectionName, basePath) + $"\\{GetPublishTablesScriptFileName(solutionName,releaseNumber)}";
        //}

        //public static string GetPublishReleasePath(String solutionName,string connectionName,string releaseNumber, string basePath)
        //{
        //    return GetPublishConnectionPath(solutionName, connectionName, basePath) + $"\\{releaseNumber}";
        //}

        public static string GetReleaseBasePath(String solutionName, string basePath)
        {
            return GetSolutionPath(solutionName, basePath) + $"\\releases";
        }

        public static string GetReleasePath(String solutionName,string releaseNumber, string basePath)
        {
            return GetReleaseBasePath(solutionName, basePath) + $"\\{releaseNumber}";
        }

        public static string GetComponentPath(string basePath)
        {
            return basePath + "\\components";
        }

        public static string GetReleaseSourcePath(String solutionName, string releaseNumber, string basePath)
        {
            return GetReleasePath(solutionName, releaseNumber, basePath) + $"\\src";
        }

        public static string GetReleaseBinPath(String solutionName, string releaseNumber, string basePath)
        {
            return GetReleasePath(solutionName, releaseNumber, basePath) + $"\\bin";
        }
    }
}
