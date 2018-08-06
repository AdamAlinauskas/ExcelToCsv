using System.Web.Mvc;
using Dto;
using Dto.Parser;
using Service;
using Service.Parser;

namespace web.Controllers
{
    public class ParserController : Controller
    {
        private readonly IParseExcelFileCommand parseExcelFileCommand;
        private readonly IPostedFileMapper fileMapper;
        private readonly IRetrieveAllFilesQuery retrieveAllFilesQuery;
        private readonly IRetrieveFileForDownloadQuery retrieveFileForDownload;

        public ParserController(IParseExcelFileCommand parseExcelFileCommand, IPostedFileMapper fileMapper, IRetrieveAllFilesQuery retrieveAllFilesQuery, IRetrieveFileForDownloadQuery retrieveFileForDownload)
        {
            this.parseExcelFileCommand = parseExcelFileCommand;
            this.fileMapper = fileMapper;
            this.retrieveAllFilesQuery = retrieveAllFilesQuery;
            this.retrieveFileForDownload = retrieveFileForDownload;
        }

        public ActionResult Index()
        {
            var dto = retrieveAllFilesQuery.Fetch();
            return View(dto);
        }
       
        public ActionResult ParseExcelFile()
        {
            return View();
        }

        //Assuming one file but could be extened to handle multiple
        [HttpPost]
        public ActionResult ParseExcelFile(ExcelFileDto dto)
        {
            if (Request.Files != null && Request.Files[0].InputStream.Length == 0)
                return View("ParseExcelFile");

            fileMapper.Map(dto,Request.Files[0]);

            parseExcelFileCommand.Execute(dto);

            return RedirectToAction("Index");
        }

        public ActionResult Download(long Id)
        {
            var file = retrieveFileForDownload.Fetch(Id);
            return File(file.Data, "text/csv", file.FileName);
        }
    }
}


