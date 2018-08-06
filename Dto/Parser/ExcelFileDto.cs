using System.IO;

namespace Dto.Parser
{
    public class ExcelFileDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Stream File { get; set; }
    }
}
