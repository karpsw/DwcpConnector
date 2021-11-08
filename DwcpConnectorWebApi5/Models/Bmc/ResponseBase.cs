using Newtonsoft.Json;

namespace DwcpConnectorWebApi5.Models.Bmc
{
    public class ResponseBase
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
