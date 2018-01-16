using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NetCorecnBeta.Models;

namespace NetCorecnBeta.Controllers
{
    [Produces("application/json")]
    [Route("api/cnBetaDownLoad")]
    public class cnBetaDownLoadController : Controller
    {
        public IConfiguration config;
        public cnBetaDownLoadController(IConfiguration configuration)
        {
            config = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> Download(string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.android.package-archive", Path.GetFileName(path));
        }

        [HttpGet]
        public IActionResult CheckVersion(string version)
        {
            string filename = "cnBeta-" + config["CnBetaConfig:Version"] + ".apk";
            var result = new ReturnResult();
            result.Success = true;
            result.Version = config["CnBetaConfig:Version"] ;
            result.DownLoadUrl = filename;
            return Json(result);

        }
    }
}