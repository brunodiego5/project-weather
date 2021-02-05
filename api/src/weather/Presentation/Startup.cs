using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Profiles;
using AutoMapper;
using CrossCuting;
using Infrastructure.Data.Profiles;
using Infrastructure.Data.Repositories;
using Infrastructure.Service.Contracts;
using Infrastructure.Service.Profiles;
using Infrastructure.Service.ServiceHandlers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Presentation
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
            var systemSettings = new SystemSettings();
            new ConfigureFromConfigurationOptions<SystemSettings>(Configuration.GetSection("SystemSettings")).Configure(systemSettings);
            
            services.AddSingleton(systemSettings);

            services.AddControllers();
            services.AddSwaggerGen();

            var assembly = AppDomain.CurrentDomain.Load("Application");
            services.AddMediatR(assembly);
            services.AddScoped<ICityRepository, CityMongoRepository>();
            //services.AddScoped<IWeatherServiceClient, OpenWeatherMapServiceClient>();
            services.AddAutoMapper(
                Assembly.GetAssembly(typeof(CityDtoProfile)),
                Assembly.GetAssembly(typeof(CitySchemaProfile)),
                Assembly.GetAssembly(typeof(WeatherDtoProfile)),
                Assembly.GetAssembly(typeof(GetWeatherResponseProfile)));
            services.AddHttpClient<IWeatherServiceClient, OpenWeatherMapServiceClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
