using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AdSourceParser.Helpers;
using AdSourceParser.Interfaces;

namespace AdSourceParser.Parsers
{
    public class AdblockPlusParser : ISourceParser
    {
        private Regex HostRegex = new Regex("\\|\\|(.*)\\^");
        public List<string> ParseSource(string source)
        {
            var lines = source.SplitByLines().ToList();

            return (from line in lines
                from Match match in HostRegex.Matches(line)
                from Group @group in match.Groups
                where Uri.CheckHostName(@group.Value) != UriHostNameType.Unknown
                select @group.Value).ToList();
        }
    }
}