using System.Data;
using DataAccess;
using Domain;
using Dto;
using Dto.Parser;
using ExcelDataReader;
using Utility;

namespace Service.Parser
{
    public interface IParseExcelFileCommand
    {
        void Execute(ExcelFileDto dto);
    }

    public class ParseExcelFileCommand : IParseExcelFileCommand
    {
        private readonly ICsvFileRepository csvFileRepository;

        public ParseExcelFileCommand(ICsvFileRepository csvFileRepository)
        {
            this.csvFileRepository = csvFileRepository;
        }

        public void Execute(ExcelFileDto dto)
        {
            DataSet data = null;
            using (var reader = ExcelReaderFactory.CreateReader(dto.File))
            {
                data = reader.AsDataSet();
            }

            var csvData = data.Tables[0].ToCsv();

            var csvFile = new CsvFile
            {
                Title = dto.Title,
                Description = dto.Description,
                Contents = csvData
                
            };

            csvFileRepository.Save(csvFile);
        }
    }
}
