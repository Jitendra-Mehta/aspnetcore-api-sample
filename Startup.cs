using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_api_sample.ModelMapper;
using aspnetcore_api_sample.Models;
using aspnetcore_api_sample.Provider;
using aspnetcore_api_sample.Provider.IProvider;
using aspnetcore_api_sample.Services;
using aspnetcore_api_sample.Services.IServices;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace aspnetcore_api_sample
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
            services.AddSingleton<IConfiguration>(Configuration); 
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //services.AddDbContext<DbContextModel>(opts => opts.UseMySQL(Configuration["ConnectionString:con_staring"]));
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("SampleAPIDoc",
                    new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Title = "Sample API",
                        Version = "1"
                    });
            });

            services.AddTransient<IUserServices, UsersServices>();
            services.AddTransient<IUsersProvider, UsersProvider>();
            services.AddAutoMapper(typeof(AoutoMapper));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .Build());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(option =>
            {
                option.SwaggerEndpoint("/swagger/SampleAPIDoc/swagger.json", "Sample API");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
