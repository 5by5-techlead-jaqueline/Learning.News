using _5by5.Learning.News.Domain;
using _5by5.Learning.News.Infrastructure.Data.Query;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

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
    }
}