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
        private readonly UnitOfWork _UW;
        private readonly ILogger<UploadFileController> _Logger;
        private readonly IHostingEnvironment _ENV;

        public UploadFileController(UnitOfWork UW, ILogger<UploadFileController> Logger, IHostingEnvironment ENV)
        {
            _UW = UW;
            _Logger = Logger;
            _ENV = ENV;
        }

        [HttpPost]
        public async Task<string> UploadImage([FromBody] string ImageBase64)
        {
            byte[] bytes = Convert.FromBase64String(ImageBase64);
            var PathFile = Path.Combine($"/Files/{Guid.NewGuid()}.jpg");
            await System.IO.File.WriteAllBytesAsync(PathFile, bytes);
            _Logger.LogInformation(" success upload File methode call by npb");
            return "آپلود فایل با موفقیت انجام شد";
        }



    }
}
