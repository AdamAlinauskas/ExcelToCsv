using System.Collections.Generic;
using System.Linq;
using DataAccess;
using Dto.Parser;

namespace Service.Parser
{
    public interface IRetrieveAllFilesQuery
    {
        FilesForListingDto Fetch();
    }

    public class RetrieveAllFilesQuery : IRetrieveAllFilesQuery
    {
        private readonly ICsvFileRepository csvFileRepository;

        public RetrieveAllFilesQuery(ICsvFileRepository csvFileRepository)
        {
            this.csvFileRepository = csvFileRepository;
        }

        public FilesForListingDto Fetch()
        {
            var fileDtos = MapFilesToFileDto();

            return new FilesForListingDto
            {
                Files = fileDtos
            };
        }

        private IEnumerable<FileDto> MapFilesToFileDto()
        {
            return csvFileRepository.AllFiles().Select(x => new FileDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description
            });
        }
    }
}