using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DwcpConnectorWebApi5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

       public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


/* 
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
      Host.CreateDefaultBuilder(args)
          .ConfigureWebHostDefaults(webBuilder =>
          {
              webBuilder.UseStartup<Startup>();
              webBuilder.UseKestrel(opts =>
              {
                    // Bind directly to a socket handle or Unix socket
                    // opts.ListenHandle(123554);
                    // opts.ListenUnixSocket("/tmp/kestrel-test.sock");
                    //opts.Listen(IPAddress.Loopback, port: 5002);
                  opts.ListenAnyIP(9001);
                  opts.ListenLocalhost(9002, opts => opts.UseHttps());
                  //opts.ListenLocalhost(5005, opts => opts.UseHttps());
              });

          });
        */
    }

}
