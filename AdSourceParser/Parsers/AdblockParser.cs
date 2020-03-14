using System;
using System.Collections.Generic;
using System.Linq;
using AdSourceParser.Helpers;
using AdSourceParser.Interfaces;

namespace AdSourceParser.Parsers
{
    public class AdblockParser : ISourceParser
    {
        public List<string> ParseSource(string source)
        {
            var lines = source.SplitByLines().ToList();

            lines.RemoveAt(0);

            return (from line in lines
                let wildcardReplaced = line.Replace('*', 'a')
                let isUri = Uri.CheckHostName(wildcardReplaced) != UriHostNameType.Unknown
                where isUri
                select line).ToList();
        }
    }
}