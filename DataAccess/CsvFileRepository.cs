using System.Collections.Generic;
using System.Linq;
using Domain;

namespace DataAccess
{
    public interface ICsvFileRepository
    {
        void Save(CsvFile csvFile);
        IEnumerable<CsvFile> AllFiles();
        CsvFile FindBy(long id);
    }

    public class CsvFileRepository : ICsvFileRepository
    {
        private static List<CsvFile> Files = new List<CsvFile>();
        private static int id = 0;

        public void Save(CsvFile csvFile)
        {
            csvFile.Id = ++id;
            Files.Add(csvFile);
        }

        public IEnumerable<CsvFile> AllFiles()
        {
            return Files.ToList();
        }

        public CsvFile FindBy(long id)
        {
            return Files.SingleOrDefault(x => x.Id == id);
        }
    }
}
