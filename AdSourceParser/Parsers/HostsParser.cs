using System;
using System.Collections.Generic;
using System.Linq;
using AdSourceParser.Helpers;
using AdSourceParser.Interfaces;

namespace AdSourceParser.Parsers
{
    public class HostsParser : ISourceParser
    {
        private List<string> LocalHosts = new List<string>{ "127.0.0.1", "::1"};
        public List<string> ParseSource(string source)
        {
            var lines = source.SplitByLines().ToList();
            var res = (from line in lines
                where !line.Trim().StartsWith('#')
                select line.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                into parts
                where parts.Length >= 2
                where LocalHosts.Any(h => h.Equals(parts[0].Trim(), StringComparison.OrdinalIgnoreCase)) &&
                      Uri.CheckHostName(parts[1]) != UriHostNameType.Unknown
                select parts[1]).ToList();
            throw new System.NotImplementedException();
        }
    }
}