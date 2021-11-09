using System;
using System.Collections.Generic;

namespace Template.Helpers
{
    public static class CodeTraditions
    {
        public static string Private_Variable_Name(string name)
        {
            return $"_{name.ToFirstCharLower()}";
        }

        public static string Private_Variable_Name_From_InterfaceType(string name)
        {
            return $"_{name.Substring(1, name.Length - 1).ToFirstCharLower()}";
        }

        public static string Method_Parameter_Name(string typeName)
        {
            return $"{typeName.ToFirstCharLower()}";
        }

        public static string Method_Parameter_Name_From_InterfaceType(string typeName)
        {
            //remove I begin interface
            return $"{typeName.Substring(1,typeName.Length-1).ToFirstCharLower()}";
        }

        public static string Method_Parameter_Name_From_ClassType( string typeName ) {
            return $"{typeName.Substring( 0, typeName.Length - 1 ).ToFirstCharLower( )}";
        }

        public static string ToFirstCharLower(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                if (input.Length > 1)
                {
                    return input[0].ToString().ToLower() + input.Substring(1);
                }
                else
                    return input[0].ToString().ToLower();
            }
            else return String.Empty;
        }

        public static string ToRepositoryName(this string input )
        {
            throw new NotImplementedException( );
        }
    }
}
