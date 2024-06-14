using BoostlingoApp.Application.Commands;
using BoostlingoApp.Application.Queries;
using BoostlingoApp.Domain.Models;
using BoostlingoApp.Infrastructure.Repository;
using BoostlingoApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Configuration;


Console.WriteLine("Boostlingo App");

// Read Configuration
string connectionString = ConfigurationManager.AppSettings["ConnectionString"];
if (string.IsNullOrEmpty(connectionString)) 
{
    throw new Exception("Connection String not configured. Please Check app.config.");
}


// Using DI 
var serviceProvider = new ServiceCollection()
           .AddDbContext<BoostlingoDBContext>(
                 options => options.UseSqlServer(connectionString))
           .AddTransient<IGetJsonDataQuery, GetJsonDataQueryHandler>()
           .AddTransient<IJsonDataHttpGateway, JsonDataHttpGateway>()
           .AddTransient<IInsertUsersCommand, InsertUsersCommandHandler>()
           .AddTransient<IGetUsersSortedByNameQuery, GetUsersSortedByNameQueryHandler>()
           .AddTransient<ITruncateUserCommand, TruncateUserCommandHandler>()
           .AddSingleton<IUserRepository, UserRepository>()
           .AddLogging(loggerBuilder =>
            {
                loggerBuilder.ClearProviders();
                loggerBuilder.AddConsole();
                loggerBuilder.AddFilter("Microsoft", LogLevel.Error);
                loggerBuilder.AddFilter("System", LogLevel.Error);
                loggerBuilder.AddFilter("BoostlingoApp", LogLevel.Debug);
                loggerBuilder.AddConsole();
            })
           .AddAutoMapper(typeof(Program).Assembly)
           .BuildServiceProvider();

// Testing the data fetch from API.
var jsonDataQuery = serviceProvider.GetService<IGetJsonDataQuery>();
List<User> userData = await jsonDataQuery.Execute();
Console.WriteLine("Data fetched. Records Count {0}", userData.Count());

// Data Cleanup before data insertion.
Console.WriteLine("Cleaning data.");
var dataCleanupCommand = serviceProvider.GetService<ITruncateUserCommand>();
dataCleanupCommand.Execute();
Console.WriteLine("Data cleaned.");

// Testing data insertion.
Console.WriteLine("Inserting data.");
var dataInsertionCommand = serviceProvider.GetService<IInsertUsersCommand>();
var result = dataInsertionCommand.Execute(userData);
Console.WriteLine("Data inserted.");

// Fetching data
Console.WriteLine("Fetching and displaying data.");
var dataFetchQuery = serviceProvider.GetService<IGetUsersSortedByNameQuery>();
var sortedResults = await dataFetchQuery.Execute();

foreach (var item in sortedResults)
{
    Console.WriteLine($"{item.Id}\n{item.Name}\n{item.Language}\n{item.Version}\n{item.Bio}\n\n"); 
}

Console.WriteLine("Fetching data completed.");







