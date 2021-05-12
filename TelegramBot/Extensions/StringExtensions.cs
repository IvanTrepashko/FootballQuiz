using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Extensions
{
    public static class StringExtensions
    {
        public static bool IsDigit(this string str)
        {
            if (str.Length == 1 && char.IsDigit(str[0]))
            {
                return true;
            }

            return false;
        }
    }
}
