namespace Dto.Parser
{
    public class FileDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public byte[] Data { get; set; } = new byte[0];
        public string FileName { get; set; }
        public string Description { get; set; }
    }
}