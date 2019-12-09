using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RockPaperScissorsApplication.Interfaces;
using RockPaperScissorsApplication.Services;
using RockPaperScissorsDomain.Interfaces;
using RockPaperScissorsDomain.Services;

namespace RockPaperScissors
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            setContainer(services);
        }
        private void setContainer(IServiceCollection services)
        {
            
            //Applications
          
            services.AddScoped<IApplicationBattle, ApplicationBattle>();
            services.AddScoped<IApplicationTournament, ApplicationTournament>();

            //Services

            services.AddScoped<IServiceBattle, ServiceBattle>();
            services.AddScoped<IServiceTournament, ServiceTournament>();


        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
