using System.Collections.Generic;

namespace AdSourceParser.Interfaces
{
    public interface ISourceParser
    {
        List<string> ParseSource(string source);
    }
}