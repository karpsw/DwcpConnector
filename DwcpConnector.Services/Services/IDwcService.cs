using DwcpConnector.Services.Models.Bmc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DwcpConnector.Services.Services
{
    public interface IDwcService
    {
        Task<RcfDescriptorResponseModel> GetRcfDescriptor();
    }
}
