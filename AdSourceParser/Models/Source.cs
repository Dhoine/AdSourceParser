using AdSourceParser.Enums;

namespace AdSourceParser.Models
{
    public class Source
    {
        public SourceFileFormat FileFormat { get; set; }
        public SourceType SrcType { get; set; }

        public string SourceName { get; set; }
        public string Path { get; set; }
    }
}