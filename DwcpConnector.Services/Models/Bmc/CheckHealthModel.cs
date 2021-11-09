using Newtonsoft.Json;

namespace DwcpConnector.Services.Models.Bmc
{
    public class ConnectionInstanceRequestModel
    {

        [JsonProperty("connectionInstanceId")]
        public string ConnectionInstanceId { get; set; }
    }
    
    public class CheckHealthResponseModel : ConnectionInstanceRequestModel
    {

        [JsonProperty("response")]
        public ResponseBase Response { get; set; } = new ResponseBase();
    }
}
