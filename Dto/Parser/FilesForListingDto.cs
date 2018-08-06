using System.Collections.Generic;

namespace Dto.Parser
{
    public class FilesForListingDto
    {
        public IEnumerable<FileDto> Files { get; set; } = new List<FileDto>();
    }
}