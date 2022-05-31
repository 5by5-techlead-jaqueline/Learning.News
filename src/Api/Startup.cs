using _5by5.Learning.News.Api.Infrastructure.IoC;
using _5by5.Learning.News.CrossCutting.Configuration;
using _5by5.Learning.News.Infrastructure.Service.Interfaces;
using _5by5.Learning.News.Infrastructure.Service.ServiceHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Linq;

namespace _5by5.Learning.News.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NewsAPI", Version = "v1" });
            });
            var Bootstrapper = new Bootstrapper(services);
            Bootstrapper.StructureScoped();

            var waitDuration = AppSettings.Settings.ResilienceAPI.Retry.WaitDuaration;
            var attempt = AppSettings.Settings.ResilienceAPI.Retry.Attempt;

            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(attempt, retryAttemp => TimeSpan.FromSeconds(waitDuration));

            services.AddHttpClient<INewsApiService, NewsApiService>(x => x.BaseAddress = new Uri(AppSettings.Settings.NoticesApi.FirstOrDefault(x => x.Id == "ApiNews").Address))
                .AddPolicyHandler(retryPolicy);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiNews v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
