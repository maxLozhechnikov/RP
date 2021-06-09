<<<<<<< Updated upstream
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
=======
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharedLib;
>>>>>>> Stashed changes

namespace Valuator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

<<<<<<< Updated upstream
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<IMessageBroker, NatsBroker>();
            services.AddScoped<IStorage, RedisStorage>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
=======
        private IConfiguration Configuration { get; }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddScoped<IStorage, RedisStorage>();
            services.AddScoped<IMessageBroker, NatsBroker>();
        }

>>>>>>> Stashed changes
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
<<<<<<< Updated upstream
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
=======
>>>>>>> Stashed changes
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
<<<<<<< Updated upstream

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
=======
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapRazorPages(); });
        }
    }
}
>>>>>>> Stashed changes
