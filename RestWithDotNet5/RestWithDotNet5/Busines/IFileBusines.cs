using Microsoft.AspNetCore.Http;
using RestWithDotNet5.Data.VO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestWithDotNet5.Busines
{
    public interface IFileBusines
    {
        public byte[] GetFile(string fileName);
        public Task<FileDetailVO> SaveFileToDisk(IFormFile file);
        public Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> files);
    }
}
