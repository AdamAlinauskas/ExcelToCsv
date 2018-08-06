using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.Parser;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Rhino.Mocks;
using Service.Parser;
using web.Controllers;

namespace Tests.Web
{
    public class ParserControllerTests
    {

        public abstract class BehavesLikeaParserController
        {
            protected IParseExcelFileCommand parseExcelFileCommand;
            protected IPostedFileMapper fileMapper;
            protected IRetrieveAllFilesQuery retrieveAllFilesQuery;
            protected IRetrieveFileForDownloadQuery retrieveFileForDownload;

            protected ParserController sut()
            {
                //This process of creating mocks is automatic in the code I typically use, but this works perfectly fine too
                parseExcelFileCommand = MockRepository.GenerateMock<IParseExcelFileCommand>();
                fileMapper = MockRepository.GenerateMock<IPostedFileMapper>();
                retrieveAllFilesQuery = MockRepository.GenerateMock<IRetrieveAllFilesQuery>();
                retrieveFileForDownload = MockRepository.GenerateMock<IRetrieveFileForDownloadQuery>();

                return new ParserController(parseExcelFileCommand,fileMapper,retrieveAllFilesQuery,retrieveFileForDownload);
            }
        }

        public class when_viewing_the_index : BehavesLikeaParserController
        {
            [Test]
            public void it_should_return_the_correct_value()
            {
                var controller = sut();

                var files = new FilesForListingDto();
                retrieveAllFilesQuery.Stub(x => x.Fetch()).Return(files);

                var result = controller.Index();
                Assert.AreEqual(result.Model,files);
            }
        }

        public class when_Downloading_a_file : BehavesLikeaParserController
        {
            [Test]
            public void it_should_return_the_correct_value()
            {
                //Arranage
                var controller = sut();
                var id = 42;
                var awesomeCsvFile = "Awesome CSV File";
                var file = new FileDto
                {
                    FileName = awesomeCsvFile
                };
                retrieveFileForDownload.Stub(x => x.Fetch(id)).Return(file);

                //Act
                var result = controller.Download(id);

                //Assert
                Assert.AreEqual(result.FileDownloadName, awesomeCsvFile);
            }
        }
    }
}
