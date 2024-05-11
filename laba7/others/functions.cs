using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace laba7.others
{
    internal static class Functions
    {
        internal static string RandomString()
        {
            Random rnd = new Random();
            char[] pwdChars = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            string result = string.Empty;
            for (int i = 0; i < 10; i++)
                result += pwdChars[rnd.Next(0, 25)];
            return result;
        }

        internal static bool IsString(string str)
        {
            string pattern = @"^([A-Za-zА-Яа-я]|[0-9]|[_])+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            return false;
        }

        internal static bool IsInteger(string str)
        {
            string pattern = "^[0-9]+$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            return false;
        }


        internal static bool IsFloat(string str)
        {
            string pattern = "^[0-9]*[.][0-9]*$";
            Match match = Regex.Match(str, pattern);
            if (match.Success)
            {
                return match.Success;
            }
            return false;
        }
    }
}
