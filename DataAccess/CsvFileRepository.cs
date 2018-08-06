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
        private static List<CsvFile> files = new List<CsvFile>();
        private static int id = 0;

        //More than one user with a static list can cause problems with Id's
        //the best solution is a database or locking.
        public void Save(CsvFile csvFile)
        {
            csvFile.Id = ++id;
            files.Add(csvFile);
        }

        public IEnumerable<CsvFile> AllFiles()
        {
            return files.ToList();
        }

        public CsvFile FindBy(long id)
        {
            return files.SingleOrDefault(x => x.Id == id);
        }

        //Only available on concrete class and no interface as it's used for tests.
        public CsvFileRepository Reset()
        {
            id = 0;
            files.Clear();
            return this;
        }
    }
}
