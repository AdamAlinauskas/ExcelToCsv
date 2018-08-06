using System.Linq;
using DataAccess;
using Domain;
using NUnit.Framework;

namespace Tests.DataAccess
{
    public class CsvFileRepositoryTests
    {
        public class when_saving_a_file
        {
            [Test]
            public void it_should_have_saved_the_file()
            {
                var sut = new CsvFileRepository().Reset();
                sut.Save(new CsvFile());
                Assert.AreEqual(sut.AllFiles().Count(), 1);
            }
        }

        public class when_finding_a_file_by_id
        {
            [Test]
            public void it_should_find_the_file()
            {
                var sut = new CsvFileRepository().Reset();
                sut.Save(new CsvFile());
                sut.Save(new CsvFile());

                var file = sut.FindBy(2);
                Assert.NotNull(file);
                Assert.AreEqual(file.Id,2);
            }
        }
    }
}