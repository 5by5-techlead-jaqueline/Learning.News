using _5by5.Learning.News.CrossCutting.Configuration;
using _5by5.Learning.News.Domain;
using _5by5.Learning.News.Domain.Commands.v1.User.Post;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Interfaces;
using _5by5.Learning.News.Infrastructure.Data.Database.MongoDB.Repositories;
using _5by5.Learning.News.Infrastructure.Data.Query;
using _5by5.Learning.News.Infrastructure.Data.Query.Queries.v1.User.Get;
using _5by5.Learning.News.Infrastructure.Service.Interfaces;
using _5by5.Learning.News.Infrastructure.Service.ServiceHandlers;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Linq;

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

        public void InjectionResilienceSettings(string id)
        {
            var newsApiServiceClient = AppSettings.Settings.ServiceClientsSettings.FirstOrDefault(x => x.Id == id);
            var waitDuration = newsApiServiceClient.Resilience.Retry.WaitDuaration;
            var attempt = newsApiServiceClient.Resilience.Retry.Attempt;

            var retryPolicy = HttpPolicyExtensions.HandleTransientHttpError()
                .WaitAndRetryAsync(attempt, retryAttemp => TimeSpan.FromSeconds(waitDuration));

            _services.AddHttpClient<INewsApiService, NewsApiService>(x => x.BaseAddress = new Uri(newsApiServiceClient.Address))
                .AddPolicyHandler(retryPolicy);
        }
        public void InjectMediator()
        {
            _services.AddMediatR(typeof(PostUserCommandHandler).Assembly);
            _services.AddMediatR(typeof(GetUserCommandHandler).Assembly);
        }

    }
}