using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DwcpConnectorWebApi5.Models.Bmc
{
 
    public class GetContentRequestModel : ConnectionInstanceRequestModel
    {
        [JsonProperty(PropertyName = "request")]
        public RequestModel Request { get; set; }


        public class RequestModel
        {
            [JsonProperty(PropertyName = "uri")]
            public string Uri { get; set; }
        }
    }

}
