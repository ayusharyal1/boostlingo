// See https://aka.ms/new-console-template for more information
using BoostlingoApp.Application.Queries;
using BoostlingoApp.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


Console.WriteLine("Boostlingo App");

// Using DI 
var serviceProvider = new ServiceCollection()
           .AddTransient<IGetJsonDataQuery, GetJsonDataQueryHandler>()
           .AddTransient<IJsonDataService, JsonDataService>()
           .BuildServiceProvider();


// Testing the data fetch from API.
var jsonDataService = serviceProvider.GetService<IGetJsonDataQuery>();
var jsonData = jsonDataService?.GetJsonDataQueryAsync().Result;
Console.WriteLine(jsonData.Count);

//string dataUrl = "https://microsoftedge.github.io/Demos/json-dummy-data/64KB.json";




