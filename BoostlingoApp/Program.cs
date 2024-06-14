using BoostlingoApp;
using BoostlingoApp.Extensions;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Boostlingo App Start");
var serviceProvider = new ServiceCollection().AddApplicationServices().BuildServiceProvider();
await App.Run(serviceProvider);
Console.WriteLine("Boostlingo App Stop");









