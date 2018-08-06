using System.Text;
using DataAccess;
using Dto.Parser;

namespace Service.Parser
{
    public interface IRetrieveFileForDownloadQuery
    {
        FileDto Fetch(long Id);
    }

    public class RetrieveFileForDownloadQuery : IRetrieveFileForDownloadQuery
    {
        private readonly ICsvFileRepository csvFileRepository;

        public RetrieveFileForDownloadQuery(ICsvFileRepository csvFileRepository)
        {
            this.csvFileRepository = csvFileRepository;
        }

        public FileDto Fetch(long Id)
        {
            var file = csvFileRepository.FindBy(Id);
            if(file == null)
                return new FileDto();

            return new FileDto
            {
                Data = Encoding.UTF8.GetBytes(file.Contents),
                FileName = $"{file.Title}.csv"
            };
        }
    }
}
