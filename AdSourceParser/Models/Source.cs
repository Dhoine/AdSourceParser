using System;
using System.IO;
using System.Net.Http;
using AdSourceParser.Enums;

namespace AdSourceParser.Models
{
    public class Source
    {
        private static readonly HttpClient client = new HttpClient();
        private static StreamReader URLStream(String fileurl)
        {
            return new StreamReader(new HttpClient().GetStreamAsync(fileurl).Result);
        }

        public SourceFileFormat FileFormat { get; set; }
        public SourceType SrcType { get; set; }

        public string SourceName { get; set; }
        public string Path { get; set; }

        public string GetFileText
        {
            get
            {
                return SrcType switch
                {
                    SourceType.File => GetTextFromFile(),
                    SourceType.DirectLink => GetTextFromLink(),
                    _ => throw new NotSupportedException("Only File and DirectLink are supported")
                };
            }
        }

        private string GetTextFromFile()
        {
            if (File.Exists(Path))
            {
                return File.ReadAllText(Path);
            }

            throw new FileNotFoundException(Path);
        }

        private string GetTextFromLink()
        {
            var stream = URLStream(Path);
            return stream.ReadToEnd();
        }
    }
}