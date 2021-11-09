using System;
using System.Collections.Generic;

namespace System
{
    public static class StringExtensions
    {
        public static bool CheckScopeCorecting(string input,char beginScopeChar, char endScopeChar)
        {
            int c = 0;

            foreach (var f in input.ToCharArray())
            {
                if (f == beginScopeChar)
                    c++;
                else
                if (f == endScopeChar)
                    c--;

                if (c < 0)
                    return false;
            }


            if (c != 0)
                return false;
            else
                return true;
        }

        public static IEnumerable<string> ParseScopeValues(this string input,char beginScopeChar,char endScopeChar)
        {
            if (!CheckScopeCorecting(input, beginScopeChar, endScopeChar))
                throw new Exception("Custom field is not correct format!");

            for(int beginScopeIndex, endScopeIndex = 0;(beginScopeIndex = input.IndexOf(beginScopeChar, endScopeIndex)) > -1;)
            {
                endScopeIndex = input.IndexOf(endScopeChar, beginScopeIndex);
                yield return input.Substring(beginScopeIndex + 1, endScopeIndex - (beginScopeIndex + 1));
            }

        }

        public static string SubStringToLastChar(this string input,char lastChar)
        {
            if (input == null)
                return null;

            int lastPoint = input.LastIndexOf('.');

            if (lastPoint > -1)
                return input.Substring(0, lastPoint);
            else
                return null;
        }

        public static string SubStringFromLastChar(this string input, char lastChar)
        {
            int lastPoint = input.LastIndexOf('.');

            if (lastPoint > -1)
                return input.Substring(lastPoint+1);
            else
                return null;
        }
    }
}
