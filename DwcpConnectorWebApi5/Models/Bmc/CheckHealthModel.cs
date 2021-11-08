using Newtonsoft.Json;

namespace DwcpConnectorWebApi5.Models.Bmc
{
    public class ConnectionInstanceRequestModel
    {

        [JsonProperty("connectionInstanceId")]
        public string ConnectionInstanceId { get; set; }
    }
    
    public class CheckHealthResponseModel
    {

        [JsonProperty("connectionInstanceId")]
        public string ConnectionInstanceId { get; set; }

        [JsonProperty("response")]
        public ResponseBase Response { get; set; } = new ResponseBase();
    }
}
