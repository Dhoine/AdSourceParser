using System;
using System.Collections.Generic;
using System.Linq;

namespace AdSourceParser.Helpers
{
    public static class StringFunctions
    {
        public static IEnumerable<string> SplitByLines(this String str)
        {
            return str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}