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
        public GetServicesResponseModel GetServices([FromBody] GetServicesRequestModel request)
        {
           
            return new GetServicesResponseModel() {  Response=new GetServicesResponseModel.ResponseModel() { Services=new List<GetServicesResponseModel.ResponseModel.ServicesModel>() { 
                new GetServicesResponseModel.ResponseModel.ServicesModel(){ Id="x1", DisplayId="x1", Description="this X1 srv desc", Excerpt="Except x1", Name="Name x1"}
            } } };
        }
        
        [HttpPost]
        [Route("{connector_path}/com.bmc.dsm.catalog:getService")]
        public GetServiceResponseModel GetService([FromBody] GetServiceRequestModel request)
        {
            return new GetServiceResponseModel()
            {
                Response = new GetServiceResponseModel.ResponseModel()
                {
                    Services = Enumerable.Range(1, 5).Select(index => 
                        new GetServiceResponseModel.ResponseModel.ServiceModel(){ 
                            Id=$"x{index}", DisplayId= $"x{index}", Description=$"this X{index} srv desc", Excerpt= $"Except x{index}", Name=$"Name x{index}",
                            LogoUri=$"logo{index}.jpg", CategoryIds=new[] { $"c{index}", $"c2{index}" },Tags=new[] { $"t{index}", $"t2{index}" },
                            Cost=new GetServiceResponseModel.ResponseModel.ServiceModel.CostClass() {  Amount=2+index, Currency="USD"}
                        }
                    ).ToList()
                }
            };
        }

        
        [HttpPost]
        [Route("{connector_path}/com.bmc.dsm.catalog:getContent")]
        public byte[] GetContent([FromBody] GetContentRequestModel request)
        {
            var path = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "AppData", "img1.jpg");
            if (System.IO.File.Exists(path))
            {
                return System.IO.File.ReadAllBytes(path);
            }

            return null;
        }
        
        [HttpPost]
        [Route("{connector_path}/com.bmc.dsm.catalog:getContent")]
        public byte[] GetContent([FromBody] GetContentRequestModel request)
        {
            var path = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "AppData", "img1.jpg");
            if (System.IO.File.Exists(path))
            {
                return System.IO.File.ReadAllBytes(path);
            }

            return null;
        }



    }
}
