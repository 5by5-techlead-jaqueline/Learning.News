using _5by5.Learning.News.Domain;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories;
using _5by5.Learning.News.Infrastructure.Data.Query;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace _5by5.Learning.News.Api.Infrastructure.IoC
{
    public class Bootstrapper
    {
        private readonly IServiceCollection _services;
        public Bootstrapper(IServiceCollection services)
        {
            _services = services;
        }

        public void StructureScoped()
        {
            _services.AddScoped<IDomain, DomainClass>();
            _services.AddScoped<IDataQuery, DataQuery>();
        }
        
        public void InjectDataBase(IConfiguration configuration)
        {
           _services.Configure<Connection>(
            configuration.GetSection(nameof(Connection)));

            _services.AddSingleton<IConnection>(sp =>
            sp.GetRequiredService<IOptions<Connection>>().Value);

            _services.AddSingleton<UserRepository>();
        }
    }
}