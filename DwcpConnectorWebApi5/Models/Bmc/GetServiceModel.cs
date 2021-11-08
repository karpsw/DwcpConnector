using Newtonsoft.Json;
using System.Collections.Generic;

namespace DwcpConnectorWebApi5.Models.Bmc
{
    public class GetServiceRequestModel : ConnectionInstanceRequestModel
    {
        [JsonProperty(PropertyName = "request")]
         public Request Request { get; set; }
    }

    public class Request
    {
        [JsonProperty(PropertyName = "serviceId")]
        public string ServiceId { get; set; }
    }


    public class GetServiceResponseModel: ConnectionInstanceRequestModel
    {
        [JsonProperty("response")]
        public ResponseModel Response { get; set; } = new ResponseModel();


        public class ResponseModel
        {
            //[JsonProperty(PropertyName = "serviceId")]
            //public string ServiceId { get; set; }

            
            [JsonProperty(PropertyName = "services")]
            public List<ServicesModel> Services { get; set; }

            public class ServicesModel
            {
                [JsonProperty(PropertyName = "id")]
                public string Id { get; set; }

                [JsonProperty(PropertyName = "displayId")]
                public string DisplayId { get; set; }
                
                [JsonProperty(PropertyName = "name")]
                public string Name { get; set; }

               
                [JsonProperty(PropertyName = "logoUri")]
                public string LogoUri { get; set; }
                
                
                [JsonProperty(PropertyName = "excerpt")]
                public string Excerpt { get; set; }
                
                
                [JsonProperty(PropertyName = "description")]
                public string Description { get; set; }
                

                [JsonProperty(PropertyName = "categoryIds")]
                public string[] CategoryIds { get; set; }
                
                [JsonProperty(PropertyName = "tags")]
                public string[] Tags { get; set; }
                
                [JsonProperty(PropertyName = "cost")]
                public CostClass Cost { get; set; }


                public class CostClass {
                    [JsonProperty(PropertyName = "amount")]
                    public int Amount { get; set; }

                    [JsonProperty(PropertyName = "currency")]
                    public string Currency { get; set; }


                }
            }
        }



    }

}
