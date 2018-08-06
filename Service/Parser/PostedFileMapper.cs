using System.IO;
using System.Web;
using Dto;
using Dto.Parser;

namespace Service.Parser
{
    public interface IPostedFileMapper
    {
        void Map(ExcelFileDto dto, HttpPostedFileBase file);
    }

    public class PostedFileMapper : IPostedFileMapper
    {
        public void Map(ExcelFileDto dto, HttpPostedFileBase file)
        {
            if (string.IsNullOrEmpty(dto.Title))
                dto.Title = Path.GetFileNameWithoutExtension(file.FileName);

            dto.File = file.InputStream;
        }
    }
}