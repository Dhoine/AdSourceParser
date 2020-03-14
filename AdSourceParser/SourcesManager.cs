using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using AdSourceParser.Enums;
using AdSourceParser.Models;
using AdSourceParser.Parsers;

namespace AdSourceParser
{
    public class SourcesManager
    {
        private static StreamReader URLStream(String fileurl)
        {
            return new StreamReader(new HttpClient().GetStreamAsync(fileurl).Result);
        }

        private readonly ParsersFactory _parsersFactory = new ParsersFactory();
        private string GetFileText(Source source)
        {
            return source.SrcType switch
            {
                SourceType.File => GetTextFromFile(source),
                SourceType.DirectLink => GetTextFromLink(source),
                _ => throw new NotSupportedException("Only File and DirectLink are supported")
            };
        }

        private string GetTextFromFile(Source source)
        {
            if (File.Exists(source.Path))
            {
                return File.ReadAllText(source.Path);
            }

            throw new FileNotFoundException(source.Path);
        }

        private string GetTextFromLink(Source source)
        {
            var stream = URLStream(source.Path);
            return stream.ReadToEnd();
        }

        public List<string> GetHosts(List<Source> sources)
        {
            return sources.SelectMany(s =>
            {
                var parser = _parsersFactory.GetParser(s.FileFormat);
                return parser.ParseSource(GetFileText(s));
            }).ToList();
        }
    }
}