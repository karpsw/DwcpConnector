using DwcpConnector.Services.Models.Bmc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwcpConnector.Services.Services
{
    public class DwcService:IDwcService
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Task<RcfDescriptorResponseModel> GetRcfDescriptor()
        {



            var path = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "AppData", "rcf_descriptor.json");
            if (System.IO.File.Exists(path))
            {
                return Content(System.IO.File.ReadAllText(path), "application/json");
            }
            return Ok($"Not found {path}");

            var res = new RcfDescriptorResponseModel() { };


            return Task.FromResult(res);
        }
    }
}
