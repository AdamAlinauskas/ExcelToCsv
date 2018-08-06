using DataAccess;
using Service;
using Service.Parser;
using StructureMap;

namespace IOC
{
    public static class MyIoc
    {
        //Manual Registeration to start then use auto mapping with interface convention.
        public static void Init(IContainer container)
        {
            //task
            container.Configure(x => x.For<IParseExcelFileCommand>().Use<ParseExcelFileCommand>());
            container.Configure(x => x.For<IPostedFileMapper>().Use<PostedFileMapper>());
            container.Configure(x => x.For<IRetrieveAllFilesQuery>().Use<RetrieveAllFilesQuery>());
            container.Configure(x => x.For<IRetrieveFileForDownloadQuery>().Use<RetrieveFileForDownloadQuery>());

            //data access
            container.Configure(x => x.For<ICsvFileRepository>().Use<CsvFileRepository>());
        }
    }
}
