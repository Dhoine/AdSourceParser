using System;
using AdSourceParser.Enums;
using AdSourceParser.Interfaces;

namespace AdSourceParser.Parsers
{
    public class ParsersFactory
    {
        public ISourceParser GetParser(SourceFileFormat format)
        {
            switch (format)
            {
                case SourceFileFormat.Adblock:
                    return new AdblockParser();
                case SourceFileFormat.AdblockPlus:
                    return new AdblockPlusParser();
                case SourceFileFormat.Hosts:
                    return new HostsParser();
                default:
                    throw new ArgumentOutOfRangeException(nameof(format), format, null);
            }
        }
    }
}