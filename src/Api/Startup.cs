using _5by5.Learning.News.Api.Infrastructure.IoC;
using _5by5.Learning.News.Domain.Commands.v1.User.Post;
using _5by5.Learning.News.Infrastructure.Data.Query.Queries.v1.User.Get;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

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
                c.CustomSchemaIds(type => type.ToString());
            });
            var Bootstrapper = new Bootstrapper(services);

            Bootstrapper.StructureScoped();

            Bootstrapper.InjectionResilienceSettings("ApiNews");
            
            Bootstrapper.InjectDataBase(Configuration);
            Bootstrapper.InjectMediator();

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
