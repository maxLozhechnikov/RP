<<<<<<< Updated upstream
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Valuator
{
    public class Program
=======
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Valuator
{
    public static class Program
>>>>>>> Stashed changes
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

<<<<<<< Updated upstream
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
=======
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}
>>>>>>> Stashed changes
