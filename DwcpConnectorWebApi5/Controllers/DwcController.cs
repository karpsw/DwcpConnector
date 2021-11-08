using DwcpConnectorWebApi5.Models.Bmc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DwcpConnectorWebApi5.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class DwcController : ControllerBase
    {
        

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public DwcController(ILogger<WeatherForecastController> logger,
            IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        } 

        [HttpGet]
        [Route("rcf/descriptor")]
        public IActionResult GetRcfDescriptor()
        {
            var path = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "AppData", "rcf_descriptor.json");
            if (System.IO.File.Exists(path))
            {
                return Content(System.IO.File.ReadAllText(path), "application/json");
            }
            return Ok($"Not found {path}");
        }


        [HttpPost]
        [Route("{connector_path}/com.bmc.dsm.catalog:checkHealth")]
        public CheckHealthResponseModel CheckHealth([FromBody] ConnectionInstanceRequestModel request)
        {
            return new CheckHealthResponseModel() { ConnectionInstanceId = request.ConnectionInstanceId, Response = new ResponseBase() { Status = "CONNECTION_SUCCESS" } };
        }


        
        [HttpPost]
        [Route("{connector_path}/com.bmc.dsm.catalog:getServices")]
        public GetServiceResponseModel GetServices([FromBody] GetServiceRequestModel request)
        {
            return new GetServiceResponseModel() {  Response=new GetServiceResponseModel.ResponseModel() { Services=new List<GetServiceResponseModel.ResponseModel.ServicesModel>() { 
                new GetServiceResponseModel.ResponseModel.ServicesModel(){ Id="x1", DisplayId="x1", Description="this X1 srv", Excerpt="Except x1", Name="Name x1"}
            } } };
        }



    }
}
