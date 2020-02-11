using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TamrinLogger.Models.UnitOfWork;

namespace TamrinLogger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        //private readonly UnitOfWork _UW;
        //prvate readonly ILogger _Logger;
        private readonly IHostingEnvironment _env;

        public UploadFileController(IHostingEnvironment env)
        {
            //  _UW = UW;
            //            _Logger = Logger;
            _env = env;
        }

        [HttpPost]
        public async Task<string> UploadImage([FromBody] string ImageBase64)
        {
            byte[] bytes = Convert.FromBase64String(ImageBase64);
            //var PathFile = Path.Combine($"/Files/{Guid.NewGuid()}.jpg");
            var pathFile = Path.Combine($"{_env.WebRootPath}/Files/{Guid.NewGuid()}.jpg");
            await System.IO.File.WriteAllBytesAsync(pathFile, bytes);
            

            //_Logger.LogInformation(" success upload File methode call by npb");
            return "آپلود فایل با موفقیت انجام شد";
        }



    }
}