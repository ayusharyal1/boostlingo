using BoostlingoApp.Application.Commands;
using BoostlingoApp.Application.Mappers;
using BoostlingoApp.Application.Queries;
using BoostlingoApp.Infrastructure.Repository;
using BoostlingoApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoostlingoApp.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            services
            .AddTransient<IConfiguration>(sp =>
                {
                    IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder.AddJsonFile("appsettings.json");
                    return configurationBuilder.Build();
                })
            .AddDbContext<BoostlingoDBContext>()
            .AddScoped<IGetJsonDataQuery, GetJsonDataQueryHandler>()
            .AddScoped<IJsonDataHttpGateway, JsonDataHttpGateway>()
            .AddScoped<IInsertUsersCommand, InsertUsersCommandHandler>()
            .AddScoped<IGetUsersSortedByNameQuery, GetUsersSortedByNameQueryHandler>()
            .AddScoped<ITruncateUserCommand, TruncateUserCommandHandler>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddLogging(loggerBuilder =>
            {
                loggerBuilder.ClearProviders();
                loggerBuilder.AddConsole();
                loggerBuilder.AddFilter("Microsoft", LogLevel.Error);
                loggerBuilder.AddFilter("System", LogLevel.Error);
                loggerBuilder.AddFilter("BoostlingoApp", LogLevel.Debug);
                loggerBuilder.AddConsole();
            })
            .AddAutoMapper(typeof(AutoMapperProfile).Assembly)
            .AddHttpClient();

            return services;
        }
    }
}
